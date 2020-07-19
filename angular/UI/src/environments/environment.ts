
export const idpBase = 'http://localhost:5000';
export const apiBase = 'http://localhost:5001';
export const angularBase = 'http://localhost:4200';

export const environment = {
  production: false,
  apiBase,
  openIdConnectSettings: {
    authority: `${idpBase}`,
    client_id: 'ngClient',
    redirect_uri: `${angularBase}/callback.html`,
    silent_redirect_uri: `${angularBase}/renew-callback.html`,
    post_logout_redirect_uri: `${angularBase}/signout-callback.html`,
    scope: 'api1 openid profile email',
    response_type: 'id_token token',
    automaticSilentRenew: true,
    accessTokenExpiringNotificationTime: 5,
    filterProtocolClaims: true,
    loadUserInfo: true
  }
};


