package module2

import (
	"bytes"
	"crypto/sha256"
	"fmt"
	"math"
	"math/big"
	"strconv"
)

const targetBits = 24
const maxNonce = math.MaxInt64

type ProofOfWork struct {
	Block  *Block
	Target *big.Int
}

func NewProofOfWork(b *Block) *ProofOfWork {
	target := big.NewInt(1)
	target.Lsh(target, uint(256-targetBits))

	pow := &ProofOfWork{b, target}

	return pow
}

func (pow *ProofOfWork) PrepareData(nonce int) []byte {
	data := bytes.Join(
		[][]byte{
			pow.Block.PrevBlockHash,
			pow.Block.Data,
			[]byte(strconv.FormatInt(pow.Block.Timestamp, 10)),
			[]byte(strconv.FormatInt(targetBits, 10)),
			[]byte(strconv.FormatInt(int64(nonce), 10)),
		},
		[]byte{},
	)

	return data
}

func (pow *ProofOfWork) Run() (int, []byte) {
	var hashInt big.Int
	var hash [32]byte

	nonce := 0

	fmt.Printf("Mining the block containing \"%s\"\n", pow.Block.Data)

	for nonce < maxNonce {
		data := pow.PrepareData(nonce)
		hash = sha256.Sum256(data)

		fmt.Printf("\r%x", hash)
		hashInt.SetBytes(hash[:])

		if hashInt.Cmp(pow.Target) == -1 {
			break
		} else {
			nonce++
		}
	}

	return nonce, hash[:]
}

func (pow *ProofOfWork) Validate() bool {
	var hashInt big.Int

	data := pow.PrepareData(pow.Block.Nonce)
	hash := sha256.Sum256(data)
	hashInt.SetBytes(hash[:])

	isValid := hashInt.Cmp(pow.Target) == -1

	return isValid
}
