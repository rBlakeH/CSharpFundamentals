using OdeToCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.data
{
  public interface BarData
    {
        IEnumerable<Bars> GetAll();

        public class InMemBarData : BarData
        {
            public List<Bars> bars;
            
            public InMemBarData()
            {
                bars = new List<Bars>();
                {
                    new Bars {ID =1, Name = "Blakes Bar", Location ="ABQ", Type=BarType.Beer},
                    new Bars {ID =2, Name = "Pub Place", Location ="DFW", Type= BarType.Whiskey},
                    new Bars {ID =3, Name = "Werido Wine", Location ="NYW", Type=BarType.Wine},

                };

            }

            IEnumerable<Bars> BarData.GetAll()
            {
                return bars.OrderBy(b => b.Name).ToList();
            }
        }
    }
}
