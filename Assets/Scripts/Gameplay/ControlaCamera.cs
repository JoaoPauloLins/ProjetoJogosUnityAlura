using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    private GameObject Jogador;
    private Vector3 distCompensar;

	private void Start () {
        Jogador = GameObject.FindGameObjectWithTag("Jogador");

        distCompensar = transform.position - Jogador.transform.position;
	}
	
	private void Update () {
        transform.position = Jogador.transform.position + distCompensar;
	}
}
