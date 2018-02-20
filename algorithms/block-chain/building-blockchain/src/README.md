# Building Blockchain
Article [link](https://jeiwan.cc/posts/building-blockchain-in-go-part-1/)

## About Blockchain

**Block** stores valuable information. For example bitcoin blocks store transactions.

**Blockchain** is a distributed database of records. But what makes it unique is that it’s not a private database, but a public one, i.e. everyone who uses it has a full or partial copy of it. And a new record can be added only with a consent of other keepers of the database. Also, it’s blockchain that made cryptocurrencies and smart contracts possible.

**Proof of work** is some useful work that allows to add a new block to a blockchain.
POW has a requirement: doing the work is hard, but verifying is easy.

## Hashing

**Hashing** is a process of obtaining a hash for specified data. A hash is a unique representation of the data it was calculated on.

Hashing key features: 
- Original data cannot be restored from a hash. Thus, hashing is not encryption;
- Certain data can have only one hash and the hash is unique;
- Changing even one byte in the input data will result in a completely different hash.

Bitcoin uses a **Hashcach**. It's a POW algorithm.

**Hashcach steps:**
1. Take some publicly known data (in case of email, it’s receiver’s email address; in case of Bitcoin, it’s block headers).
2. Add a counter to it. The counter starts at 0.
3. Get a hash of the data + counter combination.
4. Check that the hash meets certain requirements.
	- If it does, you’re done.
	- If it doesn’t, increase the counter and repeat the steps 3 and 4.

