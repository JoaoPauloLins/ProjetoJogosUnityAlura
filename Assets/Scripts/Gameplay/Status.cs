using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectStatus", menuName = "Status", order = 1)]
public class Status : ScriptableObject
{
    [NonSerialized] public int Vida;

    public int VidaInicial = 100;
    public float Velocidade = 5;

    public void Reiniciar()
    {
        Vida = VidaInicial;
    }
}
