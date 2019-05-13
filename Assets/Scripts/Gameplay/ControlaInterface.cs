using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    [SerializeField] private Slider SliderVidaJogador;
    [SerializeField] private Text TextoQuantidadeDeZumbisMortos;
    [SerializeField] private Text TextoChefeAparece;

    private Pontuacao pontuacao;
    

	private void Start ()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        AtualizarQuantidadeDeZumbisMortos();

        Time.timeScale = 1;
    }

    public void AtualizarSliderVidaJogador (int vida)
    {
        SliderVidaJogador.value = vida;
    }

    public void AtualizarQuantidadeDeZumbisMortos ()
    {
        TextoQuantidadeDeZumbisMortos.text = string.Format("x {0}", pontuacao.GetPontuacao());
    }

    public void AparecerTextoChefeCriado ()
    {
        StartCoroutine(DesaparecerTexto(2, TextoChefeAparece));
    }

    IEnumerator DesaparecerTexto (float tempoDeSumico, Text textoParaSumir)
    {
        textoParaSumir.gameObject.SetActive(true);
        Color corTexto = textoParaSumir.color;
        corTexto.a = 1;
        textoParaSumir.color = corTexto;
        yield return new WaitForSeconds(1);
        float contador = 0;
        while (textoParaSumir.color.a > 0)
        {
            contador += Time.deltaTime / tempoDeSumico;
            corTexto.a = Mathf.Lerp(1, 0, contador);
            textoParaSumir.color = corTexto;
            if(textoParaSumir.color.a <= 0)
            {
                textoParaSumir.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
