using System;
using sc_dev;


Graphs g1 = new Graphs(5); // Create a graph with 5 nodes
g1.Node.Rename(0, "A");
g1.Print.Matrix(); // Print the initial matrix
g1.Node.Resize(7); // Resize the graph to 7 nodes
g1.Print.Matrix(); // Print the resized matrix