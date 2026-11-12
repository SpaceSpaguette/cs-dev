using sc_dev;


Graphs g1 = new Graphs(5); // Create a graph with 5 nodes
g1.Edge.Create(0,1,2);
g1.Edge.Create(0,2,3);
g1.Edge.Create(0,3,4);
g1.Print.Matrix();