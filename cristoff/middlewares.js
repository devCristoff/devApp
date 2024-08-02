const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const config = require('./config');
const FedexService = require('./services/FedexService');

const middleware = express.Router();

middleware.use(bodyParser.json());
middleware.use(cors());

middleware.use('/api/offer/best-offer', async (req, res, next) => {
    try {
        const response = await FedexService.Authenticate();
        const data = await response.json();
        req.fedexToken = data.jwToken;

        next();
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: "An error has occured trying to authenticate with FEDEX" });
    }
});

module.exports = middleware;