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
            Class1.Writer();
            var actual = File.ReadAllText(@"../../../../AggregateGDPPopulation/data/output.json");
            var expected = File.ReadAllText(@"../../../expectedOutput.json");
            JObject actualJson = JObject.Parse(actual);
            JObject expectedJson = JObject.Parse(expected);
            Assert.Equal(actualJson, expectedJson);

        }
    }
}
