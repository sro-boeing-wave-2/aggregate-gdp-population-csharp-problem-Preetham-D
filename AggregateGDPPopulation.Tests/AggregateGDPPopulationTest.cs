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
        public static async void Test1()
        {
            var x = await Class1.Writer();
            //Class1.Writer();
            //var actual = File.ReadAllText(@"../../../../AggregateGDPPopulation/data/output.json");
            var expected = File.ReadAllText(@"../../../expectedOutput.json");
            //Console.WriteLine("Looped");
            JObject actualJson = JObject.Parse(x);
            JObject expectedJson = JObject.Parse(expected);
            Assert.Equal(actualJson, expectedJson);

        }
    }
}
