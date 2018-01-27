using System;
using System.Collections.Generic;

namespace PathFinding
{
    public class PathFinder
    {
        PriorityQueue<double, Tile> frontier = new PriorityQueue<double, Tile>();
        Dictionary<Point, double> costSoFar = new Dictionary<Point, double>();
        Dictionary<Point, Tile> cameFrom = new Dictionary<Point, Tile>();

        public List<Tile> FindPath(Tile from, Tile to)
        {
            frontier.Clear();
            costSoFar.Clear();
            cameFrom.Clear();

            frontier.Enqueue(0, from);
            costSoFar[from.point] = 0;

            while (!frontier.IsEmpty)
            {
                var current = frontier.Dequeue();

                if (Goal(current, from, to))
                {
                    return GeneratePath(current, cameFrom);
                }

                foreach (var next in current.Neighbours)
                {
                    var new_cost = costSoFar[current.point] + Cost(current, next);

                    double old_cost;
                    if (!costSoFar.TryGetValue(next.point, out old_cost) || 
                        new_cost < old_cost)
                    {
                        costSoFar[next.point] = new_cost;
                        var priority = new_cost + Heuristic(to, next);
                        frontier.Enqueue(priority, next);
                        cameFrom[next.point] = current;
                    }
                }
            }

            return null;
        }

        private static List<Tile> GeneratePath(Tile current, Dictionary<Point, Tile> cameFrom)
        {
            var list = new List<Tile>();
            var previous = current;

            do
            {
                list.Add(previous);
                cameFrom.TryGetValue(previous.point, out previous);
            }
            while (previous != null);

            list.Reverse();

            return list;
        }

        private static bool Goal(Tile current, Tile from, Tile to)
        {
            return current == to;
        }

        private static float Cost(Tile current, Tile b)
        {
            return 1;
        }

        private static double Heuristic(Tile a, Tile b)
        {
            var dx = a.point.X - b.point.X;
            var dy = a.point.Y - b.point.Y;
            return dx * dx + dy * dy;
        }
    }
}