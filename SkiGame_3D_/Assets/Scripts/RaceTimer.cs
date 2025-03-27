using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private float penaltyTime = 1;
    private bool timerRunning = false;
    private float raceTime = 0;
    

    private void Update()
    {
        if (timerRunning)
            raceTime += Time.deltaTime;
    }

    private void OnEnable()
    {
        PlayerEvents.raceStart += StartRace;
        PlayerEvents.raceEnd += FinishRace;
        PlayerEvents.racePenalty += Penalty;
    }

    private void OnDisable()
    {
        PlayerEvents.raceStart  -= StartRace;
        PlayerEvents.raceEnd -= FinishRace;
        PlayerEvents.racePenalty -= Penalty;
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("Penalty recieved!");
    }
    private void StartRace()
    {
        timerRunning = true;
        Debug.Log("Race started!");
    }
    
    private void FinishRace()
    {
        timerRunning = false;
        Debug.Log("Race ended!");
    }
}
