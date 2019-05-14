using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaBotao : MonoBehaviour
{
    [SerializeField] private GameObject botao;
    [SerializeField] private KeyCode teclaCorrespondente;
    [SerializeField] private UnityEvent aoTocar; 

    private void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        botao.SetActive(false);
        #endif

        #if UNITY_ANDROID || UNITY_IOS
        botao.SetActive(true);
        #endif
    }

    private void Update()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(teclaCorrespondente))
        {
            aoTocar.Invoke();
        }
        #endif
    }
}
