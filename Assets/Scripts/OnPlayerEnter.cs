using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerEnter : MonoBehaviour
{
    public bool isUsed;

    public event Action OnPlayerEnterEvent;


    //TODO:TestToDo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isUsed) return;

            OnPlayerEnterEvent?.Invoke();
        }
    }
}
