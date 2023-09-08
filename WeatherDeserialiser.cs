using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForecast
{
    public class WeatherDeserialiser
    {
        public RootContainer Deserialize(string xmlData)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(RootContainer));
            using(StringReader reader = new StringReader(xmlData))
            {
                RootContainer rootData = (RootContainer)serialiser.Deserialize(reader);
                if(rootData != null && rootData.ForecastData.ForecastDays.Length > 0)
                {
                    return rootData;
                }
                else
                {
                    throw new Exception("Something got wrong");
                }
            }
        }
    }
}
