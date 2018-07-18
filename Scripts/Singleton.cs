using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {


	public Nebulosa nebulosaTemp;
	public SistemaPlanetario sistemaTemp;
	public Planeta planetaAtacar;
	public Planeta planetaTempTeletransportador;
	public ViaLactea ViaLactea;
	public int bandera = 0; //DE LA VIA LACTEA AL SISTEMA PLANETARIO QUE TIENE TELETRANSPORTADOR
	public List<Mejora> listaMejoras = new List<Mejora>();
	public int banderaDropdown = 0;
	public Planeta planetaTemp;



	public static Singleton singleton;

	void Awake ()
	{
		agregarMejoras();

		if (Singleton.singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void agregarMejoras()
	{

		Mejora m1 = new Mejora("Escudo Multinúcleo", 1200, 500, 1800, 1600);
		Mejora m2 = new Mejora("Blindaje para naves pesadas", 5500, 4000, 3500, 5100);
		Mejora m3 = new Mejora("Cañón Thanix", 6000, 4000, 6000, 6000);
		Mejora m4 = new Mejora("Cañon Plasma", 3000, 2500, 2800, 3500);
		Mejora m5 = new Mejora("Capacidad de depósitos", 4000, 4000, 4000, 4000);
		Mejora m6 = new Mejora("Vida Infinity", 1000, 500, 1000, 1000);
		Mejora m7 = new Mejora("Capacidad de combustible", 2000, 1500, 1500, 3000);

		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m1);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m2);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m3);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m4);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m5);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m6);
		GameObject.FindObjectOfType<Singleton>().listaMejoras.Add(m7);


	}

}
