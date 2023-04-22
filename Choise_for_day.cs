using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat_Secret
{
    internal class Choise_for_day
    {
        public string date;
        [JsonIgnore]
        public List<Punktti> punkts_for_day;

        public Choise_for_day(string d, List<Punktti> punkts)
        {
            date = d;
            punkts_for_day = punkts;
        }
    }
}
