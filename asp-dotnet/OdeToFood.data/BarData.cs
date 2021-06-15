using OdeToCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.data
{
  public interface BarData
    {
        IEnumerable<BarsClass> GetAll();

        public class InMemBarData : BarData
        {
            public List<BarsClass> bars;
            
            public InMemBarData()
            {
                bars = new List<BarsClass>
                {
                    new BarsClass { ID = 1, Name = "Blakes Bar", Location = "ABQ", Type = BarType.Beer },
                    new BarsClass { ID = 2, Name = "Pub Place", Location = "DFW", Type = BarType.Whiskey },
                    new BarsClass { ID = 3, Name = "Werido Wine", Location = "NYW", Type = BarType.Wine }
                };
            }

            IEnumerable<BarsClass> BarData.GetAll()
            {
                return bars.OrderBy(b => b.Name).ToList();
            }
        }
    }
}
