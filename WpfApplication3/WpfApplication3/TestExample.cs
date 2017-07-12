using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;

namespace Okręty
{
    [TestFixture]
    public class TestExample
    {

        [Test]
        public void HelloTest()
        {
            var rect = new Rectangle(2,2,2,2);
            var rect2 = new Rectangle(5, 4, 6, 6);
            

            Assert.IsTrue(Rectangle.Intersect(rect, rect2).IsEmpty);
        }
    }
    
}
