using System;
using System.Collections.Generic;
using System.Linq;

namespace ARGraph
{
    /// <summary>
    /// This class is a generic template class that serves as the node of a graph
    /// </summary>
    /// <typeparam name="T">data type of the node</typeparam>
    public class CSC382Graph_Vertex<T>
    {
        /// <summary>
        /// data to hold in the node
        /// </summary>
        private T data;

        /// <summary>
        /// list of connected nodes
        /// </summary>
        public LinkedList<CSC382Graph_Vertex<T>> Connected_vertices { get; private set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public CSC382Graph_Vertex()
        {
            Connected_vertices = new LinkedList<CSC382Graph_Vertex<T>>();
            data = default;
        }

        /// <summary>
        /// secondary constructor building node with provided data
        /// </summary>
        /// <param name="node_data">data to hold in node</param>
        public CSC382Graph_Vertex(T node_data)
        {
            Connected_vertices = new LinkedList<CSC382Graph_Vertex<T>>();
            data = node_data;
        }

        /// <summary>
        /// connects node to the provided node
        /// </summary>
        /// <param name="vertex_connection">node to be adjacent to the calling node</param>
        public void AddEdge(CSC382Graph_Vertex<T> vertex_connection)
        {
            if (vertex_connection != this)
            {
                Connected_vertices.AddLast(vertex_connection);
            }
        }

        /// <summary>
        /// checks to see if provided node is connected to the calling node
        /// </summary>
        /// <param name="vertex_to_find">node to search for</param>
        /// <returns></returns>
        public bool VertexConnected(CSC382Graph_Vertex<T> vertex_to_find)
        {
            foreach (CSC382Graph_Vertex<T> i in Connected_vertices)
            {
                if (i == vertex_to_find)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// removes an edge from a connected node
        /// </summary>
        /// <param name="edge_to_remove">edge to remove</param>
        public void RemoveEdge(CSC382Graph_Vertex<T> edge_to_remove)
        {
            if (edge_to_remove != default)
            {
                Connected_vertices.Remove(edge_to_remove);
            }
        }

        /// <summary>
        /// returns the data that is being held in the current vertex
        /// </summary>
        /// <returns>node data</returns>
        public T GetData()
        {
            return data;
        }

        /// <summary>
        /// set the data that will be held in the current vertex
        /// </summary>
        /// <param name="data_param">node data</param>
        public void SetData(T data_param)
        {
            data = data_param;
        }

    };


    /// <summary>
    /// This class represents a graph as a list of the CSC382Graph_Vertex nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSC382Graph_NodeBased<T>
    {
        /// <summary>
        /// graph of nodes
        /// </summary>
        public LinkedList<CSC382Graph_Vertex<T>> Graph { get; private set; }

        /// <summary>
        /// default constructor that makes an empty graph
        /// </summary>
        public CSC382Graph_NodeBased()
        {
            Graph = new LinkedList<CSC382Graph_Vertex<T>>();
        }

        /// <summary>
        ///  secondary constructor that makes a new graph with an initial vertex node
        /// </summary>
        /// <param name="initial_vertex">the vertex you want to use at the initial vertex of graph</param>
        public CSC382Graph_NodeBased(CSC382Graph_Vertex<T> initial_vertex)
        {
            Graph = new LinkedList<CSC382Graph_Vertex<T>>();
            Insert(initial_vertex);
        }

        /// <summary>
        /// inserts a new vertex onto the graph
        /// </summary>
        /// <param name="vertex">vertex node to be added</param>
        /// <returns></returns>
        public CSC382Graph_Vertex<T> Insert(CSC382Graph_Vertex<T> vertex)
        {
            Graph.AddLast(vertex);
            return vertex;
        }

        /// <summary>
        /// inserta a new vertex node into the graph with specified data
        /// </summary>
        /// <param name="data">information to be stored in the vertex node</param>
        /// <returns></returns>
        public CSC382Graph_Vertex<T> Insert(T data)
        {
            CSC382Graph_Vertex<T> new_node = new CSC382Graph_Vertex<T>(data);
            return Insert(new_node);
        }

        /// <summary>
        /// remove vertex node that holds the specified data
        /// </summary>
        /// <param name="data">data that is being held in vertex to be removed</param>
        public void RemoveVertex(T data)
        {
            CSC382Graph_Vertex<T> vertex_to_remove = FindVertex(data);
            RemoveVertex(vertex_to_remove);
        }

        /// <summary>
        /// remove vertex node that is specified
        /// </summary>
        /// <param name="vertex_to_remove">vertex node that is to be removed from graph</param>
        public void RemoveVertex(CSC382Graph_Vertex<T> vertex_to_remove)
        {
            Graph.Remove(vertex_to_remove);
        }

        /// <summary>
        /// add an edge to the graph between the two vertex nodes specified
        /// </summary>
        /// <param name="start_vertex">vertex node to start the edge at</param>
        /// <param name="end_vertex">vertex node to end the edge at/param>
        public void AddEdge(CSC382Graph_Vertex<T> start_vertex, CSC382Graph_Vertex<T> end_vertex)
        {
            start_vertex.AddEdge(end_vertex);
        }

        /// <summary>
        /// remove an edge that is between the two vertex nodes specified
        /// </summary>
        /// <param name="start_vertex">starting vertex node that the edge is connected to</param>
        /// <param name="end_vertex">ending vertex node that the edge is connected to</param>
        public void RemoveEdge(CSC382Graph_Vertex<T> start_vertex, CSC382Graph_Vertex<T> end_vertex)
        {
            start_vertex.RemoveEdge(end_vertex);
        }

        /// <summary>
        /// searches the vertex node to see if the specified edge is connected to it
        /// </summary>
        /// <param name="vertex_to_search_in">vertex node to check connected nodes</param>
        /// <param name="edge_to_check_for">vertex node to look for</param>
        /// <returns></returns>
        public bool IsEdge(CSC382Graph_Vertex<T> vertex_to_search_in, CSC382Graph_Vertex<T> edge_to_check_for)
        {
            return vertex_to_search_in.VertexConnected(edge_to_check_for);
        }

        /// <summary>
        /// searches the graph for vertex node with specified data
        /// </summary>
        /// <param name="data_to_find">info that you are looking for to be stored in the graph</param>
        /// <returns></returns>
        public CSC382Graph_Vertex<T> FindVertex(T data_to_find)
        {
            foreach (CSC382Graph_Vertex<T> iter in Graph)
            {
                if (iter.GetData() is IComparable && ((IComparable<T>)iter.GetData() == ((IComparable<T>)data_to_find)) ||
                    StringComparer.CurrentCulture.Equals(iter.GetData(), data_to_find))
                {
                    return iter;
                }
            }
            return default;
        }

        /// <summary>
        /// search the graph for specified node
        /// </summary>
        /// <param name="node_to_find">vertex node to search for in the graph</param>
        /// <returns></returns>
        public CSC382Graph_Vertex<T> FindVertex(CSC382Graph_Vertex<T> node_to_find)
        {
            foreach (CSC382Graph_Vertex<T> iter in Graph)
            {
                if (iter == node_to_find)
                {
                    return iter;
                }
            }
            return default;
        }

        /// <summary>
        /// returns the size of the graph
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return Graph.Count();
        }
    }


    /// <summary>
    /// Class that represents an edge in a graph
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSC382Graph_Edge<T>
    {
        /// <summary>
        /// starting node for the edge
        /// </summary>
        private CSC382Graph_Vertex<T> starting_vertex;

        /// <summary>
        /// ending node for the edge
        /// </summary>
        private CSC382Graph_Vertex<T> ending_vertex;


        /// <summary>
        /// default constructor for edge
        /// </summary>
        public CSC382Graph_Edge()
        {
            starting_vertex = default;
            ending_vertex = default;
        }

        /// <summary>
        /// secondsary constructor for edge built with provided nodes
        /// </summary>
        /// <param name="start">start node for edge</param>
        /// <param name="end">end node for edge</param>
        public CSC382Graph_Edge(CSC382Graph_Vertex<T> start, CSC382Graph_Vertex<T> end)
        {
            starting_vertex = start;
            ending_vertex = end;
        }

    }

    /// <summary>
    /// This class represents a graph using adjacency list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSC382Graph_AdjacencyList<T>
    {
        /// <summary>
        /// representation of the graph holding vertex nodes as a  doubly linked List node
        /// </summary>
        private List<LinkedList<T>> graph_adjacencylist;

        /// <summary>
        /// Default constructor that initializes the vector as an empty vector
        /// </summary>
        public CSC382Graph_AdjacencyList()
        {
            graph_adjacencylist = new List<LinkedList<T>>();
        }

        /// <summary>
        /// Add a vertex node with provided data to the graph
        /// </summary>
        /// <param name="data">data of individual vertex node</param>
        /// <returns>new vertex node</returns>
        public LinkedList<T> AddVertex(T data)
        {
            // Attempt to find
            if (IsVertex(data))
            {
                //return default;
                throw new Exception("Vertex is already in the graph. Duplicate NOT added.");
            }
            else
            {

                LinkedList<T> new_vertex = new LinkedList<T>();        // Create new list to house the vertex and its edges
                new_vertex.AddLast(data);                // Data is added as the first element in the list
                graph_adjacencylist.Add(new_vertex); // list pointer is added to the graph
                return new_vertex;
            }
        }


        /// <summary>
        /// Add an Edge to the graph from the provided node to a new node with the provided data
        /// </summary>
        /// <param name="vertex">node to add edge from</param>
        /// <param name="data">data of new node at the end point of the edge</param>
        /// <returns></returns>
        public bool AddEdge(LinkedList<T> vertex, T data)
        {
            if (!IsVertex(vertex))
            {
                throw new Exception("Vertex specified does not exist. Cannot add edge to a non-existant vertex.");

                //return false;
            }
            if (IsVertex(data))        // Data must be an existing vertex or it will need to be created.
            {
                vertex.AddLast(data);
                return true;
            }
            else
            {
                LinkedList<T> new_vertex = AddVertex(data);
                new_vertex.AddLast(data);
                return true;
            }
        }


        /// <summary>
        /// add edge from starting node to ending node
        /// </summary>
        /// <param name="starting_vertex">staring node</param>
        /// <param name="ending_vertex">ending node</param>
        /// <returns>true if successfully added</returns>
        public bool AddEdge(LinkedList<T> starting_vertex, LinkedList<T> ending_vertex)
        {
            if (!IsVertex(starting_vertex) || !IsVertex(ending_vertex))
            {
                //return false;

                throw new Exception("Cannot AddEdge because one of the specified vertices does not exist in the graph.");
            }
            if (!IsEdge(starting_vertex, ending_vertex.First()))       // Prevent adding duplicate edges
            {
                starting_vertex.AddLast(ending_vertex.First());
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks to see if provided data is part of graph
        /// </summary>
        /// <param name="data">data stored in the node</param>
        /// <returns></returns>
        public bool IsVertex(T data)
        {
            foreach (LinkedList<T> iter in graph_adjacencylist)
            {
                // Check the first value in the list which is the primary vertex
                if (iter.First().Equals(data))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks to see if provided node is part of graph
        /// </summary>
        /// <param name="vertex_to_find">node to look for</param>
        /// <returns></returns>
        public bool IsVertex(LinkedList<T> vertex_to_find)
        {
            foreach (LinkedList<T> iter in graph_adjacencylist)
            {
                if (iter == vertex_to_find)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks to see if provided edge is part of the graph
        /// </summary>
        /// <param name="edge_to_find">edge to look for</param>
        /// <returns></returns>
        public bool IsEdge(T edge_to_find)
        {
            foreach (LinkedList<T> iter in graph_adjacencylist)
            {
                if (IsEdge(iter, edge_to_find))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// check to see if edige is part of the adjacent nodes in provided node
        /// </summary>
        /// <param name="vertex">node to search</param>
        /// <param name="edge_to_find">edge data to find</param>
        /// <returns></returns>
        public bool IsEdge(LinkedList<T> vertex, T edge_to_find)
        {
            foreach (T i in vertex)
            {
                // skip checking the primary vertex and only check edges
                if (vertex.First().Equals(i))
                {
                    continue;
                }
                if (i is IComparable && ((IComparable<T>)i == (IComparable<T>)edge_to_find) ||
                    StringComparer.CurrentCulture.Compare(i, edge_to_find) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// looks for given data within the graph
        /// </summary>
        /// <param name="data">data to search for</param>
        /// <returns>node that has data or default value if doesn't exist</returns>
        public LinkedList<T> FindVertex(T data)
        {
            foreach (LinkedList<T> iter in graph_adjacencylist)
            {
                if (iter.First().Equals(data))
                {
                    return iter;
                }
            }
            return default;
        }

        /// <summary>
        /// provides string representation of the graph
        /// </summary>
        /// <returns></returns>
        public string PrintAdjacencyList()
        {
            string node = "";
            foreach (LinkedList<T> iter in graph_adjacencylist)
            {
                var current = iter.First;
                while (current != null)
                {
                    if (current == iter.First)
                    {
                        node += "Vertex = " + current.Value + "   Edges = ";
                    }
                    else
                    {
                        node += current.Value.ToString() + " ";
                    }

                    current = current.Next;
                }

                /* //Original
                foreach (T i in iter)
                {
                    // skip checking the primary vertex and only check edges
                    if (iter.First().Equals(i))     // Prints the Vertex 
                    {
                        return "Vertex = " + i + "   Edges = ";
                    }
                    else    // Prints the Edges
                    {
                        return i + " ";
                    }
                }*/

                //return node + "\n";
            }

            return "\n" + node + "\n" + "Done!\n";
        }

        /// <summary>
        /// gets the number of edges in the graph node that hold provided data
        /// </summary>
        /// <param name="vertex_data"></param>
        /// <returns>number of edges in the graph</returns>
        public int NumberOfEdges(T vertex_data)
        {
            LinkedList<T> vertex = FindVertex(vertex_data);

            if (vertex != default)
            {
                return NumberOfEdges(vertex);
            }
            return -1;
        }

        /// <summary>
        /// gets the number of edges in the graph node
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int NumberOfEdges(LinkedList<T> vertex)
        {
            return vertex.Count;
        }

        /// <summary>
        /// gets the number of edges in the graph
        /// NOTE: this was added by me and was not provided as part of the provided code
        /// </summary>
        /// <returns></returns>
        public int NumberOfEdges()
        {
            int edges = 1;

            foreach (var item in graph_adjacencylist)
            {
                edges += item.Count - 1;
            }
            return edges;
        }

        /// <summary>
        /// gets the size of the graph
        /// </summary>
        /// <returns>size of graph</returns>
        public int GraphSize()
        {
            return graph_adjacencylist.Count;
        }


    }
}

