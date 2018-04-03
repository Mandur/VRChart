using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class DataSource
    {
        public List<DataPointModel> dataSet2;
        public List<KeyValuePair<string, string>> dataSetCategories;

        public DataSource()
        {
            dataSet2 = new List<DataPointModel>();
            dataSetCategories = new List<KeyValuePair<string, string>>();


            var rndSet = new System.Random(DateTime.Now.Millisecond);
            var i = 0;
            while (i < rndSet.Next(10, 20))
            {
                var rndBar = new System.Random(rndSet.Next());
                var vals = new List<double>();
                var cat = string.Format("Category {0}", i);
                for (var b = 0; b <= 11; b++)
                {
                    var val = rndBar.NextDouble() * (50 - 2) + 2;
                    vals.Add(val);
                    dataSet2.Add(new DataPointModel(cat, val));
                }
                i++;
            }
            //---Get distinct category keys
            dataSetCategories = dataSet2.GroupBy(p => p.key).Select(p => new KeyValuePair<string,string>(p.First().key, p.First().name)).ToList();
        }

    }

    


    public class DataPointModel
    {
        private string _name = "";

        public DataPointModel() { }

        public DataPointModel(string  name, double value)
        {
            this.name = name;
            this.value = value;
        }
        
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = (value == null) ? "" : value.Trim();
                key = _name.ToLower();
            }
        }

        public double value { get; set; }
        public string key{get;private set;}
    }
}
