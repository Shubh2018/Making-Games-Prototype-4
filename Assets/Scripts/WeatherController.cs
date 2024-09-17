using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{

    enum Seasons
    {
        Summer,
        Autumn,
        Winter,
        Spring
    }

    private Seasons currentSeason = Seasons.Summer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ChangeWeather()
    {
        Seasons[] values = (Seasons[]) Enum.GetValues(typeof(Seasons));
        int index = Array.FindIndex<Seasons>(values, (e) => e.ToString() == currentSeason.ToString());
        List<Seasons> valuesList = new List<Seasons>(values);
        valuesList.RemoveAt(index);
        currentSeason = valuesList[UnityEngine.Random.Range(0, valuesList.Count)];
        Debug.Log("Season is now: " + currentSeason);
    }

    public string GetCurrentSeason()
    {
        return currentSeason.ToString();
    }
}
