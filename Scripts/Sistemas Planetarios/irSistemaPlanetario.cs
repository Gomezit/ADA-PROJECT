using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irSistemaPlanetario : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		

		if (other.tag == "SpaceScene_LocalStar") {

			GameObject.FindObjectOfType<Singleton>().bandera = 2; //DE LA NEBULOSA AL SISTEMA PLANETARIO COLISIONADO
			GameObject.FindObjectOfType<Singleton>().sistemaTemp = other.GetComponent<PrefabSistemaPlanetario>().sistema;

			SceneManager.LoadScene("SistemaPlanetario", LoadSceneMode.Single);
		}

		

	}
}
