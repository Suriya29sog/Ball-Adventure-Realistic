using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Require AuioSource
[RequireComponent(typeof(AudioSource))]
public abstract class Item : MonoBehaviour
{
    protected AudioSource audioSource;

    protected void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    protected abstract void OnTriggerEnter(Collider collider);

}
