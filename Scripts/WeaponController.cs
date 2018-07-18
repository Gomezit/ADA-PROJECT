using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {

        //audioSource = GetComponent<AudioSource>();


        InvokeRepeating("Fire",delay,fireRate);
	}

    void Fire() {

		if(GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Count != 0)
		{
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

		}

        
        //double v = Random.Range(0, clips.length);
       // AudioClip clip = clips(v);
        //audioSource.clip = clip;

       
           // audioSource.Play();

        
        
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
