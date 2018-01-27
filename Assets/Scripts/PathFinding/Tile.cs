using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinding
{
    public class Tile
    {
        public static List<Point> NeighbourShift
        {
            get
            {
                return new List<Point>
                {
                    new Point(0, 1),
                    new Point(1, 0),
                    new Point(0, -1),
                    new Point(-1, 0),
                };
            }
        }

        public bool Passable;
        public readonly Point point;
        public readonly Grid grid;

        private IEnumerable<Tile> AllNeighbours { get; set; }
        public IEnumerable<Tile> Neighbours
        {
            get { return AllNeighbours.Where(o => o.Passable); }
        }

        public Tile(Point point, Grid grid)
        {
            this.point = point;
            this.Passable = true;
            this.grid = grid;
        }

        public void FindNeighbours(Grid grid, bool EqualLineLengths)
        {
            List<Tile> neighbours = new List<Tile>();

            foreach (Point neighbour in NeighbourShift)
            {
                int neighbourX = this.point.X + neighbour.X;
                int neighbourY = this.point.Y + neighbour.Y;

                if (neighbourX < 0 || 
                    neighbourY < 0 || 
                    neighbourX >= grid.size.X || 
                    neighbourY >= grid.size.Y)
                {
                    continue;
                }

                var p = new Point(neighbourX, neighbourY);
                var tile = grid[p];
                if (tile != null)
                {
                    neighbours.Add(tile);
                }
                else
                {
                    UnityEngine.Debug.LogError("WTF! " + p);
                }
            }

            AllNeighbours = neighbours;
        }

        public override string ToString()
        {
            return string.Format("[Tile {0}]", this.point.ToString());
        }
    }
}
