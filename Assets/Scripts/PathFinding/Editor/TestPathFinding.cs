using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace PathFinding
{
    public class TestPathFinding
    {
        [Test]
        public void PathFindingSimplePasses()
        {
            var grid = new Grid(10, 10);
            var pathFinder = new PathFinder();

            var start = new Point(1, 1);
            var end = new Point(4, 4);
            var path = grid.FindPath(pathFinder, start, end);

            Assert.AreEqual(start, path.First());
            Assert.AreEqual(end, path.Last());
        }
    }
}
