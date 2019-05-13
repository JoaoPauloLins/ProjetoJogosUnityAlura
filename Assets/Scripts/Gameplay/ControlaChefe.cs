using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ControlaChefe : MonoBehaviour, IMatavel, IReservavel
{
    [SerializeField] private CaixaDeSom AudioMorte;
    [SerializeField] private CaixaDeSom AudioAtaque;
    [SerializeField] private GameObject KitMedicoPrefab;
    [SerializeField] private Slider sliderVidaChefe;
    [SerializeField] private Image ImagelSlider;
    [SerializeField] private Color CorDaVidaMaxima, CorDaVidaMinima;
    [SerializeField] private GameObject ParticulaSangueZumbi;
    [SerializeField] private Status statusChefe;

    private Transform jogador;
    private NavMeshAgent agente;
    private AnimacaoPersonagem animacaoChefe;
    private MovimentoPersonagem movimentoChefe;
    private IReservaDeObjetos reserva;
    private int vidaAtual;

    private void Awake()
    {
        animacaoChefe = GetComponent<AnimacaoPersonagem>();
        movimentoChefe = GetComponent<MovimentoPersonagem>();
        agente = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        jogador = GameObject.FindWithTag("Jogador").transform;
        agente.speed = statusChefe.Velocidade;
        vidaAtual = statusChefe.VidaInicial;
        sliderVidaChefe.maxValue = statusChefe.VidaInicial;
        AtualizarInterface();
    }

    public void SetPosicao(Vector3 posicao)
    {
        this.transform.position = posicao;
        this.agente.Warp(posicao);
    }
    private void Update()
    {
        agente.SetDestination(jogador.position);
        animacaoChefe.Movimentar(agente.velocity.magnitude);

        if (agente.hasPath == true)
        {
            bool estouPertoDoJogador = agente.remainingDistance <= agente.stoppingDistance;

            if (estouPertoDoJogador)
            {
                animacaoChefe.Atacar(true);
                Vector3 direcao = jogador.position - transform.position;
                movimentoChefe.Rotacionar(direcao);
            }
            else
            {
                animacaoChefe.Atacar(false);
            }
        }
    }

    void AtacaJogador ()
    {
        AudioAtaque.Tocar();
        int dano = Random.Range(30, 40);
        jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        AtualizarInterface();
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void ParticulaSangue(Vector3 posicao, Quaternion rotacao)
    {
        Instantiate(ParticulaSangueZumbi, posicao, rotacao);
    }

    public void Morrer()
    {
        animacaoChefe.Morrer();
        movimentoChefe.Morrer();
        this.enabled = false;
        AudioMorte.Tocar();
        agente.enabled = false;
        Instantiate(KitMedicoPrefab, transform.position, Quaternion.identity);
        Invoke("VoltarParaReserva", 2);
    }

    private void VoltarParaReserva()
    {
        this.reserva.DevolverObjeto(this.gameObject);
    }

    void AtualizarInterface ()
    {
        sliderVidaChefe.value = vidaAtual;
        float porcentagemDaVida = (float)vidaAtual / statusChefe.VidaInicial;
        Color corDaVida = Color.Lerp(CorDaVidaMinima, CorDaVidaMaxima, porcentagemDaVida);
        ImagelSlider.color = corDaVida;
    }

    public void SetReserva(IReservaDeObjetos reserva)
    {
        this.reserva = reserva;
    }

    public void AoEntrarNaReserva()
    {
        this.gameObject.SetActive(false);
        this.movimentoChefe.Reiniciar();
        this.enabled = true;
        agente.enabled = true;
        vidaAtual = statusChefe.VidaInicial;
    }

    public void AoSairDaReserva()
    {
        this.gameObject.SetActive(true);
    }
}
