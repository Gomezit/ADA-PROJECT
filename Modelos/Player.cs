using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player  {

	public int vida = 1200;
	public int danio = 60;
	public int combustible = 100000;
	public int capacidadCombustible = 200000;
	public int capacidadMateriales = 80000;
	public float x;
	public float y;
	public float z;
	public int iridioRecolectado=0;
	public int paladioRecolectado=0;
	public int platinoRecolectado=0;
	public int elementoZeroRecolectado=0;
	public int numeroSondas = 15;




	// Use this for initialization
	void Start () {

		//Vector3 pos = new Vector3(x, y, z);
		//GameObject nebulosa = Instantiate(player, pos, Quaternion.identity);
		//GameObject.FindObjectOfType<SingletonPlayer>().player = player;
		//nebulosa.GetComponent<PrefabNebulosa>().nebulosa = item;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool capacidadDisponibleMateriales()
	{
		int cantidadMaterialesRecolectados = this.elementoZeroRecolectado + this.iridioRecolectado + this.paladioRecolectado + this.platinoRecolectado;

		return cantidadMaterialesRecolectados < this.capacidadMateriales ? true : false;
	
	}

	

}
