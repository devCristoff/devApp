require('dotenv').config()

const https = require('https');

// Create an HTTPS agent that ignores SSL certificate validation
const httpsAgent = new https.Agent({
    rejectUnauthorized: false
});

module.exports = {
    HTTPS_AGENT: httpsAgent, 
    FEDEX_URL: process.env.FEDEX_URL,
    FEDEX_EMAIL: process.env.FEDEX_EMAIL,
    FEDEX_PASS: process.env.FEDEX_PASS,
    DOMEX_URL: process.env.DOMEX_URL,
    DOMEX_EMAIL: process.env.DOMEX_EMAIL,
    DOMEX_PASS: process.env.DOMEX_PASS,
    VIMENPAQ_URL: process.env.VIMENPAQ_URL,
    VIMENPAQ_EMAIL: process.env.VIMENPAQ_EMAIL,
    VIMENPAQ_PASS: process.env.VIMENPAQ_PASS,
}