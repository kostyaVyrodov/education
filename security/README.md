# Security in applications

## Symmetric and asymmetric algorithms of encryption

Symmetric algorithms use the same key for encrypting and decrypting.
Examples of algorithms: AES, DES, RC5, RC6.

Asymmetric algorithms use a public key for encrypting and private key decrypting.
Examples of algorithms: RSA, DSA, Elliptic curve techniques.

Asymmetric encryption takes relatively more time than the symmetric encryption.

## Digital certificates and digital signature

Digital certificates are based on asymmetric cipher algorithms.

A certificate is a package of information that identifies a user and a server. It contains info about organization's name, the organization that issued the certificate, user's email, country and user's public key.

## HTTPS

HTTPS allows to prevent 'man in the middle' attack, making possible to possible securely transfer data between a client and a server.

HTTPS cons:

- requires more computational power;
- transfer bigger amount of data;
- make it impossible to use caching.

TLS (transport security protocol) is a child of SSL protocol that's used for providing secure connection of HTTP (Secure HTTP is called HTTPS)

TLS lives on 'session' layer.

TLS is hybrid cryptography system using asymmetric(for key exchanging and proofing of identity) and symmetric(for encrypting data) encrypting. TLS uses Diffie-Hellman algorithm to exchange keys.
