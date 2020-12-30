using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFetcherLogic;
using GameFetcherLogic.Models;
using GameFetcherLogic.SerializationServices;
using Xunit;

namespace GameFetcherLogic.Tests
{
    public class NullList : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class GameDetailsModelToXmlSerializerTests
    {
        [Fact]
        public void CheckIfPathIsValid_ShouldFailIfPathEmpty()
        {
            Assert.Throws<ArgumentException>("path", () => GameDetailsModelToXmlSerializer.CheckIfPathIsValid(""));
        }

        [Theory]
        [InlineData("C:/")]
        [InlineData("C:/Users/Xyz/Documents")]
        [InlineData("E:/Files")]
        public void CheckIfPathIsValid_ShouldPassIfPathValid(string path)
        {
            Assert.True(GameDetailsModelToXmlSerializer.CheckIfPathIsValid(path));
        }

        [Fact]
        public void ConvertModels_ShouldFailIfListsNull()
        {
            List<IGameDetailsModel> source = null;
            List<ExportedGameModel> output = null;
            Assert.Throws<NullReferenceException>(() => GameDetailsModelToXmlSerializer.ConvertModels(source,output));
        }
    }
}
