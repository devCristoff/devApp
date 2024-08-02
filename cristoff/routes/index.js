const express = require('express');

const offerRoute = require('./offer');
const router = express.Router();

router.use('/offer', offerRoute);

module.exports = router;