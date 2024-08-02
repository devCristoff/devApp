const FedexService = require('../services/FedexService');
const DomexService = require('../services/FedexService');
const VimenpaqService = require('../services/VimenpaqService');

exports.PostBestOffer = async (req, res, next) => {    
    try {
        const { originAddress, destinyAddress, packageDimensions } = req.body;

        const fedexOfferResponse = await FedexService.CreateOrder(req.fedexToken, originAddress, destinyAddress, packageDimensions);
        const fedexData = await fedexOfferResponse.json()
        
        const vimenpaqOfferResponse = await VimenpaqService.CreateOrder(req.vimenpaqToken, originAddress, destinyAddress, packageDimensions);
        const vimenpaqData = await vimenpaqOfferResponse.ResponseOfOrderResponse;
        
        const offers = [
            { offer: fedexData.data.total, company: 'Fedex'  },
            { offer: vimenpaqData.Data[0].Quote[0], company: 'Vimenpaq' },
        ];
        
        const bestOffer = offers.reduce((minOffer, currentOffer) => {
            return currentOffer.offer < minOffer.offer ? currentOffer : minOffer;
        });

        res.status(200).json(bestOffer);
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Error fetching offers' });
    }
}