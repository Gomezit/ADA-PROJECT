﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo1  {

		int N,V;
		static int[,] P;

		public Grafo1(int vertices) {

		this.N = vertices;
		this.V = vertices;
		P = new int[N, N];
		}

		public void main()
		{
			int[,] M = { { 0,    5, 999,  999 }, 
						 { 50,   0,  15,    5 }, 
						 { 30, 999,   0,   15 },
			             { 15, 999,   5,    0 } };
			
			Debug.Log("Matrix to find the shortest path of.");
			printMatrix(M);
			Debug.Log("Shortest Path Matrix.");
			printMatrix(FloydAlgo(M));
			Debug.Log("Path Matrix");
			printMatrix(P);
			Debug.Log("Algoritmo Prim");
			primMST(M);
		}

		public  int[,] FloydAlgo(int[,] M)
		{
			for (int k = 0; k < N; k++)
			{
				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < N; j++)
					{
						// to keep track.;
						if (M[i, k] + M[k, j] < M[i, j])
						{
							M[i, j] = M[i, k] + M[k, j];
							P[i, j] = k;
						}

					}
				}
			}
			return M;
		}


		public  void printMatrix(int[,] Matrix)
		{
			string cad = "";

			cad += "\n ";
			for (int j = 0; j < N; j++)
			{
				cad += j + " - ";
			}
			cad += "";
			for (int j = 0; j < 35; j++)
			{
				cad += "-";
			}
			cad += "";
			for (int i = 0; i < N; i++)
			{
				cad += i + " | - ";
				for (int j = 0; j < N; j++)
				{
					cad += Matrix[i, j];
					cad += " - ";
				}
				cad += "\n";
			}
			Debug.Log(cad);
		}


	// A C# program for Prim's Minimum 
	// Spanning Tree (MST) algorithm.
	// The program is for adjacency 
	// matrix representation of the graph



	// A utility function to find 
	// the vertex with minimum key
	// value, from the set of vertices 
	// not yet included in MST
	int minKey(int[] key, bool[] mstSet)
	{

		// Initialize min value
		int min = int.MaxValue, min_index = -1;

		for (int v = 0; v < V; v++)
			if (mstSet[v] == false && key[v] < min)
			{
				min = key[v];
				min_index = v;
			}

		return min_index;
	}

	// A utility function to print
	// the constructed MST stored in
	// parent[]
	public void printMST(int[] parent, int n, int[,] graph)
	{
		Debug.Log("Edge Weight");
		for (int i = 1; i < V; i++)
			Debug.Log(parent[i] + " - " + i + " " + graph[i, parent[i]]);
	}

	// Function to construct and 
	// print MST for a graph represented
	// using adjacency matrix representation
	public void primMST(int[,] graph)
	{

		// Array to store constructed MST
		int[] parent = new int[V];

		// Key values used to pick
		// minimum weight edge in cut
		int[] key = new int[V];

		// To represent set of vertices
		// not yet included in MST
		bool[] mstSet = new bool[V];

		// Initialize all keys
		// as INFINITE
		for (int i = 0; i < V; i++)
		{
			key[i] = int.MaxValue;
			mstSet[i] = false;
		}

		// Always include first 1st vertex in MST.
		// Make key 0 so that this vertex is
		// picked as first vertex
		// First node is always root of MST
		key[0] = 0;
		parent[0] = -1;

		// The MST will have V vertices
		for (int count = 0; count < V - 1; count++)
		{

			// Pick thd minimum key vertex
			// from the set of vertices
			// not yet included in MST
			int u = minKey(key, mstSet);

			// Add the picked vertex
			// to the MST Set
			mstSet[u] = true;

			// Update key value and parent 
			// index of the adjacent vertices
			// of the picked vertex. Consider
			// only those vertices which are 
			// not yet included in MST
			for (int v = 0; v < V; v++)

				// graph[u][v] is non zero only 
				// for adjacent vertices of m
				// mstSet[v] is false for vertices
				// not yet included in MST Update 
				// the key only if graph[u][v] is
				// smaller than key[v]
				if (graph[u, v] != 0 && mstSet[v] == false &&
										graph[u, v] < key[v])
				{
					parent[v] = u;
					key[v] = graph[u, v];
				}
		}

		// print the constructed MST
		printMST(parent, V, graph);
	}

}

