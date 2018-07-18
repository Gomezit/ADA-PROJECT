using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlNebulosas : MonoBehaviour {

	public ViaLactea viaLactea;
	public Grafo grafo;
	public List<Nebulosa> listaNebulosas;
	int[,] matrizAdyacencia = new int[4,4];
	List<string> planetas;
	public Dropdown m_Dropdown;

	int[,] a2 = new int[4, 4];
	int V;


	private int[,] mat;



	public void llenarMatriz()
	{
		mat = new int[viaLactea.Nebulosas.Count, viaLactea.Nebulosas.Count];
		List<Nebulosa> nebulosas = viaLactea.Nebulosas;

		int k = 0;

		for (int f = 0; f < 4; f++)
		{
			for (int c = 0; c <4 ; c++)
			{
				mat[f, c] =  calcularDistancia(nebulosas[f].x, nebulosas[f].y, nebulosas[c].x, nebulosas[c].y);
				mat[c, f] = calcularDistancia(nebulosas[f].x, nebulosas[f].y, nebulosas[c].x, nebulosas[c].y);
				k++;
			}
		
		}

		primMST(mat);
	}

	public void ImprimirMatriz()
	{
		string cad = "";

		for (int f = 0; f < 4; f++)
		{
			for (int c = 0; c < 4; c++)
			{
				cad += mat[f, c] + " ";
			}
			cad +="|";
		}
		Debug.Log(cad);
	}

	public GameObject[] prefabsNebulosas;

	int totalIridioMejoras = 0;
	int totalZeroMejoras = 0;
	int totalPaladioMejoras = 0;
	int totalPlatinoMejoras = 0;

	void Awake()
	{

		listaNebulosas = new List<Nebulosa>();
		this.V = listaNebulosas.Count;
		
		cargarInfoDesdeJson();
		
		//grafo = new Grafo();
		//grafo.identificarVertices(this.viaLactea);
		//grafo.crearMatrizAdyacencia(this.listaNebulosas);
		//grafo.printMatrixAdjacency();


	}

	void Start()
	{
		this.V = viaLactea.Nebulosas.Count;
		mejorOpcion();
		
		llenarMatriz();
		ImprimirMatriz();
		m_Dropdown.ClearOptions();
		m_Dropdown.AddOptions(planetas);
		//m_Dropdown.ClearOptions();
		m_Dropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(m_Dropdown);
		});

	}


	void DropdownValueChanged(Dropdown change)
	{

		foreach (var item in viaLactea.Nebulosas)
		{

			foreach (var sistema in item.sistemasPlanetarios)
			{

				foreach (var planeta in sistema.nodos)
				{

					
						if (planetas[change.value] == planeta.nombre)
						{

						GameObject.FindObjectOfType<Singleton>().nebulosaTemp = item;
						GameObject.FindObjectOfType<Singleton>().sistemaTemp = sistema;
						GameObject.FindObjectOfType<Singleton>().planetaTemp = planeta;
						GameObject.FindObjectOfType<Singleton>().banderaDropdown = 1;

						SceneManager.LoadScene("SistemaPlanetario");


						Debug.Log("Encontrado" + planeta.nombre);
						}
					
					

				}
			}

		}

			
	}



	private void llenarListaNebulosas()
	{
		foreach (var item in viaLactea.Nebulosas)
		{

			this.listaNebulosas.Add(item);

		}

	}
	
	
	private void cargarInfoDesdeJson()
	{

		string path = @"C:\Users\gomez\Documents\ADA PROJECT\Assets\/viaLactea.json";
		string readText = File.ReadAllText(path);

		viaLactea = JsonUtility.FromJson<ViaLactea>(readText);
		GameObject.FindObjectOfType<Singleton>().ViaLactea = viaLactea;

		cargarNebulosas(viaLactea);

	}


	private int indiceAleatorio()
	{

		System.Random rnd = new System.Random();
		int index = rnd.Next(0, prefabsNebulosas.Length);

		return index;

	}


	public void cargarNebulosas(ViaLactea viaLactea)
	{
		planetas = new List<string>();
		
		foreach (var item in viaLactea.Nebulosas)
		{

			foreach (var sistema in item.sistemasPlanetarios)
			{

				foreach(var planeta in sistema.nodos)
				{
					planetas.Add(planeta.nombre);

				}
			}

			Vector3 pos = new Vector3(item.x, item.y, item.z);
			
			GameObject nebulosa = Instantiate(prefabsNebulosas[0], pos, Quaternion.Euler(90,0,0));
			nebulosa.GetComponent<PrefabNebulosa>().nebulosa = item;

			
		}
		m_Dropdown.AddOptions(planetas);

	}

	private int calcularDistancia(float x1, float y1, float x2, float y2)
	{

		float distancia = Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));


		return (int)distancia;
	}

	private void crearMatrizAdyacencia()
	{


		for (int i = 0; i < this.V; i++)
		{
			for (int j = 0; j < this.V; j++)
			{

				//this.matrizAdyacencia[i, j] = 1;
				//this.matrizAdyacencia[j, i] = 2;
				//this.matrizNombreVertices[f, c] = nebulosa.nombre;
				//this.matrizNombreVertices[c, f] = nebulosa.nombre;

			}
		}

	}

	public string printMatrixAdjacency(int[,] matriz)
	{
		string cad = "";

		for (int i = 0; i < this.V; i++)
		{
			for (int j = 0; j < this.V; j++)
			{

				cad += matriz[i, j] + ",";
			}
			cad += "|";
		}

		return cad;
	}


	public void totalRecursosMejoras()
	{
				
		foreach (var item in GameObject.FindObjectOfType<Singleton>().listaMejoras)
		{
			totalIridioMejoras += item.costoIridio;
			totalPaladioMejoras += item.costoPaladio;
			totalZeroMejoras += item.costoZero;
			totalPlatinoMejoras += item.CostoPlatino;
		}		
	}

	public void mejorOpcion()
	{
		

		foreach (var nebulosa in viaLactea.Nebulosas)
		{
			listaNebulosas.Add(nebulosa);

		}

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{

				this.matrizAdyacencia[i, j] = 1;
			}
		}

		Debug.Log(printMatrixAdjacency(this.matrizAdyacencia));

		
	}


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
		Debug.Log("NEBULOSAS A VISITAR");
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
