import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'AdvBoxCRM',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44380/',
    redirectUri: baseUrl,
    clientId: 'AdvBoxCRM_App',
    responseType: 'code',
    scope: 'offline_access AdvBoxCRM',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44380',
      rootNamespace: 'AdvBoxCRM',
    },
  },
} as Environment;
