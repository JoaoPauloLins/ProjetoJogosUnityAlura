using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaJogador : MonoBehaviour, IMatavel, ICuravel
{
    [SerializeField] private LayerMask MascaraChao;
    [SerializeField] private GameObject TextoGameOver;
    [SerializeField] private AudioClip SomDeDano;
    [SerializeField] private Status statusJogador;
    [SerializeField] private UnityEvent AoMorrer;
    [SerializeField] private AoMudarVida AoMudarVida;

    private Vector3 direcao;
    private MovimentoJogador meuMovimentoJogador;
    private AnimacaoPersonagem animacaoJogador;
    private Pontuacao pontuacao;
    private string caminhoArquivo;

    private void Awake()
    {
        meuMovimentoJogador = GetComponent<MovimentoJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
    }

    private void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();

        if(statusJogador.Vida == 0)
        {
            statusJogador.Reiniciar();
        }

        AoMudarVida.Invoke(statusJogador.Vida);
    }

    private void Update()
    {
        animacaoJogador.Movimentar(this.meuMovimentoJogador.Direcao.magnitude);
    }

    private void FixedUpdate()
    {
        meuMovimentoJogador.Movimentar(statusJogador.Velocidade);

        meuMovimentoJogador.RotacaoJogador();
    }

    public void TomarDano (int dano)
    {
        statusJogador.Vida -= dano;
        AoMudarVida.Invoke(statusJogador.Vida);
        ControlaAudio.instancia.PlayOneShot(SomDeDano);
        if(statusJogador.Vida <= 0)
        {
            Morrer();
        }        
    }

    public void Morrer ()
    {
        statusJogador.Reiniciar();
        pontuacao.AtualizarTempoSobrevivencia();
        AoMorrer.Invoke();
    }

    public void CurarVida (int quantidadeDeCura)
    {
        statusJogador.Vida += quantidadeDeCura;
        if(statusJogador.Vida > statusJogador.VidaInicial)
        {
            statusJogador.Vida = statusJogador.VidaInicial;
        }
        AoMudarVida.Invoke(statusJogador.Vida);
    }
}

[Serializable]
public class AoMudarVida : UnityEvent<int> { }
