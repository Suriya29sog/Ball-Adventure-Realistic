using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 160;
    [SerializeField] private float jumpPower = 9;
    private float horizontalInput;
    private bool isGround;
    private float ballSize;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isGround = true;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ballSize = transform.localScale.x;

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, ballSize/4, new Vector3(0, -ballSize/2, 0), out hit, ballSize/2))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        //move ball
        rigidBody.AddForce(speed * Time.deltaTime * new Vector3(horizontalInput, 0, 0));

        //jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            rigidBody.AddForce(jumpPower * new Vector3(0, 1, 0), ForceMode.Impulse);
            audioSource.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position - new Vector3(0, ballSize/2, 0), ballSize/4);
    }
}
