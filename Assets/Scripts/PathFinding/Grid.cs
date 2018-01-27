using System;
using System.Collections.Generic;

namespace PathFinding
{
    public class Grid
    {
        public readonly Point size;

        private Dictionary<Point, Tile> tileMap = new Dictionary<Point, Tile>();
        private List<Tile> tiles = new List<Tile>();

        public Tile this[Point point]
        {
            get
            {
                Tile tile = null;
                if (tileMap.TryGetValue(point, out tile))
                {
                    return tile;
                }
                return null;
            }

            set
            {
                tileMap[point] = value;
            }
        }

        public Grid(int sizeX, int sizeY) : this(new Point(sizeX, sizeY))
        {
        }

        public Grid(Point size)
        {
            this.size = size;

            for (int j = 0; j < size.Y; j++)
            {
                for (int i = 0; i < size.X; i++)
                {
                    var point = new Point(i, j);
                    var tile = new Tile(point, this);
                    tileMap[point] = tile;
                    tiles.Add(tile);
                }
            }

            foreach (var tile in tiles)
            {
                tile.FindNeighbours(this, true);
            }
        }

        public List<Tile> FindPath(PathFinder pathFinder, Point from, Point to)
        {
            Tile fromTile = null;
            if (!tileMap.TryGetValue(from, out fromTile))
            {
                throw new Exception("WTF!");
            }

            Tile toTile = null;
            if (!tileMap.TryGetValue(to, out toTile))
            {
                throw new Exception("WTF!");
            }

            return pathFinder.FindPath(fromTile, toTile);
        }
    }
}
