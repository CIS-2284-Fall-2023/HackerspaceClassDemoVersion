using Hackerspace.Shared.Models;

namespace Hackerspace.Shared.Tests
{
    [TestClass]
    public class SpeedFeedCalcTests
    {
        [TestMethod]
        public void ChipLoad0017milWith4Flutes1500RPMShouldReturn10pt2()
        {
            var classUnderTest = new SpeedFeedCalc();
            classUnderTest.ChipLoad = 0.0017;
            classUnderTest.RPM = 1500;
            classUnderTest.Flutes = 4;
            double actual = classUnderTest.FeedRate;
            double expected = 10.2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegativeChipLoadShouldThrowException()
        {
            var classUnderTest = new SpeedFeedCalc();

            Assert.ThrowsException<Exception>(() => classUnderTest.ChipLoad = -5);
        }

        

        //[TestMethod]
        //public void ChipLoadCalcShouldNotAllowSetOfChipLoad()
        //{
        //    Assert.ThrowsException<Exception>(SetFeedRate);
        //}

        //private void SetFeedRate()
        //{           
        //    var classUnderTest = new SpeedFeedCalc();
        //    classUnderTest.FeedRate = 1234.5678;
        //}
    }
}