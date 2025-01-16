using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_API
{
    public class WeatherResponse
    {

        public string Name { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }
}
