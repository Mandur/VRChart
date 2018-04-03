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
        
        }

        public void generateMockDataSource(double min, double max)
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
                    ///---only for demostration that the number generated will be between 2 and 
                    var val = rndBar.NextDouble() * (max - min) + min;
                    vals.Add(val);
                    dataSet2.Add(new DataPointModel(cat, val));
                }
                i++;
            }
            var maxOrig = dataSet2.Max(p => p.value);
            var minOrig = dataSet2.Min(p => p.value);
            for (var t = 0; t < dataSet2.Count; t++)
            {
                this.dataSet2[t].value = this.normalizeValue(this.dataSet2[t].value, 0, 1, minOrig, maxOrig);
            }

            //---Get distinct category keys
            dataSetCategories = dataSet2.GroupBy(p => p.key).Select(p => new KeyValuePair<string, string>(p.First().key, p.First().name)).ToList();
        }
        

        private double normalizeValue(double val, double maxNewRange, double minNewRange, double minOriginalRange, double maxOriginalRange)
        {
            var newValue = minNewRange + (((maxNewRange - minNewRange) * (val - minOriginalRange)) / (maxOriginalRange - minOriginalRange));
            return newValue;
        }

    }

    


    public class DataPointModel
    {
        private string _name = "";
        private double _value = 0;

        public DataPointModel() { }

        public DataPointModel(string  name, double value)
        {
            this.name = name;
            this.originalValue = value;
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

        public double value {
            get {
                return this._value;
            } set
            {
                this._value = value;
            }
        }

        public double originalValue { get; set; }

        public string key{get;private set;}
    }
}
