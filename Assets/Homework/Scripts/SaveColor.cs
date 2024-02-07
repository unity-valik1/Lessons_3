using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SaveColor : MonoBehaviour
{
    [SerializeField] private Planes planes;
    [SerializeField] private ColorPlane colorPlane;

    private int color;//Цвет коробля

    private void Start()
    {
        if (PlayerPrefs.HasKey("color0"))
        {
            color = PlayerPrefs.GetInt("color0");
            colorPlane.AirplaneColor(color);
        }
        else
        {
            colorPlane.AirplaneColor(4);
        }
    }
    public void GetColor(int index)
    {
        if (index == 0)
        {
            if (PlayerPrefs.HasKey("color0"))
            {
                color = PlayerPrefs.GetInt("color0");
                colorPlane.AirplaneColor(color);
            }
            else
            {
                colorPlane.AirplaneColor(4);
            }
        }
        else if (index == 1)
        {
            if (PlayerPrefs.HasKey("color1"))
            {
                color = PlayerPrefs.GetInt("color1");
                colorPlane.AirplaneColor(color);
            }
            else
            {
                colorPlane.AirplaneColor(4);
            }
        }
        else if (index == 2)
        {
            if (PlayerPrefs.HasKey("color2"))
            {
                color = PlayerPrefs.GetInt("color2");
                colorPlane.AirplaneColor(color);
            }
            else
            {
                colorPlane.AirplaneColor(4);
            }
        }
        else if (index == 3)
        {
            if (PlayerPrefs.HasKey("color3"))
            {
                color = PlayerPrefs.GetInt("color3");
                colorPlane.AirplaneColor(color);
            }
            else
            {
                colorPlane.AirplaneColor(4);
            }
        }
    }
    public void SaveColors(int index)
    {
        color = index;
        if (planes.numberPlace == 0)
        {
            PlayerPrefs.SetInt("color0", color);
            PlayerPrefs.Save();
        }
        else if (planes.numberPlace == 1)
        {
            PlayerPrefs.SetInt("color1", color);
            PlayerPrefs.Save();
        }
        else if (planes.numberPlace == 2)
        {
            PlayerPrefs.SetInt("color2", color);
            PlayerPrefs.Save();
        }
        else if (planes.numberPlace == 3)
        {
            PlayerPrefs.SetInt("color3", color);
            PlayerPrefs.Save();
        }
    }
}
