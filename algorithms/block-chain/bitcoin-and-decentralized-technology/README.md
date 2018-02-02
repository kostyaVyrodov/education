# Bitcoin and Decentralized Technology

## Bitcoin overview

### General summary
- You don't need login to a site to buy something, also you don't need to add any private information such as credit card number or CVV code. Web app needs to know only your IP address;
- Bitcoin is electronic version of cash;
- When you buy something using bitcoin you push it to consumer. When you buy something using credit card, you share your information and allow a service to pull money;
- Every transaction is public, your identity is private. It's hidden under the GUID of transaction; 
- Bitcoin is controlled by network of people(bookkeepers), not one organization;
- Wallet corresponds your private key

### Bitcoin security

Every transaction is signed by cryptographic digital signature. It's the same as simple human's signature.
CDS is created for every transaction, so it can't be stolen and reused.

**Digital signature consists of**
- Public key - bitcoin address;
- Private key - password to spend money;
- Encryption

Keys are mathematically related.

If a user lose his private key he will lose his money. Nobody can reset his password.

**Decentralized downsides**
 - Less efficient - high value transactions require 1 hours;
 - Proof of work burn energy by design;
 - Changing more difficult - widespread agreement needed.

 ## Bitcoin under the hood

 ### Bitcoin software universe
 - Software for creating private keys and addresses. Create and sign transactions (wallets/thin clients); 
 - Software for booking keeper tasks: wallet functionality, check and relay transactions, maintain full ledger (full node/ bitcoin core);
 - Solving proof of work puzzle in voting process (voter/miners);