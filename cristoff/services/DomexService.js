const config = require('../config');

exports.Authenticate = async () => {
  const fetch = (await import('node-fetch')).default;
  const url = config.DOMEX_URL + 'Account/authenticate';
  const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
  };
  const body = {
      email: config.DOMEX_EMAIL, 
      password: config.DOMEX_PASS
  }
  
  const response = await fetch(url, { 
      agent: config.HTTPS_AGENT,
      headers: headers,
      method: 'POST',
      body: JSON.stringify(body),
  });
  
  if (response.status !== 200) {
      throw new Error("An error has occured trying to authenticate with DOMEX");
  } 

  return response;
};

exports.CreateOrder = async (bearerToken, consigee, consignor, cartons) => {
  const fetch = (await import('node-fetch')).default;
  const url = config.DOMEX_URL + 'v1/Order';
  const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Authorization': `Bearer ${bearerToken}`,
  };
  const body = {
    consigee: consigee,
    consignor: consignor,
    cartons: cartons
  }
  
  const response = await fetch(url, { 
      agent: config.HTTPS_AGENT,
      headers: headers,
      method: 'POST',
      body: JSON.stringify(body),
  });
  
  if (response.status !== 200) {
      throw new Error("An error has occured trying to create an order with DOMEX");
  } 

  return response;
};

