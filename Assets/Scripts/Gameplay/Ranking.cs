using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string NOME_DO_ARQUIVO = "Ranking.json";

    [SerializeField] private List<Colocado> listaColocados;

    private string caminhoArquivo;

    private void Awake()
    {
        caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);
        if (File.Exists(caminhoArquivo))
        {
            string textoJson = File.ReadAllText(caminhoArquivo);
            JsonUtility.FromJsonOverwrite(textoJson, this);
        }
        else
        {
            listaColocados = new List<Colocado>();
        }
    }

    private void SalvarRanking()
    {
        string textoJson = JsonUtility.ToJson(this, true);
        File.WriteAllText(caminhoArquivo, textoJson);
    }

    public string AdicionarPontuacao(string nome, int pontos, float tempoSobrevivencia)
    {
        string id = Guid.NewGuid().ToString();
        Colocado novoColocado = new Colocado(nome, pontos, tempoSobrevivencia, id);
        listaColocados.Add(novoColocado);
        listaColocados.Sort();
        SalvarRanking();
        return id;
    }

    public void AlterarNome(string novoNome, string id)
    {
        foreach (Colocado colocado in listaColocados)
        {
            if (colocado.id == id)
            {
                colocado.nome = novoNome;
                break;
            }
        }
        SalvarRanking();
    }

    public int Quantidade()
    {
        return listaColocados.Count;
    }

    public ReadOnlyCollection<Colocado> GetColocados()
    {
        return listaColocados.AsReadOnly();
    }
}

[Serializable]
public class Colocado : IComparable
{
    public string nome;
    public int pontos;
    public float tempoSobrevivencia;
    public string id;

    public Colocado(string nome, int pontos, float tempoSobrevivencia, string id)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.tempoSobrevivencia = tempoSobrevivencia;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        var outroObjeto = obj as Colocado;
        return outroObjeto.pontos.CompareTo(this.pontos);
    }
}
