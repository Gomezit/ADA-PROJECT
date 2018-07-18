using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    public Transform player;
    public GameObject[] hazards;
	public Button enemigoA;
	public Button enemigoB;
	public Button enemigoC;
	public Button cerrarPanelSistemaAtaque;

	public Button comprarSOndas;
	public Button comprarGasolina;
	public Button cerrarSistemaCompras;

	public GameObject enemigo;
	public int cantidadExploradoras;
	private int speedX;
	public Text txtVida;
	public Text txtCombustible;
	public Text txtIridio;
	public Text txtPlatino;
	public Text txtPaladio;
	public Text txtZero;
	public Text txtSondas;
	public Text txtVidaEnemigo;
	private List<Mejora> mejoras;

	bool  mejora1;
	bool  mejora2;
	bool  mejora3;
	bool  mejora4;
	bool  mejora5;
	bool  mejora6;
	bool  mejora7;
	

	
    void Start()
	{

		mejoras = GameObject.FindObjectOfType<Singleton>().listaMejoras;
		        
		StartCoroutine(estadisticasNave());
		enemigoA.onClick.AddListener(delegate { desplegarEnemigo("nodriza"); });
		enemigoB.onClick.AddListener(delegate { desplegarEnemigo("avanzada"); });
		enemigoC.onClick.AddListener(delegate { desplegarEnemigo("exploradora"); });
		cerrarPanelSistemaAtaque.onClick.AddListener(delegate { cerrarPanelSistema(); });

		comprarSOndas.onClick.AddListener(delegate { compraEspacial("sonda"); });
		comprarGasolina.onClick.AddListener(delegate { compraEspacial("gasolina"); });
		cerrarSistemaCompras.onClick.AddListener(delegate { cerrarPanelSistemaCompras(); });

		enemigo = null;
		cantidadExploradoras = 0;
		StartCoroutine(comprarMejorasAutomaticamente());
	}

    void Update()
    {

		

	}

    

	private void desplegarEnemigo(string tipoEnemigo)
	{

		if (tipoEnemigo == "nodriza") {

			enemigo = hazards[1];

			enemigo.GetComponent<Enemigo>().tipo = "nodriza";
			enemigo.GetComponent<Enemigo>().vida = 500;
			enemigo.GetComponent<Enemigo>().danio = 150;

			

		}
		if (tipoEnemigo == "avanzada") {

			enemigo = hazards[2];

			enemigo.GetComponent<Enemigo>().tipo = "avanzada";
			enemigo.GetComponent<Enemigo>().vida = 400;
			enemigo.GetComponent<Enemigo>().danio = 100;

			
		}
		if (tipoEnemigo == "exploradora") {

			enemigo = hazards[0];

			enemigo.GetComponent<Enemigo>().tipo = "exploradora";
			enemigo.GetComponent<Enemigo>().vida = 100;
			enemigo.GetComponent<Enemigo>().danio = 50;
			cantidadExploradoras = 4;


		}		
	}

	private void cerrarPanelSistema()
	{

		GameObject.Find("CanvasSistemaAtaque").GetComponent<Canvas>().enabled = false;
	}

	private void cerrarPanelSistemaCompras()
	{

		GameObject.Find("CanvasCompras").GetComponent<Canvas>().enabled = false;
	}


	public void compraEspacial(string articulo)
	{

		Player nave = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp;

		if (articulo == "gasolina" && nave.combustible + 10000 < nave.capacidadCombustible && nave.iridioRecolectado > 100 && nave.paladioRecolectado > 100 && nave.platinoRecolectado > 100 && nave.elementoZeroRecolectado > 100 )
		{

			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.combustible += 10000;
			nave.iridioRecolectado -= 100;
			nave.paladioRecolectado -= 100;
			nave.platinoRecolectado -= 100;
			nave.elementoZeroRecolectado -= 100;

		}else if (articulo == "sonda" && nave.iridioRecolectado > 200 && nave.paladioRecolectado > 200 && nave.platinoRecolectado > 100 && nave.elementoZeroRecolectado > 100)
		{
			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas += 1;
			nave.iridioRecolectado -= 200;
			nave.paladioRecolectado -= 200;
			nave.platinoRecolectado -= 100;
			nave.elementoZeroRecolectado -= 100;
		}
		else
		{

			Debug.Log("No dispones de recursos para comprar el artìculo seleccionado.");
		}
	}

	

	public void ataqueEnemigo()
	{
		GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Clear();


		GameObject.Find("GameController").GetComponent<AudioSource>().Play();

		Planeta planetaAtacado = GameObject.FindObjectOfType<Singleton>().planetaAtacar;
		Vector3 spawnPosition = new Vector3(planetaAtacado.x + 25, 0, planetaAtacado.z);
		Quaternion spawnRotation = enemigo.transform.rotation;

		cerrarPanelSistema();

		if (cantidadExploradoras != 0) {

			int k = 17;

			for (int i = 0; i < cantidadExploradoras; i++)
			{
				spawnPosition = new Vector3(planetaAtacado.x +k, 0, planetaAtacado.z );
				k = k + 10;

				Instantiate(this.enemigo, spawnPosition, spawnRotation);
				GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Add(enemigo);
			}

			cantidadExploradoras = 0;

		}else
		{

			Instantiate(this.enemigo, spawnPosition, spawnRotation);
			GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Add(enemigo);
		}

		
		batallar();

	}




	private void batallar()
	{

		Debug.Log("cantidad enemigos" + GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Count);
		

		if (calcularDisparosNave() >= calcularDisparosEnemigo())
		{
			Debug.Log("Emprender huida");
			GameObject.FindObjectOfType<Singleton>().bandera = 1; //DE UN SISTEMA PLANETARIO A LA NEBULOSA
			SceneManager.LoadScene("Nebulosa", LoadSceneMode.Single);
			
		}
		else
		{
			
			Debug.Log("Batalla");
			GameObject nave = GameObject.FindGameObjectWithTag("Player");

			nave.GetComponent<WeaponController>().enabled = true;


		}

	}

	private float calcularDisparosNave()
	{

		int vidaEnemigo = enemigo.GetComponent<Enemigo>().vida;
		int danioNave = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.danio;
		float numDisparos = vidaEnemigo / danioNave;

		Debug.Log("Num disparos nave : " + numDisparos);

		if (cantidadExploradoras != 0)
		{

			return numDisparos * cantidadExploradoras;
		}


		return numDisparos;

	}

	private float calcularDisparosEnemigo()
	{
		int vidaNave = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida;
		int danioEnemigo = enemigo.GetComponent<Enemigo>().danio;
		float numDisparos = vidaNave / danioEnemigo;

		Debug.Log("Num disparos enemigo : " + numDisparos);

		return numDisparos;

	}

	IEnumerator comprobarSistemaArmas()
	{
		Debug.Log("Comporbar Sistema");

		while (true)
		{
			if(GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Count != 0)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().enabled = true;

			}
			else
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>().enabled = false;
			}
			yield return new WaitForSeconds(0.2f);
		}
		
	}




	IEnumerator comprarMejorasAutomaticamente()
	{
		
		
		while (true)
		{
			Player nave = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp;



			//MEJORA 1 : Escudo Multinúcleo, 1 VEZ
			if (nave.elementoZeroRecolectado >= mejoras[0].costoZero && nave.iridioRecolectado >= mejoras[0].costoIridio 
				&& nave.paladioRecolectado >= mejoras[0].costoPaladio && nave.platinoRecolectado >= mejoras[0].CostoPlatino && mejora1 == false)
			{
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida += 400;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[0].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[0].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[0].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[0].CostoPlatino;
				
				mejora1 = true;
							
				Debug.Log("Mejora Escudo Multinúcleo comprada");



			}

			//MEJORA 2 : Blindaje para naves pesadas:, 1 VEZ
			if (nave.elementoZeroRecolectado >= mejoras[1].costoZero && nave.iridioRecolectado >= mejoras[1].costoIridio
				&& nave.paladioRecolectado >= mejoras[1].costoPaladio && nave.platinoRecolectado >= mejoras[1].CostoPlatino && mejora2 == false)
			{
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida += 1200;
				mejora2 = true;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[1].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[1].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[1].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[1].CostoPlatino;

				Debug.Log("Mejora Blindaje para naves pesadas comprada");

			}

			//MEJORA 3: Cañón Thanix, 1 VEZ
			if (nave.elementoZeroRecolectado >= mejoras[2].costoZero && nave.iridioRecolectado >= mejoras[2].costoIridio
				&& nave.paladioRecolectado >= mejoras[2].costoPaladio && nave.platinoRecolectado >= mejoras[2].CostoPlatino && mejora3 == false)
			{

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.danio += 200;
				mejora3 = true;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[2].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[2].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[2].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[2].CostoPlatino;

				Debug.Log("Mejora Cañón Thanix comprada");
			}

			//MEJORA 4 :Cañon Plasma, 1 VEZ
			if (nave.elementoZeroRecolectado >= mejoras[3].costoZero && nave.iridioRecolectado >= mejoras[3].costoIridio
				&& nave.paladioRecolectado >= mejoras[3].costoPaladio && nave.platinoRecolectado >= mejoras[3].CostoPlatino && mejora4 == false)
			{

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.danio += 100;
				mejora4 = true;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[3].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[3].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[3].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[3].CostoPlatino;

				Debug.Log("Mejora Cañon Plasma comprada");
			}

			//MEJORA 5 : Capacidad de depósitos, 1 VEZ
			if (nave.elementoZeroRecolectado >= mejoras[4].costoZero && nave.iridioRecolectado >= mejoras[4].costoIridio
				&& nave.paladioRecolectado >= mejoras[4].costoPaladio && nave.platinoRecolectado >= mejoras[4].CostoPlatino && mejora5 == false)
			{

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.capacidadMateriales += GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.capacidadMateriales/2;
				mejora5 = true;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[4].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[4].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[4].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[4].CostoPlatino;

				Debug.Log("Mejora Capacidad de depósitos comprada");

			}

			//MEJORA 6 : Vida Infinity: , MULTIPLES VECES
			if (nave.elementoZeroRecolectado >= mejoras[5].costoZero && nave.iridioRecolectado >= mejoras[5].costoIridio
				&& nave.paladioRecolectado >= mejoras[5].costoPaladio && nave.platinoRecolectado >= mejoras[5].CostoPlatino && mejora6 == false)
			{
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida += 50;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[5].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[5].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[5].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[5].CostoPlatino;
				mejora6 = true;
				Debug.Log("Mejora Vida Infinity comprada");

			}

			//MEJORA 6 : Capacidad de combustible: 1 vez
			if (nave.elementoZeroRecolectado >= mejoras[6].costoZero && nave.iridioRecolectado >= mejoras[6].costoIridio
				&& nave.paladioRecolectado >= mejoras[6].costoPaladio && nave.platinoRecolectado >= mejoras[6].CostoPlatino && mejora7 == false)
			{
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.capacidadCombustible += 50000;
				mejora7 = true;

				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado -= mejoras[6].costoZero;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado -= mejoras[6].costoIridio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado -= mejoras[6].costoPaladio;
				GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado -= mejoras[6].CostoPlatino;

				Debug.Log("Mejora Capacidad de combustible comprada");

			}

			yield return new WaitForSeconds(1);
		}

	}


		IEnumerator estadisticasNave()
	{
		
		while (true)
		{

			txtCombustible.text = "Combustible: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.combustible;
			txtVida.text = "Vida: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida;
			txtIridio.text = "Iridio: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.iridioRecolectado;
			txtPaladio.text = "Paladio: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.paladioRecolectado;
			txtPlatino.text = "Platino: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.platinoRecolectado;
			txtZero.text = "Zero: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.elementoZeroRecolectado;
			txtSondas.text = "Sondas: " + GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas;

			yield return new WaitForSeconds(1);

		}	

	}

	

	IEnumerator movernaveAutomatica()
	{
		float moveHorizontal = 0;
		float moveVertical = 0;
		int speed = 20;
		GameObject nave = GameObject.FindGameObjectWithTag("Player");

		while (nave.transform.position.x != enemigo.transform.position.x)
		{

			if(nave.transform.position.x > enemigo.transform.position.x)
			{
				moveHorizontal = moveHorizontal +0.01f;
				Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
				nave.GetComponent<Rigidbody>().velocity = movement * speed;
				nave.GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, 0f, nave.GetComponent<Rigidbody>().velocity.x*2);
				

			}else {

				moveHorizontal = moveHorizontal - 0.01f;
				Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
				GetComponent<Rigidbody>().velocity = movement * speed;
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, 0f, GetComponent<Rigidbody>().velocity.x * 2);

			}
			
			Debug.Log(moveHorizontal);

			yield return new WaitForSeconds(0.2f);
		}
			

	}



	IEnumerator lookAtEnemy()
	{
		
		GameObject nave = GameObject.FindGameObjectWithTag("Player");

		while (enemigo != null) {


			nave.GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, 80, 0);


			yield return new WaitForSeconds(0.3f);
		}
	}

	

  
}