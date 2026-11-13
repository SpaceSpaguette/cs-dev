using System.Numerics;
namespace sc_dev
{
    class Graphs
    {
        // Shared variables which the classes can manipulate
        int nodeCount = 0;
        int[,] Matrix;
        string[] nodeNames;

        // Links to other classes
        public Nodes Node;
        public Paths Path;
        public Edges Edge;
        public Analyzer Analyze;
        public Printer Print;



        public Graphs(int nodeCount)
        {
            this.nodeCount = nodeCount;
            Matrix = new int[nodeCount, nodeCount];
            nodeNames = new string[nodeCount] ;
            // Initialize other classes


            Node = new Nodes(this);
            Path = new Paths(this);
            Edge = new Edges(this);
            Analyze = new Analyzer(this);
            Print = new Printer(this);




        } // Constructor for parent. This declares the subclasses

        public class Nodes      
        {
            private Graphs parent;
            public Nodes(Graphs _parent)
            {
                parent = _parent;
            }

            public void Rename(int index, string newName)
            {
                parent.nodeNames[index] = newName;
            }
            public void Reset() { parent.Matrix = new int[parent.nodeCount, parent.nodeCount]; } // Set everything to 0
            public void Resize(int newSize) {
                int[,] newMatrix = new int[newSize, newSize];
                string[] newNodeNames = new string[newSize];

                for (int x = 0; x < Math.Min(parent.nodeCount, newSize); x++)
                {
                    for (int y = 0; y < Math.Min(parent.nodeCount, newSize); y++)
                    {
                        newMatrix[x, y] = parent.Matrix[x, y];
                    }
                }
                for (int x = 0; x < Math.Min(parent.nodeCount, newSize); x++)
                {
                    newNodeNames[x] = parent.nodeNames[x];
                }

                //copy the old matrix and names into the new ones
                parent.Matrix = newMatrix;
                parent.nodeNames = newNodeNames;
            } // Copy the old matrix and make a new one with the new size
            public void Separate(int index)
            {
                // This function will separate a node from the graph by removing all edges to and from it.
                for (int i = 0; i < parent.nodeCount; i++)
                {
                    parent.Matrix[index, i] = 0; // Remove outgoing edges
                    parent.Matrix[i, index] = 0; // Remove incoming edges
                }
            } // This will remove all edges to and from a node, effectively isolating it from the graph.
        } // This is a manipulator for the NODES and FIELD as a whole. has functions [RESET,RESIZE,RENAME]
        public class Paths      
        {
            private Graphs parent;
            public Paths(Graphs _parent)
            {
                parent = _parent;
            }
            public void Exists(int from, int to)
            {
                /*  Pathfinding to check if a path exists between two nodes.
                 * 1. Create values. 
                 *      Create Queue for nodes to check.
                 *      Create second Queue for nodes that have been 
                 *      Create an int which tells us which node we are on.
                 *      Create a Bool which tells us if its true or false.
                 * 2. The process
                 *     
                 *     Iterate over its neighbors. If the neighbor is the target node, return true. If not, add it to the queue.
                 *     Add the current node to the visited queue.
                 *     Change the current node to the first node in the queue and remove it from the queue. AKA "dequeue" it.
                 *     If the queue is empty, return false. If not, repeat step 2.
                 * 3. Return the result.
                 */
                Queue<int> toCheck = new Queue<int>();
                Queue<int> visited = new Queue<int>();
                int currentNode = from;
                int targetNode = to;
                visited.Enqueue(currentNode);
                while (true)
                {
                    for (int i = 0; i < parent.nodeCount; i++)
                    {
                        if (parent.Matrix[currentNode, i] != 0 && !visited.Contains(i))
                        {
                            if (i == targetNode)
                            {
                                Console.WriteLine("Path exists between " + visited.Dequeue() + " and " + targetNode);
                                return;
                            }
                            toCheck.Enqueue(i);
                        }
                    }
                    if (toCheck.Count == 0)
                    {
                        Console.WriteLine("No path exists between " + visited.Dequeue() + " and " + targetNode);
                        return;
                    }
                    currentNode = toCheck.Dequeue();
                    visited.Enqueue(currentNode);
                }
            }
        } // TODO: Add the pathfinding functions
        public class Edges      
        {
            private Graphs parent;
            public Edges(Graphs _parent)
            {
                parent = _parent;
            }

            public void Create(int from, int to, int cost = 1)
            {
                if (from < 0) {from = from * -1;}
                if (to < 0) {to = to * -1;}
                parent.Matrix[from, to] = cost;
            } 
            public void Remove(int from, int to)
            {
                if (from < 0) {from = from * -1;}
                if (to < 0) {to = to * -1;}
                parent.Matrix[from, to] = 0;
            }
            public void CopyFromList(int[,] list)
            {
                int rows = list.GetLength(0);
                int cols = list.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        parent.Matrix[i, j] = list[i, j];
                    }
                }
            } // Copies a list into the relational matrix

        } // this class serves as the manipulator for edges between nodes. [CREATE,DELETE]
        public class Analyzer   
        {
            private Graphs parent;
            public Analyzer(Graphs _parent)
            {
                parent = _parent;
            }
        } // The analyzer that the Teach requested. This will be made as the last thing ever
        public class Printer    
        {
            private Graphs parent; //Acts as a link between memory of the parent Graphs and the Print
            public Printer(Graphs _parent)
            {
                parent = _parent;
            } // constructor
            public void Matrix()
            {
                int rows = parent.Matrix.GetLength(0);
                int cols = parent.Matrix.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(parent.Matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            } // Prints the relational matrix
        } // this makes the .Print.Matrix() work as it looks amazing
    }
}