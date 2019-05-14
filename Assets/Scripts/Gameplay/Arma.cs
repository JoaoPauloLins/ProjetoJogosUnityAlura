using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private float taxaDisparo;

    public float GetTaxaDisparo()
    {
        return taxaDisparo;
    }
}
