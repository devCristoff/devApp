const FedexService = require('../services/FedexService');
const DomexService = require('../services/FedexService');
const VimenpaqService = require('../services/FedexService');

exports.PostBestOffer = async (req, res, next) => {    
    try {
        const { contactAddress, warehouseAddress, packageDimensions } = req.body;

        const fedexOfferResponse = await FedexService.CreateOrder(req.fedexToken, contactAddress, warehouseAddress, packageDimensions);

        const data = await fedexOfferResponse.json()
        console.log(data.data.total);

        res.status(200).json(fedexOffer.json());
    } catch (error) {
        // console.error(error);
        res.status(500).json({ error: 'Error fetching offers' });
    }
}