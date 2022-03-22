using System;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.Algorithms
{
    public class DisjointSet
    {
        private int[] weights; // Used to store weights of each nodes 
        private int[] parents;

        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);
            // If both a and b have same root, i.e. they both belong to the same set, hence we don't need to take union
            if (rootA == rootB) return;

            // Weighted union
            if (this.weights[rootA] > this.weights[rootB])
            {
                // In case rootA is having more weight
                // 1. Make rootA as the parent of rootB
                // 2. Increment the weight of rootA by rootB's weight
                this.parents[rootB] = rootA;
                this.weights[rootA] += this.weights[rootB];
            }
            else
            {
                // Otherwise
                // 1. Make rootB as the parent of rootA
                // 2. Increment the weight of rootB by rootA's weight
                this.parents[rootA] = rootB;
                this.weights[rootB] += this.weights[rootA];
            }
        }

        public int Find(int a)
        {
            // Traverse all the way to the top (root) going through the parent nodes
            while (a != this.parents[a])
            {
                // Path compression
                // a's grandparent is now a's parent
                this.parents[a] = this.parents[parents[a]];
                a = this.parents[a];
            }
            return a;
        }

        public bool isInSameGroup(int a, int b)
        {
            // Return true if both a and b belong to the same set, otherwise return false
            return Find(a) == Find(b);
        }

        // Initialize weight for each node to be 1
        public DisjointSet(int n)
        {
            this.parents = new int[n + 1];
            this.weights = new int[n + 1];
            // Set the initial parent node to itself
            for (int i = 1; i <= n; ++i)
            {
                this.parents[i] = i;
                this.weights[i] = 1;
            }
        }

    }

    public class KrusKalAlgorithm
    {
        public int minimumCost(int N, int[][] connections)
        {
            DisjointSet disjointset = new DisjointSet(N);
            // Sort connections based on their weights (in increasing order)
            Array.Sort(connections, (a, b) => a[2] - b[2]);
            // Keep track of total edges added in the MST
            int total = 0;
            // Keep track of the total cost of adding all those edges
            int cost = 0;
            for (int i = 0; i < connections.Length; ++i)
            {
                int a = connections[i][0];
                int b = connections[i][1];
                // Do not add the edge from a to b if it is already connected
                if (disjointset.isInSameGroup(a, b)) continue;
                // If a and b are not connected, take union
                disjointset.Union(a, b);
                // increment cost
                cost += connections[i][2];
                // increment number of edges added in the MST
                total++;
            }

            // If all N nodes are connected, the MST will have a total of N - 1 edges
            if (total == N - 1)
            {
                return cost;
            }
            else
            {
                return -1;
            }
        }

        public int MinimumCost2(int N, int[][] connections)
        {
            DisJointSet1 disjointset = new DisJointSet1();

            Array.Sort(connections, (a, b) => a[2] - b[2]);
            int total = 0;
            int cost = 0;

            for (int i = 0; i < connections.Length; ++i)
            {
                disjointset.MakeSet(connections[i][0]);
                disjointset.MakeSet(connections[i][1]);
            }

            for (int i = 0; i < connections.Length; ++i)
            {
                if (disjointset.FindSet(connections[i][0]) == disjointset.FindSet(connections[i][1]))
                {
                    continue;
                }
                disjointset.Union(connections[i][0], connections[i][1]);
                cost += connections[i][2];
                total++;
            }

            if (total == N - 1)
            {
                return cost;
            }
            else
            {
                return -1;
            }
        }
    }

    public class DisJointSet1
    {
        public class Node
        {
            public int Data { get; set; }
            public int Rank { get; set; }
            public Node Parent { get; set; }

        }

        private Dictionary<int, Node> map = new Dictionary<int, Node>();

        public void MakeSet(int data)
        {
            if (!map.ContainsKey(data))
            {
                Node node = new Node()
                {
                    Data = data,
                    Rank = 0
                };
                node.Parent = node;
                map.Add(data, node);
            }
        }

        public void Union(int data1, int data2)
        {
            Node node1 = map[data1];
            Node node2 = map[data2];
            Node parent1 = FindSet(node1);
            Node parent2 = FindSet(node2);

            if (parent1.Data == parent2.Data)
            {
                return;
            }

            if (parent1.Rank >= parent2.Data)
            {
                parent1.Rank = (parent1.Rank == parent2.Rank) ?
                    parent1.Rank + 1 : parent1.Rank;
                parent2.Parent = parent2;
            }
            else
            {
                parent1.Parent = parent2;
            }

        }

        public int FindSet(int data)
        {
            return FindSet(map[data]).Data;
        }

        public Node FindSet(Node node)
        {
            Node parent = node.Parent;
           
            if (parent == node)
            {
                return parent;
            }
            node.Parent = FindSet(node.Parent);

            return node.Parent;
        }
    }
}
