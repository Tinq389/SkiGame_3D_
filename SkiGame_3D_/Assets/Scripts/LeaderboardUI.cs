using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private Leaderboard leaderboard;
    [SerializeField] private GameObject leaderboardContainer;
    [SerializeField] private List<TextMeshProUGUI> leaderboardEntries;
    public void UpdateLeaderboard()
    {
        leaderboardContainer.gameObject.SetActive(true);

        List<float> bestTimes = leaderboard.GetBestTimes();
        Debug.Log("Best times count: " + bestTimes.Count); 

        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            if (i < bestTimes.Count)
            {
                Debug.Log($"Setting entry {i}: {bestTimes[i]}");
                leaderboardEntries[i].text = $"{i + 1}. {FormatTime(bestTimes[i])}";
            }
            else
            {
                leaderboardEntries[i].text = $"{i + 1}. ---";
            }
        }
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}