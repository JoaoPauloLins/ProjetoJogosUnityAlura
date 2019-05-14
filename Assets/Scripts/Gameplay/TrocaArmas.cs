using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrocaArmas : MonoBehaviour
{
    [SerializeField] private List<Arma> armas;
    [SerializeField] private AoTrocarArma aoTrocarArma;

    private int indexArmaAtiva;

    private void Start()
    {
        indexArmaAtiva = 0;

        if (armas.Count > 0)
        {
            foreach (Arma arma in armas)
            {
                arma.gameObject.SetActive(false);
            }

            armas[indexArmaAtiva].gameObject.SetActive(true);
            aoTrocarArma.Invoke(armas[indexArmaAtiva].GetTaxaDisparo());
        }
    }

    public void TrocarArma()
    {
        if (armas.Count > 0)
        {
            armas[indexArmaAtiva].gameObject.SetActive(false);

            indexArmaAtiva = indexArmaAtiva == armas.Count - 1 ? 0 : indexArmaAtiva + 1;

            armas[indexArmaAtiva].gameObject.SetActive(true);

            aoTrocarArma.Invoke(armas[indexArmaAtiva].GetTaxaDisparo());
        }
    }

    public Arma GetArmaAtiva()
    {
        return armas[indexArmaAtiva];
    }
}

[Serializable]
public class AoTrocarArma : UnityEvent<float> { }
