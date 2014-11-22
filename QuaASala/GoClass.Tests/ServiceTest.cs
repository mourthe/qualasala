using System.Collections.Generic;
using NUnit.Framework;

namespace GoClass.Tests
{
    [TestFixture]
    public class ServiceTest
    {
        [Test]
        public void Test()
        {
            // arrange
            IList<string> rooms = null;

            // act
            rooms = GoClassService.GetRooms("9", "seg");

            // assert
            Assert.That(rooms, Is.Not.Null);            
        }
    }
}
