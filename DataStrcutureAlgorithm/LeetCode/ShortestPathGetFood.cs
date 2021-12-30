using System;
using System.Collections.Generic;


namespace DataStrcutureAlgorithm.LeetCode
{
    public class ShortestPathGetFood
    {
        public class Pair
        {
            public Pair(int x, int y, int l)
            {
                this.x = x;
                this.y = y;
                this.level = l;
            }
            public int x { get; set; }
            public int y { get; set; }
            public int level { get; set; }
        }

        public int GetFood(char[][] grid)
        {
            var res = -1;
            var queue = new Queue<Pair>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        queue.Enqueue(new Pair(i, j, 0));
                        res = shortestPath(grid, queue);
                        break;
                    }
                }
            }

            return res == int.MaxValue ? -1 : res;
        }

        private int shortestPath(char[][] grid, Queue<Pair> queue)
        {
            if (queue.Count == 0) return int.MaxValue;

            var cord = queue.Dequeue();

            if (grid[cord.x][cord.y] == '#')
                return cord.level;
            grid[cord.x][cord.y] = 'X';

            var paths = GetOtherPaths(grid, cord.x, cord.y);

            foreach (var path in paths)
            {
                if (grid[path[0]][path[1]] != 'X')
                {
                    if (grid[path[0]][path[1]] == 'O')
                        grid[path[0]][path[1]] = 'X';

                    queue.Enqueue(new Pair(path[0], path[1], cord.level + 1));
                }
            }

            return shortestPath(grid, queue);
        }

        private List<int[]> GetOtherPaths(char[][] grid, int x, int y)
        {
            int row = grid.Length; int col = grid[0].Length;
            var paths = new List<int[]>();
            if (isValidCordinate(grid, x, y + 1, row, col)) paths.Add(new int[] { x, y + 1 });
            if (isValidCordinate(grid, x, y - 1, row, col)) paths.Add(new int[] { x, y - 1 });
            if (isValidCordinate(grid, x + 1, y, row, col)) paths.Add(new int[] { x + 1, y });
            if (isValidCordinate(grid, x - 1, y, row, col)) paths.Add(new int[] { x - 1, y });
            return paths;
        }

        private bool isValidCordinate(char[][] grid, int x, int y, int row, int col)
        {
            if (x < 0 || y < 0 || x >= row || y >= col || grid[x][y] == 'X')
                return false;

            return true;
        }
    }
}
