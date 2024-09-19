using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OverlayController : MonoBehaviour
{
    private SpriteRenderer overlay;

    [SerializeField]
    byte alpha = 0x80;

    // Start is called before the first frame update
    void Start()
    {
        overlay = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        WeatherStates season = GameManager.Instance.Weather;
        switch (season.ToString())
        {
            case "Summer":
                overlay.color = new Color32(0xF9, 0xD6, 0x2E, alpha);
                break;
            case "Winter":
                overlay.color = new Color32(0x00, 0xE4, 0xFF, alpha);
                break;
            case "Spring":
                overlay.color = new Color32(0x5E, 0x8D, 0x5A, alpha);
                break;
            case "Autumn":
                overlay.color = new Color32(0xF4, 0x7B, 0x20, alpha);
                break;
            default:
                break;
        }
        Debug.Log(overlay.color);
    }
}
