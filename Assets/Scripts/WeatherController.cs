using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            WeatherStates[] values = (WeatherStates[]) Enum.GetValues(typeof(WeatherStates));
            int index = Array.FindIndex(values, (e) => e == GameManager.Instance.Weather);
            List<WeatherStates> valuesList = new List<WeatherStates>(values);
            valuesList.RemoveAt(index);
            GameManager.Instance.Weather = valuesList[UnityEngine.Random.Range(0, valuesList.Count)];
            Debug.Log("Season is now: " + GameManager.Instance.Weather.ToString());
        }
    }
}
