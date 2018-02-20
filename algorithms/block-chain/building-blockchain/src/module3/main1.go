package main

// Proof-of-Work algorithms must meet a requirement: doing the work is hard, but verifying the proof is easy.

// Hashing is a process of obtaining a hash for specified data.
// A hash is a unique representation of the data it was calculated on.
// A hash function is a function that takes data of arbitrary size and produces a fixed size hash.

// Here are some key features of hashing:
// Original data cannot be restored from a hash. Thus, hashing is not encryption.
// Certain data can have only one hash and the hash is unique.
// Changing even one byte in the input data will result in a completely different hash.

// bc := NewBlockchain()
// bc.AddBlock("Send 1 BTC to Ivan")
// bc.AddBlock("Send 2 more BTC to Ivan")

// for _, block := range bc.blocks {
// 	fmt.Printf("Prev. hash: %x\n", block.PrevBlockHash)
// 	fmt.Printf("Data: %s\n", block.Data)
// 	fmt.Printf("Hash: %x\n", block.Hash)
// 	fmt.Println()

// 	pow := NewProofOfWork(block)
// 	fmt.Printf("PoW: %s\n", strconv.FormatBool(pow.Validate()))
// 	fmt.Println()
// }

func main() {

}
