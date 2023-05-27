using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BeerPongController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawner;
    private GameObject currentBall;

void Start()
{
    SpawnBall();
}


void SpawnBall()
{
    currentBall = Instantiate(ballPrefab, ballSpawner.position, ballSpawner.rotation);
}

}