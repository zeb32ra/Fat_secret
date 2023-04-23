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
        public List<PunkttiDTO> punkts_for_day;

        public Choise_for_day(string d, List<PunkttiDTO> punkts)
        {
            date = d;
            punkts_for_day = punkts;
        }
    }
}
