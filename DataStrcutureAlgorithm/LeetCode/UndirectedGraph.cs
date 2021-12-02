using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    public class UndirectedGraph
    {
        public enum State { VISITED, UNVISITED }

        public class Graph
        {
            public ArrayList nodes { get; } = new ArrayList();
            private Dictionary<int, GraphNode> map = new Dictionary<int, GraphNode>();

            public GraphNode GetOrCreateNode(int val)
            {
                if (!map.ContainsKey(val))
                {
                    GraphNode node = new GraphNode(val);
                    nodes.Add(node);
                    map.Add(val, node);
                }

                return map[val];
            }

            public void addEdge(int startName, int endName)
            {
                GraphNode start = GetOrCreateNode(startName);
                GraphNode end = GetOrCreateNode(endName);
                start.addNeighbour(end);
            }

        }

        public class GraphNode
        {
            public ArrayList neighbours { get; } = new ArrayList();
            private Dictionary<int, GraphNode> map { get; } = new Dictionary<int, GraphNode>();
            public State state { get; set; }
            public int val { get; }

            public GraphNode(int val)
            {
                this.val = val;
                state = State.UNVISITED;
            }

            public void addNeighbour(GraphNode node)
            {
                if (!map.ContainsKey(node.val))
                {
                    neighbours.Add(node);
                    map.Add(node.val, node);
                }
            }

        }
        Graph buildGraph(int[] nodes, int[][] edges)
        {
            Graph graph = new Graph();

            foreach (int node in nodes)
            {
                graph.GetOrCreateNode(node);
            }

            foreach (int[] edge in edges)
            {
                int first = edge[0];
                int second = edge[1];
                graph.addEdge(first, second);
                graph.addEdge(second, first);
            }

            return graph;
        }

        void doBreadthFirstSearch(GraphNode node)
        {
            var neighboursNode = node.neighbours;
            node.state = State.VISITED;

            foreach (GraphNode neighbourNode in neighboursNode)
            {
                if (neighbourNode.state == State.UNVISITED)
                {
                    doBreadthFirstSearch(neighbourNode);
                }
            }

        }

        public int CountComponents(int n, int[][] edges)
        {
            var nodes = new List<int>();

            int singleNodes = 0;
            foreach (int[] edge in edges)
            {
                if (!nodes.Contains(edge[0]))
                {
                    nodes.Add(edge[0]);
                }
                if (!nodes.Contains(edge[1]))
                {
                    nodes.Add(edge[1]);
                }
            }
            singleNodes = n - nodes.Count;

            Graph graph = buildGraph(nodes.ToArray(), edges);

            var all_nodes = graph.nodes;

            int totalPaths = 0;

            foreach (GraphNode node_ingraph in all_nodes)
            {
                if (node_ingraph.state == State.UNVISITED)
                {
                    totalPaths++;
                    doBreadthFirstSearch(node_ingraph);
                }
            }

            return totalPaths + singleNodes;
        }

    }
}
