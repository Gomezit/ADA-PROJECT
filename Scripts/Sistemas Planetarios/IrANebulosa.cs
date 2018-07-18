using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrANebulosa : MonoBehaviour {

	

	public void irNebulosa()
	{

		GameObject.FindObjectOfType<Singleton>().bandera = 1; //DE UN SISTEMA PLANETARIO A LA NEBULOSA
		SceneManager.LoadScene("Nebulosa", LoadSceneMode.Single);

	}
	
	
}
