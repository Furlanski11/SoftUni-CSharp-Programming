using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> booths;
        public BoothRepository()
        {
            booths = new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models => booths;

        public void AddModel(IBooth model)
        {
            booths.Add(model);
        }
    }
}
