using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OverlayController : MonoBehaviour
{
    [SerializeField]
    WeatherController weatherController;
    [SerializeField]
    GameObject panel;   
    Image img;

    [SerializeField]
    byte alpha = 0x80;

    // Start is called before the first frame update
    void Start()
    {
        img = panel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (weatherController.GetCurrentSeason())
        {
            case "Summer":
                img.color = new Color32(0xF9, 0xD6, 0x2E, alpha);
                break;
            case "Winter":
                img.color = new Color32(0x00, 0xE4, 0xFF, alpha);
                break;
            case "Spring":
                img.color = new Color32(0x5E, 0x8D, 0x5A, alpha);
                break;
            case "Autumn":
                img.color = new Color32(0xF4, 0x7B, 0x20, alpha);
                break;
            default:
                break;
        }
        Debug.Log(img.color);
    }
}
