const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const config = require('./config');
const FedexService = require('./services/FedexService');
const DomexService = require('./services/DomexService');
const VimenpaqService = require('./services/VimenpaqService');

const middleware = express.Router();

middleware.use(bodyParser.json());
middleware.use(cors());

middleware.use('/api/offer/best-offer', async (req, res, next) => {
    try {
        const fedexResponse = await FedexService.Authenticate();
        const fedexData = await fedexResponse.json();
        req.fedexToken = fedexData.jwToken;

        next();
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: "An error has occured trying to authenticate with FEDEX" });
    }
});

middleware.use('/api/offer/best-offer', async (req, res, next) => {
    try {
        const domexResponse = await DomexService.Authenticate();
        const domexData = await domexResponse.json();
        req.domexToken = domexData.jwToken;

        next();
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: "An error has occured trying to authenticate with DOMEX" });
    }
});

middleware.use('/api/offer/best-offer', async (req, res, next) => {
    try {
        const vimenpaqResponse = await VimenpaqService.Authenticate();
        const vimenpaqData = await vimenpaqResponse.AuthenticationResponse;
        req.vimenpaqToken = vimenpaqData.JWToken[0];

        next();
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: "An error has occured trying to authenticate with VIMENPAQ" });
    }
});

module.exports = middleware;