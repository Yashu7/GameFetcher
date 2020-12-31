using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GameFetcherLogic;
using GameFetcherLogic.Helpers;

namespace GameFetcherLogic.Tests
{
    public class EpochToDateConverterTests
    {
        [Theory]
        [InlineData(1609408646)]
        public void ConvertTime_ShouldReturnCorrectTime(long time)
        {
            string expected = "31.12.2020";
            string actual = EpochToDateConverter.ConvertTime(time);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1222323234)]
        public void ConvertTime_ShouldReturnCorrectTime_2(long time)
        {
            string expected = "25.09.2008";
            string actual = EpochToDateConverter.ConvertTime(time);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(543345345)]
        public void ConvertTime_ShouldReturnFailIfWrongTime(long time)
        {
            string notExpected = "21.03.2000";
            string actual = EpochToDateConverter.ConvertTime(time);
            Assert.NotEqual(notExpected, actual);
        }
    }
}
