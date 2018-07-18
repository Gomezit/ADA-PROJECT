using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaGrafo : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		//int INF = 999999;

		//int[,] graph =  { { 0, 5, INF, INF }, { 50, 0, 15, 5 }, { 30, INF, 0, 15 },
				  // { 15, INF, 5, 0 } };
		//int numVertices = graph.GetLength(0);

		//Grafo a = new Grafo(numVertices);

		// Print the solution
		//a.floydWarshall(graph);

		//Algoritmo Prim

		/* Let us create the following graph
        2 3
        (0)--(1)--(2)
        | / \ |
        6| 8/ \5 |7
        | / \ |
        (3)-------(4)
            9     */


		// Print the solution
		//a.primMST(graph);

		Grafo1 g = new Grafo1(4);
		g.main();
	}
	
}





