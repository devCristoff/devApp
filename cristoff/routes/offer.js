const express = require('express');

const OfferController = require('../controllers/OfferController');
const router = express.Router();

router.get('/', OfferController.GetBest);

module.exports = router;