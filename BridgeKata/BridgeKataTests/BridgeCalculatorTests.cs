using System;
using System.Diagnostics;
using BridgeKata;
using NUnit.Framework;
using Rhino.Mocks;

namespace BridgeKataTests
{
    [TestFixture]
    public class BridgeCalculatorTests
    {

        [Test]
        public void Valid_Constructor_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() => new BridgeCalculator(MockRepository.GenerateMock<IFileHandler>()));
        }

        [Test]
        public void Fails_When_No_File()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(false);
            const string fileName = "Bridge_Hand.txt";
            Assert.Throws<ArgumentException>(() => bridgeCalculator.readHand(fileName));
        }

        [Test]
        public void ReadHand_Returns_FileFormatException_When_File_Exists_And_IsEmpty()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[]{});
            const string fileName = "Bridge_Hand.txt";
            Assert.Throws<FileFormatException>(() => bridgeCalculator.readHand(fileName));
        }

        [Test]
        public void A_File_With_No_Points_Returns_Zero()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[]{"????","???","???", "???"});
            const string fileName = "Bridge_Hand.txt";
            bridgeCalculator.readHand(fileName);
            Assert.AreEqual(bridgeCalculator.Points, 0);
        }

        [Test]
        public void A_New_File_Cannot_Replace_An_Old()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            const string fileName = "Bridge_Hand.txt";
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[] { "????", "???", "???", "???" });
            bridgeCalculator.readHand(fileName);
            Assert.Throws<ArgumentException>(() => bridgeCalculator.readHand(fileName + "somethingelse"));
        }

        [Test]
        public void A_File_With_One_Point_Returns_One()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[] { "J???", "???", "???", "???" });
            const string fileName = "Bridge_Hand.txt";
            bridgeCalculator.readHand(fileName);
            Assert.AreEqual(bridgeCalculator.Points, 1);
        }

        [Test]
        public void A_File_With_Two_Point_Returns_Two()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[] {"J???", "J??", "???", "???"});
            const string fileName = "Bridge_Hand.txt";
            bridgeCalculator.readHand(fileName);
            Assert.AreEqual(bridgeCalculator.Points, 2);
        }

        [Test]
        public void A_File_With_Two_Point_Returns_Two_PartTwo()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new string[] { "Q???", "???", "???", "???" });
            const string fileName = "Bridge_Hand.txt";
            bridgeCalculator.readHand(fileName);
            Assert.AreEqual(bridgeCalculator.Points, 2);
        }

        [Test]
        public void A_File_With_four_Points_in_one_suit_returns_four_points()
        {
            var fileMock = MockRepository.GenerateMock<IFileHandler>();
            var bridgeCalculator = new BridgeCalculator(fileMock);
            fileMock.Stub(me => me.Exists(Arg<string>.Is.Anything)).Return(true);
            fileMock.Stub(me => me.ReadAllLines(Arg<string>.Is.Anything)).Return(new[] { "QJJ?", "???", "???", "???" });
            const string fileName = "Bridge_Hand.txt";
            bridgeCalculator.readHand(fileName);
            Assert.AreEqual(4, bridgeCalculator.Points);
        }
    }


}
