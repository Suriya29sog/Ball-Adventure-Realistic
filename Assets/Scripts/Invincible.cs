using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Item
{
    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Ball ball = collider.gameObject.GetComponent<Ball>();

            ball.Invulnurable = true;

            //Change material
            ball.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
            ball.Material = gameObject.GetComponent<Renderer>().material;

            audioSource.Play();

            //disable gameobject
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            //destroy when clip ended
            Destroy(gameObject, audioSource.clip.length);
        }
    }

}
