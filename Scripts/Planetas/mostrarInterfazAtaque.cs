using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarInterfazAtaque : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (Input.GetMouseButtonDown(0))
			Debug.Log("Pressed primary button.");

		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed secondary button.");

		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
	}

}
