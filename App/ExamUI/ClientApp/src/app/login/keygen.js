const forge = require('node-forge');
// Generate an RSA key pair
const keyPair = forge.pki.rsa.generateKeyPair({ bits: 2048 });
// Get the private key in PEM format
const privateKey = forge.pki.privateKeyToPem(keyPair.privateKey);

// Get the public key in PEM format
const publicKey = forge.pki.publicKeyToPem(keyPair.publicKey);

// Print the private key and public key
console.log(privateKey);
console.log(publicKey);
