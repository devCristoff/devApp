const express = require('express');

const OfferController = require('../controllers/OfferController');
const router = express.Router();

router.post('/best-offer', OfferController.PostBestOffer);

module.exports = router;