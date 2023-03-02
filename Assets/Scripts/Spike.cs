using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] GameObject playerDeadParticle;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball.PowerUp && !ball.Invulnurable && ball.Material == ball.DefaultMaterial)
            {
                ball.PowerUp = false;
                ball.Invulnurable = true;
            }
            else if (!ball.Invulnurable)
            {
                audioSource.Play();
                Destroy(collision.gameObject);
                Instantiate(playerDeadParticle, transform.position, Quaternion.identity);
                StartCoroutine(WaitForReset());
            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
       OnCollisionEnter(collision);
    }


    IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(1.5f);
        score.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

