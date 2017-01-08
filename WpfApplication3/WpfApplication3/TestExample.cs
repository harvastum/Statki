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
            var rect = new Rectangle(4,4,3,1);
            var rect2 = new Rectangle(7, 2, 1, 2);

            var result = Rectangle.Intersect(rect, rect2);
        }
    }
    
}
