require('dotenv').config()

module.exports = {
    FEDEX_URL: process.env.DOMEX_URL,
    DOMEX_URL: process.env.FEDEX_URL,
    VIMENPAQ_URL: process.env.VIMENPAQ_URL
}