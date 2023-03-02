using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float existDration = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, existDration);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
