using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo {


	int V;
	public int[,] matrizAdyacencia;
	private int[,] mat;
	private string[] nombreVertices; 
	private string[,] matrizNombreVertices;
	private List<Nebulosa> nebulosas;
	private List<SistemaPlanetario> sistemasPlanetarios;
	private List<Planeta> planetas;
	
	


	public Grafo() {

		
		matrizAdyacencia = new int[V, V];
		matrizNombreVertices = new string[V, V];
		nebulosas=new List<Nebulosa>();
	    sistemasPlanetarios= new List<SistemaPlanetario>();
		planetas = new List<Planeta>() ;
		this.V = 4;

	}

	private float calcularDistancia(float x1, float y1, float x2,  float y2)
	{

		float distancia = Mathf.Sqrt(Mathf.Pow(x2 - x1,2) + Mathf.Pow(y2 - y1, 2));
	
		return distancia;
	}

	public void identificarVertices(ViaLactea viaLactea) {

		foreach (var nebulosa in viaLactea.Nebulosas)
		{
			
			this.nebulosas.Add(nebulosa);

			foreach (var sistemaPlanetario in nebulosa.sistemasPlanetarios)
			{
				
				this.sistemasPlanetarios.Add(sistemaPlanetario);

				foreach (var planeta in sistemaPlanetario.nodos)
				{
					
					this.planetas.Add(planeta);
				}
			}
		}
	}


	
			

	public int[,] crearMatrizAdyacencia(List<Nebulosa> listaNebulosas)
	{
		
		for (int i = 0; i < listaNebulosas.Count; i++)
		{
			for (int j = 0; j < listaNebulosas.Count; j++)
			{

				this.matrizAdyacencia[i, j] = 1;
				this.matrizAdyacencia[j, i] = 2;
				//this.matrizNombreVertices[f, c] = nebulosa.nombre;
				//this.matrizNombreVertices[c, f] = nebulosa.nombre;

			}
		}

				
		return this.matrizAdyacencia;
	}

	

	public void Imprimir()
	{
		for (int f = 0; f < V; f++)
		{
			for (int c = 0; c < V; c++)
			{
				Debug.Log(this.matrizAdyacencia[f, c]);
				
			}
			Debug.Log("");
		}
		
	}

	public void printMatrixAdjacency()
	{
		string cad = "";

		for (int i = 0; i < this.nebulosas.Count; i++)
		{
			for (int j = 0; j < this.nebulosas.Count; j++)
			{

				cad += this.matrizAdyacencia[i, j] + ",";
			}
			cad += "|";
		}

		Debug.Log(cad);
	}

	public void printMatrixNameVertex()
	{
		string cad = "";

		for (int i = 0; i < V; i++)
		{
			for (int j = 0; j < V; j++)
			{

				cad += this.matrizNombreVertices[i, j] + ",";
			}
			cad += "|";
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
			Debug.Log(parent[i] + " - " + i + " " +	graph[i, parent[i]]);
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
