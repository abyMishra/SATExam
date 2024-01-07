// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  gatewayBaseUrl: 'https://localhost:7080',
  authenticateUrl: '/api/Users/AuthanticateUser',
  createUserUrl: '/Users/CreateUser',
  publicKey: '-----BEGIN PUBLIC KEY-----\n' +
    'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2bq72ckd0dqEgxWAYHALaiQ0B8RFZ7GO1Zjs4QnBFUNAutiLhpz7WjWaGuD8R1plyF1OWhJQfoBSbCDGW/Y1BSU2AJI5mobMnL2fOyygCVlEzw9RMP4y1BmTdIi + QDcuOSIOoT0Abjd / MOb54gmrCbGiDrI5oCE / pDCBDViwndkD + 6JsPTgQ4I9rAHGkTy0pDLv8NvvyACNFVPMfqS6RYVTOAGBaUeVooiqxGGPkMQTSGuBz3fZrrfwN9QbiR8JZJLMl7dsEmEgksifZ1kn622yJRSjtVC1jk0Iu8jfQz28dTZPDmGXsesqIApvagTr7raN7Z7SeIZTy1xRU3zDG5QIDAQAB\n' + 'MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2bq72ckd0dqEgxWAYHALaiQ0B8RFZ7GO1Zjs4QnBFUNAutiLhpz7WjWaGuD8R1plyF1OWhJQfoBSbCDGW/Y1BSU2AJI5mobMnL2fOyygCVlEzw9RMP4y1BmTdIi + QDcuOSIOoT0Abjd / MOb54gmrCbGiDrI5oCE / pDCBDViwndkD + 6JsPTgQ4I9rAHGkTy0pDLv8NvvyACNFVPMfqS6RYVTOAGBaUeVooiqxGGPkMQTSGuBz3fZrrfwN9QbiR8JZJLMl7dsEmEgksifZ1kn622yJRSjtVC1jk0Iu8jfQz28dTZPDmGXsesqIApvagTr7raN7Z7SeIZTy1xRU3zDG5QIDAQAB\n' +
    '-----END PUBLIC KEY-----'
  
  // contentCountriesUrl: '/Content/allCountry',
  // contentCurrenciesUrl: '/Content/allCurrency'
};

export const IdentityCompanyPublic = {
  production: false,
  gatewayBaseUrl: 'http://localhost:5297',
  Url: '/Identity/PublicDetails'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
