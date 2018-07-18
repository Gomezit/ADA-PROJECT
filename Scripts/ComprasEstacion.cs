using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprasEstacion : MonoBehaviour {

	private Canvas canvasSistemaCompras;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake()
	{
		GameObject objectCanvasSistemaCompras = GameObject.Find("CanvasCompras");

		if (objectCanvasSistemaCompras != null)
		{
			canvasSistemaCompras = objectCanvasSistemaCompras.GetComponent<Canvas>();

			
		}
	}

	private void OnMouseEnter()
	{

		
			//GameObject.FindObjectOfType<Singleton>().planetaAtacar.x = this.transform.position.x;
			//GameObject.FindObjectOfType<Singleton>().planetaAtacar.z = this.transform.position.z;
			canvasSistemaCompras.GetComponent<Canvas>().enabled = true;
			
		
	}
}
