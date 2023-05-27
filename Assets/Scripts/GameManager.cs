using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BallController2 ballController;
    public CupDetector2[] cupDetectors;
    public int maxTries = 5;
    public Text statusText;

    private int tries;
    private Vector3 ballStartPosition;

    void Start()
    {
        ballStartPosition = ballController.ballPrefab.transform.position;
        tries = 0;
    }

    void Update()
    {
        foreach (CupDetector2 detector in cupDetectors)
        {
            if (detector.ballInCup)
            {
                statusText.text = "You Win!";
                ResetGame();
            }
        }

        if (ballController.ballPrefab.transform.position.y < -10 || tries >= maxTries)
        {
            ballController.ballPrefab.transform.position = ballStartPosition;
            ballController.ballPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ballController.ballPrefab.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            tries++;
        }
    }

    void ResetGame()
    {
        tries = 0;
        ballController.ballPrefab.transform.position = ballStartPosition;
        ballController.ballPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ballController.ballPrefab.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        foreach (CupDetector2 detector in cupDetectors)
        {
            detector.ballInCup = false;
        }
    }
}
