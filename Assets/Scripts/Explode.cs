using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Require AuioSource
[RequireComponent(typeof(AudioSource))]
public class Explode : MonoBehaviour
{
    [SerializeField] private float timeToExplode = 3;
    [SerializeField] private float explodeForce = 1000;
    [SerializeField] private float explodeRadius = 5;
    [SerializeField] private GameObject explosionPrefab;

    private float timeElapsed;
    private bool isExplode;
    private Rigidbody connectedBody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeToExplode && !isExplode)
        {
            isExplode = true;
            Collider[] gameObjectInRange = Physics.OverlapSphere(transform.position, explodeRadius);

            foreach(Collider hit in gameObjectInRange)
            {
                Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                Ball ball = hit.gameObject.GetComponent<Ball>();

                if (rigidbody != null && hit.gameObject.CompareTag("Player"))
                {
                    if (ball != null && ball.Material != ball.DefaultMaterial)
                        continue;

                    rigidbody.AddExplosionForce(explodeForce, transform.position, explodeRadius);
                }
            }

            audioSource.Play();

            //disable gameobject
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            //instantiate explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //destroy when clip ended
            Destroy(gameObject, audioSource.clip.length);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (connectedBody == null && collision.rigidbody)
        {
            gameObject.AddComponent<FixedJoint>();
            FixedJoint fixedJoint = gameObject.GetComponent<FixedJoint>();
            connectedBody = collision.rigidbody;
            fixedJoint.connectedBody = collision.rigidbody;
        }
    }

}
