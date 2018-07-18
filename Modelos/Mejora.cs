using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejora {

	public string nombre;
	public int costoPaladio;
	public int costoZero;
	public int costoIridio;
	public int CostoPlatino;

	
	public Mejora(string nombre, int paladio, int zero, int iridio, int platino)
	{
		this.nombre = nombre;
		this.costoPaladio = paladio;
		this.costoZero = zero;
		this.costoIridio = iridio;
		this.CostoPlatino = platino;

	}
}
