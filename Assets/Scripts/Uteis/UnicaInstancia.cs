using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    private void Start()
    {
        GameObject[] outros = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < outros.Length; i++)
        {
            GameObject outro = outros[i];

            if (outro != gameObject)
            {
                Destroy(outro);
            }
        }
    }
}
