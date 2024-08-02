const config = require('../config');

exports.Authenticate = async () => {
  const fetch = (await import('node-fetch')).default;
  const url = config.FEDEX_URL + 'Account/authenticate';
  const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
  };
  const body = {
      email: config.FEDEX_EMAIL, 
      password: config.FEDEX_PASS
  }
  
  const response = await fetch(url, { 
      agent: config.HTTPS_AGENT,
      headers: headers,
      method: 'POST',
      body: JSON.stringify(body),
  });
  
  if (response.status !== 200) {
      throw new Error("An error has occured trying to authenticate with FEDEX");
  } 

  return response;
};

exports.CreateOrder = async (bearerToken, contactAddress, warehouseAddress, packageDimensions) => {
  const fetch = (await import('node-fetch')).default;
  const url = config.FEDEX_URL + 'v1/Order';
  const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Authorization': `Bearer ${bearerToken}`,
  };
  const body = {
    contactAddress: contactAddress,
    warehouseAddress: warehouseAddress,
    packageDimensions: packageDimensions
  }
  
  const response = await fetch(url, { 
      agent: config.HTTPS_AGENT,
      headers: headers,
      method: 'POST',
      body: JSON.stringify(body),
  });
  
  if (response.status !== 200) {
      throw new Error("An error has occured trying to create an order with FEDEX");
  } 

  return response;
};

