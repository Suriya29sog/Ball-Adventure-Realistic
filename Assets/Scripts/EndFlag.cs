using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : Item
{
    [SerializeField] private string loadSceneName;

    protected override void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            StartCoroutine(WaitForNextScene());
        }
    }

    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(loadSceneName);
    }

}
