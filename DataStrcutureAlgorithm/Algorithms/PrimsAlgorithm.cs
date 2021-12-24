using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.Algorithms
{
    public class Vertex
    {
        public int Status { get; set; }
        public int predecessor { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
    }

    public class UnDirectedWeightedGraph
    {
        public readonly int MAX_VERTICES = 30;

        int n;
        int e;
        int[,] adj;
        Vertex[] vertexList;
        private readonly int TEMPORARY = 1;
        private readonly int PERMANENT = 2;
        private readonly int NIL = int.MinValue;
        private readonly int INFINITY = int.MaxValue;

        public UnDirectedWeightedGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        public void Prims()
        {
            int current, v;
            int edgesInTree = 0;
            int wtTree = 0;
            for (v = 0; v < n; v++)
            {
                vertexList[v].Status = TEMPORARY;
                vertexList[v].Length = INFINITY;
                vertexList[v].predecessor = NIL;
            }

            int root = 0;
            vertexList[root].Length = 0;
            while (true)
            {
                current = TempVertexMinL(); //Gives temporary adjacent min vertex;

                if (current == NIL)
                {
                    if (edgesInTree == n - 1)
                    {
                        Console.WriteLine($"Weight of minimum spaning tree is {wtTree}");
                        printMinSpaningTreeEdges();
                        return;
                    }
                    else
                    {
                        throw new InvalidOperationException("Graph is not connected");
                    }
                }

                vertexList[current].Status = PERMANENT;

                if (current != root)
                {
                    edgesInTree++;
                    wtTree += adj[vertexList[current].predecessor, current];
                }

                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(current, v) && vertexList[v].Status == TEMPORARY)
                    {
                        if (adj[current, v] < vertexList[v].Length)
                        {
                            vertexList[v].Length = adj[current, v];
                            vertexList[v].predecessor = current;
                        }
                    }
                }
            }
        }

        public void InsertVertex(string str)
        {
            vertexList[n] = new Vertex() { Name = str };
            n++;
        }

        public void printMinSpaningTreeEdges()
        {
            for (int i = 0; i < n; i++)
            {
                if (vertexList[i].predecessor < n && vertexList[i].predecessor >= 0)
                    Console.WriteLine($"For node {vertexList[i].Name } predecessor" +
                        $" is { vertexList[vertexList[i].predecessor].Name}");
            }
        }

        public void InsertEdge(string v1Name, string v2Name, int length)
        {
            int v1Index = 0;
            int v2Index = 0;

            for (int i = 0; i < n; i++)
            {
                if (vertexList[i].Name.Equals(v1Name))
                {
                    v1Index = i;
                }

                if (vertexList[i].Name.Equals(v2Name))
                {
                    v2Index = i;
                }
            }

            adj[v1Index, v2Index] = length;
            adj[v2Index, v1Index] = length;

            e++;

        }

        private bool IsAdjacent(int u, int v)
        {
            return (adj[u, v] != 0);
        }

        private int TempVertexMinL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].Status == TEMPORARY && vertexList[v].Length < min)
                {
                    min = vertexList[v].Length;
                    x = v;
                }
            }

            return x;
        }

    }

}
