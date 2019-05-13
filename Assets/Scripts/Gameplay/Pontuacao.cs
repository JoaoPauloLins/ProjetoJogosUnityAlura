using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    private int pontuacao;
    private float tempoSobrevivencia;

    private void Start()
    {
        tempoSobrevivencia = 0;
    }

    public void AtualizarPontos()
    {
        pontuacao++;
    }

    public void AtualizarTempoSobrevivencia()
    {
        tempoSobrevivencia += Time.timeSinceLevelLoad;
    }

    public int GetPontuacao()
    {
        return pontuacao;
    }

    public float GetTempoSobrevivencia()
    {
        return tempoSobrevivencia;
    }
}
