using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI massText;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (score != null)
            scoreText.text = "Score: " + score.score;

        if (ballRigidbody != null)
            massText.text = "Mass: " + ballRigidbody.mass;
    }


    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
    }

}
