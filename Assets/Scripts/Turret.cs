using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform turretMuzzle;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private float range = 10;
    [SerializeField] private float shootPower = 900;
    [SerializeField] private float coolDown = 1;
    [SerializeField] private Transform bullet;

    [SerializeField] private bool isRangeDisplay;
    [SerializeField] private GameObject rangeDsplay;

    private Transform target;
    private bool isCooldown;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = range / 2;
        rangeDsplay.transform.localScale = new Vector3(range, range, range);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRangeDisplay)
        {
            gameObject.GetComponent<SphereCollider>().radius = range / 2;
            rangeDsplay.transform.localScale = new Vector3(range, range, range);
            rangeDsplay.SetActive(true);
        }
        else
            rangeDsplay.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            if (!isCooldown)
            {
                Shoot();
                StartCoroutine(CoolDown());
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            turretMuzzle.rotation = Quaternion.LookRotation(target.position - turretMuzzle.position);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            target = null;
    }


    IEnumerator CoolDown ()
    {
        isCooldown = true;

        yield return new WaitForSeconds(coolDown);

        isCooldown = false;

        if (target != null)
        {
            Shoot();
            StartCoroutine(CoolDown());
        }

    }

    private void Shoot()
    {
        //perform shooting
        Vector3 shootVector = (target.position - turretMuzzle.position).normalized;
        Transform spawnBullet = Instantiate(bullet, shootPosition.position, Quaternion.identity);
        spawnBullet.gameObject.GetComponent<Rigidbody>().AddForce(shootVector * shootPower);
        audioSource.Play();
    }


}
