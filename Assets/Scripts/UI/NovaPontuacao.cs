using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField] private Text textoPontuacao;
    [SerializeField] private Text textoTempoSobrevivencia;
    [SerializeField] private Ranking ranking;

    private Pontuacao pontuacao;
    private string id;
    private int pontos;
    private float tempoSobrevivencia;

    private void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        
        if (pontuacao != null)
        {
            pontos = pontuacao.GetPontuacao();
            tempoSobrevivencia = pontuacao.GetTempoSobrevivencia();
        }
        textoPontuacao.text = pontos.ToString();
        int minutos = (int)(tempoSobrevivencia / 60);
        int segundos = (int)(tempoSobrevivencia % 60);
        textoTempoSobrevivencia.text = $"Você sobreviveu por {minutos}min e {segundos}s";
        id = ranking.AdicionarPontuacao("Nome", pontos, tempoSobrevivencia);
    }

    public void AlterarNome(string nome)
    {
        ranking.AlterarNome(nome, id);
    }
}
