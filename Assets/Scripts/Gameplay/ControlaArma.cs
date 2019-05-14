using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    [SerializeField] private CaixaDeSom caixaDeSom;
    [SerializeField] private GameObject CanoDaArma;
    [SerializeField] private ReservaExtensivel reservaDeBalas;

    private float tempoRecargaArma;
    private float cronometro;

    private void Update()
    {
        cronometro -= Time.deltaTime;

        var toquesNaTela = Input.touches;
        foreach(var toque in toquesNaTela)
        {
            if (cronometro <= 0 && toque.phase == TouchPhase.Began)
            {
                this.Atirar();
                caixaDeSom.Tocar();
                cronometro = tempoRecargaArma;
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

    public void AtualizarTempoRecargaArma(float novoTempoRecarga)
    {
        tempoRecargaArma = novoTempoRecarga;
        cronometro = tempoRecargaArma;
    }
}
