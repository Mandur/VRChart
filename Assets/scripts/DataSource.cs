using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class DataSource
    {
        public Dictionary<string, List<double>> dataSet;
        public DataSource()
        {
            dataSet = new Dictionary<string, List<double>>();
            var rndSet = new System.Random(DateTime.Now.Millisecond);
            var i = 0;
            while (i < rndSet.Next(5, 10))
            {
                var rndBar = new System.Random(DateTime.Now.Millisecond);
                var vals = new List<double>();
                for (var b = 0; b <= 11; b++)
                {
                    vals.Add(rndBar.NextDouble() * (150 - 2) + 2);
                }
                dataSet.Add(string.Format("category {0}", i), vals);
                i++;
            }
        }
    }
    class Category
    {
        public String name
        {
            get;set;
        }

    }
}
