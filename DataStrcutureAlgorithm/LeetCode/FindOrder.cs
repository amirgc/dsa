using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStrcutureAlgorithm.LeetCode
{
    /*There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] 
     indicates that you must take course bi first if you want to take course ai.
     For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
     Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them.If it is impossible to 
     finish all courses, return an empty array.
    */
    public class FindOrderSolution
    {
        public enum State { COMPLETE, PARTIAL, BLANK }
        public class Graph
        {
            private ArrayList nodes = new ArrayList();
            private Dictionary<int, Course> map = new Dictionary<int, Course>();

            public Course GetOrCreateNode(int courseId)
            {
                if (!map.ContainsKey(courseId))
                {
                    Course node = new Course(courseId);
                    nodes.Add(node);
                    map.Add(courseId, node);
                }

                return map[courseId];
            }

            public void addEdge(int startName, int endName)
            {
                Course start = GetOrCreateNode(startName);
                Course end = GetOrCreateNode(endName);
                start.addNeighbour(end);
            }

            public ArrayList getNodes() { return nodes; }
        }
        public class Course
        {
            private ArrayList children = new ArrayList();
            private Dictionary<int, Course> map = new Dictionary<int, Course>();
            private int prerequisites = 0;
            public State state { get; set; }
            public int CourseId { get; }
            public Course(int name)
            {
                CourseId = name;
                this.state = State.BLANK;
            }

            public void addNeighbour(Course node)
            {
                if (!map.ContainsKey(node.CourseId))
                {
                    children.Add(node);
                    map.Add(node.CourseId, node);
                    node.incrementDependencies();
                }
            }

            public void incrementDependencies() { prerequisites++; }
            public void decrementDependencies() { prerequisites--; }
            public ArrayList getChildren() { return children; }
            public int getNumberDependencies() { return prerequisites; }
        }
        Graph buildGraph(int[] courses, int[][] prerequisites)
        {
            Graph graph = new Graph();

            foreach (int course in courses)
            {
                graph.GetOrCreateNode(course);
            }

            foreach (int[] prerequisite in prerequisites)
            {
                int first = prerequisite[0];
                int second = prerequisite[1];
                graph.addEdge(first, second);
            }

            return graph;
        }

        Stack<Course> findBuildOrder(int[] courses, int[][] prerequisites)
        {
            Graph graph = buildGraph(courses, prerequisites);
            return orderProjects(graph.getNodes());
        }

        Stack<Course> orderProjects(ArrayList courses)
        {
            Stack<Course> stack = new Stack<Course>();
            foreach (Course course in courses)
            {
                if (course.state == State.BLANK)
                {
                    if (!doDFS(course, stack))
                    {
                        return null;
                    }
                }
            }

            return stack;
        }

        bool doDFS(Course course, Stack<Course> stack)
        {
            if (course.state == State.PARTIAL)
                return false;

            if (course.state == State.BLANK)
            {
                course.state = State.PARTIAL;
                ArrayList children = course.getChildren();
                foreach (Course child in children)
                {
                    if (!doDFS(child, stack))
                    {
                        return false;
                    }
                }
                course.state = State.COMPLETE;
                stack.Push(course);
            }

            return true;

        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var courses = new List<int>();
            var res = new int[numCourses];
            foreach (int[] prerequisite in prerequisites)
            {
                if (!courses.Contains(prerequisite[0]))
                {
                    courses.Add(prerequisite[0]);
                }
                if (!courses.Contains(prerequisite[1]))
                {
                    courses.Add(prerequisite[1]);
                }
            }

            var stack = findBuildOrder(courses.ToArray(), prerequisites);

            int counter = numCourses - 1;

            while (stack != null && stack.Count != 0)
            {
                res[counter] = stack.Pop().CourseId;
                counter--;
            }

            return res;
        }

    }
}
