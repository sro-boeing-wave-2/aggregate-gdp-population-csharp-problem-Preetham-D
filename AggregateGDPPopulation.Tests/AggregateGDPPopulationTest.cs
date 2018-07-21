using System;
using Xunit;
using AggregateGDPPopulation;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AggregateGDPPopulation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Class1.AggregateCalcultion();
            var actual = File.ReadAllText(@"E:\workspace\c#\aggregate-gdp-population-csharp-problem-Preetham-D\AggregateGDPPopulation\data\output.json");
            var expected = File.ReadAllText(@"E:\workspace\c#\aggregate-gdp-population-csharp-problem-Preetham-D\AggregateGDPPopulation.Tests\expectedOutput.json");
            JObject actualJson = JObject.Parse(actual);
            JObject expectedJson = JObject.Parse(expected);
            Assert.Equal(actualJson, expectedJson);
            //Dictionary<string, Class1.aggregate> pokade = new Dictionary<string, Class1.aggregate>();
            //Dictionary<string, Class1.aggregate> actualDIctionary =  new Dictionary<string, Class1.aggregate>();
            //Dictionary<string, Class1.aggregate> expectedDIctionary = new Dictionary<string, Class1.aggregate>();
            //actualDIctionary = JsonConvert.DeserializeObject<Dictionary<string, Class1.aggregate>>(actual);
            //expectedDIctionary = JsonConvert.DeserializeObject<Dictionary<string, Class1.aggregate> > (expected);
            //bool equal = actualDIctionary.Keys.Count == expectedDIctionary.Keys.Count && actualDIctionary.ContainsValue
            //for (int i=0; i < actualDIctionary.Count; i++)
            //{
            //    if()
            //}

        }
    }
}
