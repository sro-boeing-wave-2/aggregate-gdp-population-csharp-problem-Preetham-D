using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace AggregateGDPPopulation
{
    public class Class1
    {
        public static void AggregateCalcultion ()
        {
            string[] datafile = File.ReadAllLines("E:\\workspace\\c#\\aggregate-gdp-population-csharp-problem-Preetham-D\\AggregateGDPPopulation\\data\\datafile.csv", Encoding.UTF8);
            string[] mapper = File.ReadAllLines("E:\\workspace\\c#\\aggregate-gdp-population-csharp-problem-Preetham-D\\AggregateGDPPopulation\\data\\cc-mapping.txt", Encoding.UTF8);
            string[] header = (datafile[0].Replace("\"", "")).Split(',');
            string[][] map = new string[mapper.Length][];
            //var dic = mapper.ToDictionary<sKey => sKey.Split(',')[0],;
            //map[0] = mapper[0].Split(',');
            for (int i = 0; i < mapper.Length; i++)
            {
                map[i] = mapper[i].Split(',');
                //dic = map.ToDictionary<country => 
            }
            Dictionary<string, string> countryContinent = new Dictionary<string, string>();
            countryContinent = map.ToDictionary(sr => sr[0], sr => sr[1]);
            //map.ToDictionary();
            //Console.Write(countryContinent["Venezuela"]);
            //Console.Write(header[0]+'\n');
            int cI = Array.IndexOf(header, "Country Name");
            int gdp2012Index = Array.IndexOf(header, "GDP Billions (USD) 2012");
            int population2012Index = Array.IndexOf(header, "Population (Millions) 2012");
            //int cI = header.IndexOf("Country Name");
            //Console.Write(cI);
            //Console.Write(gdp2012Index);
            //Output sol = new Output();
            Dictionary<string, aggregate> output = new Dictionary<string, aggregate>();
            for (int i = 1; i < datafile.Length; i++)
            {
                if (datafile[i].Length > 1)
                {
                    var row = datafile[i].Split(',');
                    string country = row[cI].Replace("\"", "");
                    double population = Convert.ToDouble(row[population2012Index].Replace("\"", ""));
                    double gdp = Convert.ToDouble(row[gdp2012Index].Replace("\"", ""));
                    //Console.Write(countryContinent[country]);
                    aggregate temp = new aggregate();
                    if (country != "European Union")
                    {
                        if (output.ContainsKey(countryContinent[country]))
                        {
                            output[countryContinent[country]].GDP_2012 += gdp;
                            output[countryContinent[country]].POPULATION_2012 += population;
                        }
                        else
                        {
                            temp.GDP_2012 = gdp;
                            temp.POPULATION_2012 = population;
                            output.Add(countryContinent[country], temp);
                        }
                    }
                }
            }
            //Console.Write(output["Africa"].GDP_2012);
            var jsonOut = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText("E:\\workspace\\c#\\aggregate-gdp-population-csharp-problem-Preetham-D\\AggregateGDPPopulation\\data\\output.json", jsonOut);
            //Console.Write(jsonOut);

            //Console.Read();
        }
        public class aggregate
        {
            //public string Continent;
            public double GDP_2012;
            public double POPULATION_2012;
        }
    }
    
}
