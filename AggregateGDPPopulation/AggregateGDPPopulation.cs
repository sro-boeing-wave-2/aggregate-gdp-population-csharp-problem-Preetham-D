using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AggregateGDPPopulation
{
    public class Class1
    {
        public static async Task<string[]> Reader(string filepath)
        {
            return (await File.ReadAllLinesAsync(filepath, Encoding.UTF8));
            //string h = StreamReader(filepath);
            //StreamReader  data = new StreamReader(filepath);
            //string s = await data.ReadToEndAsync();
            
            //string[] data2 = s.Split('\n');
            //return (data2);
        }
        public static async Task<Dictionary<string, aggregate>> Operations()
        {
            string[] datafile = await Reader(@"../../../../AggregateGDPPopulation/data/datafile.csv");
            string[] mapper = await Reader(@"../../../../AggregateGDPPopulation/data/cc-mapping.txt");
            //string[][] temp1 = await Task<string[]>.WhenAll(Reader(@"../../../../AggregateGDPPopulation/data/datafile.csv"), Reader(@"../../../../AggregateGDPPopulation/data/cc-mapping.txt"));
            //string[] datafile = temp1[0];
            //string[] mapper = temp1[1];
            string[] header = (datafile[0].Replace("\"", "")).Split(',');
            string[][] map = new string[mapper.Length - 1][];
            Console.WriteLine(mapper.Length);
            //Console.Write(map[0][0]);
                for (int i = 0; i < mapper.Length -1; i++)
                {
                    map[i] = mapper[i].Split(',');
                //Console.WriteLine("new item added - " + mapper[i]);
                }

            //Console.WriteLine(count);
            Dictionary<string, string> countryContinent = new Dictionary<string, string>();
            countryContinent = map.ToDictionary(sr => sr[0], sr => sr[1]);
            //foreach (string[] a in map)
            //{
            //   countryContinent.Add(a[0], a[1]);
            //}
            int cI = Array.IndexOf(header, "Country Name");
            int gdp2012Index = Array.IndexOf(header, "GDP Billions (USD) 2012");
            int population2012Index = Array.IndexOf(header, "Population (Millions) 2012");
            Dictionary<string, aggregate> output = new Dictionary<string, aggregate>();
            for (int i = 1; i < datafile.Length; i++)
            {
                if (datafile[i].Length > 1)
                {
                    var row = datafile[i].Split(',');
                    string country = row[cI].Replace("\"", "");
                    double population = Convert.ToDouble(row[population2012Index].Replace("\"", ""));
                    double gdp = Convert.ToDouble(row[gdp2012Index].Replace("\"", ""));
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
            return output;
        }
        public static async Task<string> Writer()
        {
            Dictionary<string, aggregate> output1 = await Operations();
            string jsonOut = JsonConvert.SerializeObject(output1);
            //string u = jsonOut.ToCharArray().ToString();
            //string out = jsonOut.Join();
            await File.WriteAllLinesAsync(@"..\..\..\..\AggregateGDPPopulation\data\output.json",jsonOut.Split(","));
            return jsonOut;
        }
        public class aggregate
        {
            public double GDP_2012;
            public double POPULATION_2012;
        }
    }
}
