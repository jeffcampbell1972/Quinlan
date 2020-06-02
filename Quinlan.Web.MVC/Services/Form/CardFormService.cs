using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class CardFormService : IFormService<CardViewModel>
    {
        ICrudService<Card> _cardService;
        public CardFormService(ICrudService<Card> cardService)
        {
            _cardService = cardService;
        }
        public void Save(CardViewModel cardVM)
        {
            if (cardVM == null)
            {
                throw new Exception();
            }

            var card = new Card
            {
                Identifier = cardVM.Identifier 
            };

            _cardService.Post(card);
        }
        public void Save(int id, CardViewModel cardVM)
        {
            if (cardVM == null)
            {
                throw new Exception();
            }

            var card = new Card
            {
                Id = id ,
                Identifier = cardVM.Identifier
            };

            _cardService.Put(id, card);
        }
    }
}
