using sc_dev;

int[,] graphMatrix = new int[11, 11]; // Create a 11x11 adjacency matrix
Graphs g1 = new Graphs(11); // Create a graph with 11 nodes



graphMatrix = new int[,] 
                // 0  1  2  3  4  5  6  7  8  9  10 TO
               { { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 0  FROM
                 { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 }, // 1
                 { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
                 { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 }, // 3
                 { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }, // 4
                 { 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0 }, // 5
                 { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 }, // 6
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // 7
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, // 8
                 { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, // 9
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }  // 10
               };

g1.Edge.CopyFromList(graphMatrix); // Copy the adjacency matrix into the graph's edge structure
g1.Path.Exists(0, 10); // Check if a path exists between node 0 and node 10
g1.Print.Matrix(); // Print the adjacency matrix of the graph
g1.Node.Separate(10); // Separate node 10 from the graph
g1.Path.Exists(0, 10); // Check again if a path exists between node 0 and node 10 after separation
g1.Print.Matrix(); // Print the adjacency matrix of the graph after separation
