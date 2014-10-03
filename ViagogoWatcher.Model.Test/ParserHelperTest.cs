using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagoWatcher.Model;

namespace ViagogoWatcher.Model.Test
{
    [TestClass]
    public class ParserHelperTest
    {
        [TestMethod]
        public void GetLowerPrice_Should_Return_Something()
        {
            //arrange
            ParserHelper parserHelper = new ParserHelper();

            //act
            long result = parserHelper.GetLowerPrice("http://www.viagogo.fr/psg/Billets-de-sport/Football/Ligue-1/Paris-Saint-Germain-Billets/E-667356");

            //assert
            Assert.AreEqual(34, result);

        }
    }
}
