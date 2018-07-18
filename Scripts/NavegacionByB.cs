using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavegacionByB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 /**
	 * Buscar el sistema que tiene mejor relación recursos/distancia
	 * usando la estrategia de Branch and Bound
	 * @return solucion sistema con mejor relación
	 */

	public SistemaPlanetario mejorSistemaParaRecolectarByB()
	{

		var visitados = new List<SistemaPlanetario>();
		//SistemaPlanetario solucion = null;
		


		return null;

	}

	/**
 * Busar el camino al sistema que tiene mejor relación recursos/distancia
 * usando la estrategia de Branch and Bound
 * @return solucion sistema, o sistemas si se cuenta con relé, con mejor relación
 */
//	hallarSistemaMayorBeneficio = () => {
//     let visitados = []

//	 let distanciaVisitados = { }

//	 solucion = null
//     cota = 0
//     lugarActual = null

//     let distanciaAcum = 0


//	 listaSistemas = listarSistemas()
//     if(sistema) {
//          lugarActual = nebulosa
//		  distanciaAcum = 1000

//		  visitados.push(sistema)
//		  distanciaVisitados[sistema] = 0

//		  sistema = null
//     } else if(nebulosa) {
//          lugarActual = nebulosa
//     } else if(galaxia) {
//          lugarActual = galaxia
//     } else {
//          lugarActual = universo
//     }

//     let distanciaCombustible = calcularDistanciaCombustible()


//	 let LNV = []

//	 let camino = []

//	 camino.push(lugarActual)
//	 LNV.push({ caminoActual: camino, distAcum: distanciaAcum })
//     while (LNV.length > 0) {
//          let { caminoActual, distAcum } = LNV.shift()
//		  let actual = caminoActual[caminoActual.length - 1]
//		  visitados.push(actual)

//		  distanciaVisitados[actual] = distAcum

//          if (distAcum > distanciaCombustible) {
//               continue
//          }
//          if(obtenerTipo(actual) === 'sistema') { // Es un sistema planetario
//               let recursos = { }

//			   recursos = calcularRecursosSistema(actual)


//			   let totalRecursos = recursos.iridio + recursos.paladio + recursos.platino + recursos.zero

//			   cotaTmp = totalRecursos / distAcum
//               if (cotaTmp > cota && compararRecursosMejora(recursos)) {
//                    solucion = caminoActual
//					cota = cotaTmp
//               }
//               if (actual.teletransportador) {
//                    let sistemasTeletransportador = buscarDestinosTeletransportador(actual)

//					sistemasTeletransportador.forEach(st => {
//                         if (visitados.indexOf(st) < 0 || distanciaVisitados[st] > distAcum) {
//                              let nuevoCamino = caminoActual.slice()

//							  nuevoCamino.push(st)
//							  LNV.push({ caminoActual: nuevoCamino, distAcum })
//                         }
//                    })
//               }
//          } else {
//               let padre = obtenerPadre(actual)
//               if(padre && (visitados.indexOf(padre) < 0 || distanciaVisitados[padre] > distAcum + 1000)) {
//                    let nuevoCamino = caminoActual.slice()

//					nuevoCamino.push(padre)
//					let nuevaDist = distAcum + 1000
//                    LNV.push({ caminoActual: nuevoCamino, distAcum: nuevaDist })
//               }
//               let hijos = obtenerHijos(actual)

//			   hijos.forEach(h => {
//                    if(visitados.indexOf(h) < 0 || distanciaVisitados[h] > distAcum + 1000 + calcularDistancia(200, 200, h.x, h.y)) {
//                         let nuevoCamino = caminoActual.slice()

//						 nuevoCamino.push(h)
//						 let nuevaDist = distAcum + 1000 + calcularDistancia(200, 200, h.x, h.y)

//						 LNV.push({ caminoActual: nuevoCamino, distAcum: nuevaDist })
//                    }
//               })
//          }
//     }
//     return solucion
//}

}
