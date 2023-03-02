using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] private Score score;
    [SerializeField] private int scorePoint;

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            score.score += scorePoint;

            audioSource.Play();

            //disable gameobject
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            Collider collide = gameObject.GetComponent<Collider>();
            renderer.enabled = false;
            collide.enabled = false;

            //destroy when clip ended
            Destroy(gameObject, audioSource.clip.length);
        }
    }

}
