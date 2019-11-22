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

## Security testing

There are 3 types of security testing:
- Static application security testing - analyzing of source codes to find vulnerabilities;
- Dynamic application security testing - trying to hack a running program to find vulnerabilities;
- Interactive application security testing - combination of the both above.

Main types of dynamic security testing:
- Vulnerability assessment (finding issues without exploiting);
- Penetration testing (find one vulnerability and exploit it to obtain the goal);

### Risks

Top 10 risks according to OWASP

1. Injections (OS commands, SQL, etc.);
2. Broken auth and session management;
3. Sensitive data exposures (like api secrets, rsa keys);
4. XML external entities (vulnerable XML processors);
5. Broken access control (when application has bad access control);
6. Security misconfiguration (of a server for example);
7. XSS (JS injecting to pages);
8. Insecure Deserialization (lead to remote code execution attacks);
9. Components with known vulnerabilities (just using components that have vulnerabilities);
10. Insufficient Logging & Monitoring (allows a hacker to be undetected);
