using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private bool powerUp;
    [SerializeField] private bool invulnurable;
    [SerializeField] private float invulDuration = 1.0f;
    [SerializeField] private float invincibleDuration = 4.0f;

    private float ballSize;
    private float elapsedTime;
    private Rigidbody rigidBody;

    public bool PowerUp 
    { 
        get { return powerUp; } 
        set { powerUp = value; }
    }

    public bool Invulnurable
    {
        get { return invulnurable; }
        set { invulnurable = value; }
    }

    public Material DefaultMaterial
    {
        get;
        private set;
    }

    public Material Material
    {
        get;
        set;
    }


    // Start is called before the first frame update
    void Start()
    {
        PowerUp = false;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        DefaultMaterial = gameObject.GetComponent<Renderer>().material;
        Material = DefaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {

        if (invulnurable && Material == DefaultMaterial)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > invulDuration)
            {
                elapsedTime = 0;
                invulnurable = false;
            }

        }
        else if (Material != DefaultMaterial)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > invincibleDuration)
            {
                elapsedTime = 0;
                invulnurable = false;
                Material = DefaultMaterial;
                gameObject.GetComponent<Renderer>().material = Material;
            }
        }


        if (PowerUp)
        {
            ballSize = 1.25f;
            rigidBody.mass = 1.25f;
        }
        else
        {
            ballSize = 1;
            rigidBody.mass = 1f;
        }

        transform.localScale = new Vector3(ballSize, ballSize, ballSize);
    }


}
