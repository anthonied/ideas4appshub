using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas4AppsHub.Domain
{
    public class GPS
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }


        private string _value;
        public string Value
        {
            get
            {
                _value = String.Format("{0},{1}", Longitude, Latitude);
                return _value;
            }
            set { }
        }

        public void ConvertToLongitudeAndLatitude(string valueFromDb)
        {
            if (valueFromDb == null) return;

            if (valueFromDb.Length < 5) return;

            string[] values = valueFromDb.Split(',');
            Longitude = values[0];
            Latitude = values[1];
        }

    }
}
