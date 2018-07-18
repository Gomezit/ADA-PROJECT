using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;
	public GameObject sonda;
	public Transform spawnSonda;
	public float vida;
	private GameObject explosion;

	public float moveHorizontal;
	public float moveVertical;


	private float nextFire;
	private int numSondas;

	public string recolectarElemento1;
	public string recolectarElemento2;
	public int toneladasParaRecolectar=500;


	private void Awake()
	{
		
	}

	private void Start()
	{
		this.vida = 1;
		
		recolectarElemento1 = "iridio";
		recolectarElemento2 = "platino";


}

	void Update()
    {


		//if (Input.GetButton("Fire1") && Time.time > nextFire)
		//{
		//	nextFire = Time.time + fireRate;
		//	//foreach (var shotSpawn in shotSpawns)
		//	//{

		//		Instantiate(shot, shotSpawns[0].position, shotSpawns[0].rotation);


		//	//}
		//	GetComponent<AudioSource>().Play();
		//}

		if (Input.GetButton("Fire2") && Time.time > nextFire && GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas > 0)
		{
			nextFire = Time.time + fireRate + 3 / 2;


			//DECIRLE A LA SONDA LOS 2 ELEMENTOS A RECOLECTAR Y LA CAPACIDAD
			sonda.GetComponent<SondaEspacial>().recolectarElemento1 = this.recolectarElemento1;
			sonda.GetComponent<SondaEspacial>().recolectarElemento2 = this.recolectarElemento2;
			sonda.GetComponent<SondaEspacial>().toneladasParaRecolectar = this.toneladasParaRecolectar;


			Instantiate(sonda, spawnSonda.position, spawnSonda.rotation);
			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.numeroSondas - 1;
			

		}
		
	}

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

		

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;


		GetComponent<Rigidbody>().rotation = Quaternion.Euler(-90, 0f, GetComponent<Rigidbody>().velocity.x  * tilt);
		
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "boltEnemy" ) {

			if (this.vida > 0.173f)
			{
				this.vida =  this.vida - 0.7f;
			}
			else if(this.vida < 0.173f) {

				   


				//Instantiate(explosion, playerDestruir.transform.position, playerDestruir.transform.rotation);

				//this.imagenGameOver.SetActive(true);
				
				

			}

			}

			
		}


			
		
		
	}





