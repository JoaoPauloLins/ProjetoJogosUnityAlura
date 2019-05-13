using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject particulas;
    [SerializeField] private int pontuacaoAbrirPortal;
    [SerializeField] private UnityEvent AoEntrarNoPortal;

    private Pontuacao pontuacao;
    private bool portalAberto;

    private void Start()
    {
        particulas.SetActive(false);

        pontuacao = FindObjectOfType<Pontuacao>();

        portalAberto = false;
    }

    private void Update()
    {
        if (pontuacao.GetPontuacao() >= pontuacaoAbrirPortal)
        {
            portalAberto = true;
            particulas.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (portalAberto && collision.gameObject.CompareTag("Jogador"))
        {
            pontuacao.AtualizarTempoSobrevivencia();
            AoEntrarNoPortal.Invoke();
        }
    }
}
