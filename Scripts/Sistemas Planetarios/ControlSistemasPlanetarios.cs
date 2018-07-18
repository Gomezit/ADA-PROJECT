using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSistemasPlanetarios : MonoBehaviour {

	public GameObject[] prefabSistemasPlanetarios;

	public Text txtVida;
	public Text txtCombustible;
	public Text txtIridio;
	public Text txtPlatino;
	public Text txtPaladio;
	public Text txtZero;
	public Text txtSondas;
	

	void Start()
	{
		
		cargarSistemas(GameObject.FindObjectOfType<Singleton>().nebulosaTemp);

		StartCoroutine(estadisticasNave());
		

	}

	private int generarIndexAleatorio()
	{


		int indexAleatorio = UnityEngine.Random.Range(0, prefabSistemasPlanetarios.Length);

		return indexAleatorio;

	}

	public void cargarSistemas(Nebulosa nebulosa)
	{

		foreach (var item in nebulosa.sistemasPlanetarios)
		{
			Vector3 pos = new Vector3(item.x, item.y, item.z);
			GameObject SistemaPlanetario = Instantiate(prefabSistemasPlanetarios[generarIndexAleatorio()], pos, Quaternion.identity);
			SistemaPlanetario.GetComponent<PrefabSistemaPlanetario>().sistema = item;
		}

	}


	IEnumerator estadisticasNave()
	{
		
		while (true)
		{


			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.combustible -= 
				(int)Math.Ceiling(Math.Abs(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveHorizontal));

			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.combustible -=
				(int)Math.Ceiling(Math.Abs(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveVertical));

			txtCombustible.text = "Combustible: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.combustible;
			txtVida.text = "Vida: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida;
			txtIridio.text = "Iridio: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado;
			txtPaladio.text = "Paladio: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado;
			txtPlatino.text = "Platino: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado;
			txtZero.text = "Zero: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado;
			txtSondas.text = "Sondas: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas;

			yield return new WaitForSeconds(0.2f);

		}



	}
}
