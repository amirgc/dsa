using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStrcutureAlgorithm.Algorithms
{
    public class Dijkstra
    {
        int[] parent;
        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        private void PrintParent(int n)
        {
            while (n != 0)
            {
                Console.WriteLine(parent[n]+"<------'");
                n = parent[n];
            }
        }

        public void DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            parent = new int[verticesCount];

            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
                parent[i] = i;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v])
                        && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                        parent[v] = u;
                    }
                }
            }

            Print(distance, verticesCount);
            PrintParent(3);
        }
    }

    public class DijkstraGraph
    {
        public DijkstraGraph()
        {
            nodes.Reverse();
            nodes.Add(new Node() { Name = "A", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "B", 6 }, { "H", 9 } } });
            nodes.Add(new Node() { Name = "B", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "C", 9 }, { "H", 11 }, { "A", 6 } } });
            nodes.Add(new Node() { Name = "C", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "B", 9 }, { "F", 6 }, { "D", 5 }, { "I", 2 } } });
            nodes.Add(new Node() { Name = "D", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "C", 5 }, { "F", 16 }, { "E", 9 } } });
            nodes.Add(new Node() { Name = "E", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "F", 10 }, { "D", 9 } } });
            nodes.Add(new Node() { Name = "F", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "C", 6 }, { "D", 16 }, { "E", 10 }, { "G", 2 } } });
            nodes.Add(new Node() { Name = "G", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "F", 2 }, { "I", 6 }, { "H", 1 } } });
            nodes.Add(new Node() { Name = "H", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "I", 5 }, { "B", 11 }, { "A", 9 }, { "G", 1 } } });
            nodes.Add(new Node() { Name = "I", AdjacentsNodesPathMaping = new Dictionary<string, int>() { { "H", 5 }, { "C", 2 }, { "G", 6 } } });
        }

        internal class Node
        {
            public string Name { get; set; }
            public string Predecessor { get; set; }
            public int MinDistance { get; set; } = int.MaxValue;
            public bool IsLocked { get; set; }
            public Dictionary<string, int> AdjacentsNodesPathMaping { get; set; }
        }

        List<Node> nodes = new List<Node>();

        public void FindMinimumDistancePathBetweenNode()
        {
            var node = nodes.FirstOrDefault();
            node.MinDistance = 0;
            while (nodes.Any(x => !x.IsLocked))
            {
                foreach (var items in node.AdjacentsNodesPathMaping)
                {
                    var adjNode = nodes.Find(x => x.Name == items.Key);
                    if (adjNode.MinDistance > node.MinDistance + items.Value && !adjNode.IsLocked)
                    {
                        adjNode.MinDistance = node.MinDistance + items.Value;
                        adjNode.Predecessor = node.Name;
                    }
                }

                node.IsLocked = true;
                node = nodes.OrderBy(x => x.MinDistance).FirstOrDefault(x => x.IsLocked == false);
            }

            nodes.ForEach(x => { Console.WriteLine($"Node Name:{x.Name}, Min Path from source: {x.MinDistance} : Predecessor {x.Predecessor}"); });
        }

    }
}
