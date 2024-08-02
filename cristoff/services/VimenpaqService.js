const config = require('../config');
const { create } = require('xmlbuilder2');
const { parseStringPromise } = require('xml2js');

exports.Authenticate = async () => {
    const fetch = (await import('node-fetch')).default;
    const url = config.VIMENPAQ_URL + 'Account/authenticate';
    const headers = {
        'Content-Type': 'application/xml',
        'Accept': 'application/xml',
    };
    const body = {
        email: config.VIMENPAQ_EMAIL, 
        password: config.VIMENPAQ_PASS
    }
    // Convert to XML
    const xmlBody = create({ version: '1.0', encoding: 'UTF-8' })
        .ele('AuthenticationRequest')
        .ele('email').txt(body.email).up()
        .ele('password').txt(body.password)
        .end({ prettyPrint: true });
  
    const response = await fetch(url, { 
        agent: config.HTTPS_AGENT,
        headers: headers,
        method: 'POST',
        body: xmlBody,
    });
  
    if (response.status !== 200) {
        throw new Error("An error has occured trying to authenticate with VIMENPAQ");
    } 

    const responseText = await response.text();
    const responseXml = await parseStringPromise(responseText);

    return responseXml;
};

exports.CreateOrder = async (bearerToken, source, destination, packages) => {
    const fetch = (await import('node-fetch')).default;
    const url = config.VIMENPAQ_URL + 'v1/Order';
    const headers = {
        'Content-Type': 'application/xml',
        'Accept': 'application/xml',
        'Authorization': `Bearer ${bearerToken}`,
    };
    const body = {
        source: source,
        destination: destination,
        packages: packages
    }
    // Convert to XML
    let xmlBody = create({ version: '1.0', encoding: 'UTF-8' })
    .ele('OrderRequest')
    .ele('source').txt(body.source).up()
    .ele('destination').txt(body.destination).up()
    .ele('packages');

    body.packages.forEach(pkg => {
        xmlBody.ele('package').txt(pkg).up();
    });

    xmlBody = xmlBody.end({ prettyPrint: true });
    
    const response = await fetch(url, { 
        agent: config.HTTPS_AGENT,
        headers: headers,
        method: 'POST',
        body: xmlBody,
    });
    
    if (response.status !== 200) {
        throw new Error("An error has occured trying to create an order with VIMENPAQ");
    } 

    const responseText = await response.text();
    const responseXml = await parseStringPromise(responseText);

    return responseXml;
};

