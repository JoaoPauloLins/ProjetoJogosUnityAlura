using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField] private CaixaDeSom caixaDeSom;
    [SerializeField] private GameObject CanoDaArma;
    [SerializeField] private ReservaExtensivel reservaDeBalas;

    private void Update()
    {
        var toquesNaTela = Input.touches;
        foreach(var toque in toquesNaTela)
        {
            if(toque.phase == TouchPhase.Began)
            {
                this.Atirar();
                caixaDeSom.Tocar();
            }
        }
      
    }

    private void Atirar()
    {
        if (this.reservaDeBalas.TemObjeto())
        {
            var bala = this.reservaDeBalas.PegarObjeto();
            bala.transform.position = CanoDaArma.transform.position;
            bala.transform.rotation = CanoDaArma.transform.rotation;
        }
    }
}
