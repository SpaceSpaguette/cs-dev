using System.Numerics;
namespace sc_dev
{
    class Graphs
    {
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
            nodeNames = new string[nodeCount];
            // Initialize other classes


            Node = new Nodes(this);
            Path = new Paths(this);
            Edge = new Edges(this);
            Analyze = new Analyzer(this);
            Print = new Printer(this);




        } // Constructor for parent

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
        }
        public class Paths
        {
            private Graphs parent;
            public Paths(Graphs _parent)
            {
                parent = _parent;
            }
        }
        public class Edges
        {
            private Graphs parent;
            public Edges(Graphs _parent)
            {
                parent = _parent;
            }
        }
        public class Analyzer
        {
            private Graphs parent;
            public Analyzer(Graphs _parent)
            {
                parent = _parent;
            }
        }
        public class Printer
        {
            private Graphs parent;
            public Printer(Graphs _parent)
            {
                parent = _parent;
            }
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
            }
        }


    }
}