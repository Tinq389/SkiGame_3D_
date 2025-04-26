using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();

    private void Awake()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            float savedTime = PlayerPrefs.GetFloat("time" + i, 9999999);
            if (savedTime < 9999999)
            {
                bestTimes.Add(savedTime);
            }
        }
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if(i<bestTimes.Count)
                PlayerPrefs.SetFloat("time"+i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }
    public List<float> GetBestTimes()
    {
        return new List<float>(bestTimes);
    }
}
