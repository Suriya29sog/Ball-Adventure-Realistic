using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerUp : Item
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Ball ball = collider.gameObject.GetComponent<Ball>();

            ball.PowerUp = true;

            audioSource.Play();

            //disable gameobject
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            //destroy when clip ended
            Destroy(gameObject, audioSource.clip.length);
        }

    }
}
