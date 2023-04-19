using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private ICollection <ICocktail> models;   
        public CocktailRepository()
        {
            this.models = new List <ICocktail> ();
        }
        public IReadOnlyCollection<ICocktail> Models => this.models.ToList().AsReadOnly();

        public void AddModel(ICocktail model)
        {
            this.models.Add(model);
        }
    }
}
