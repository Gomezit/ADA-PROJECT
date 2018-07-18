using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarNebulosa : MonoBehaviour {



	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("colision");
			SceneManager.LoadScene("ViaLactea");

		}
	}
}
