using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SmallPlane : MonoBehaviour
{
    [SerializeField] private RawImage imgPlane;

    [SerializeField] private Texture textures;

    [SerializeField] private GameObject cameraGameObject;

    private Quaternion up = Quaternion.Euler(90f, 90f, 0f);
    private Quaternion down = Quaternion.Euler(270f, 90f, 0f);
    private Quaternion face = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion left = Quaternion.Euler(0f, 90f, 0f);
    private Vector3 upV = new Vector3(0f, 10f, 0f);
    private Vector3 downV = new Vector3(0f, -10f, 0f);
    private Vector3 faceV = new Vector3(0f, 0f, -10f);
    private Vector3 leftV = new Vector3(-10f, 0f, 0f);

    void Start()
    {
        imgPlane.texture = textures;
    }
    public void AirplaneView(int index)
    {
        if (index == 0)
        {
            cameraGameObject.transform.position = upV;
            cameraGameObject.transform.rotation = up;
        }
        else if (index == 1)
        {
            cameraGameObject.transform.position = downV;
            cameraGameObject.transform.rotation = down;
        }
        else if (index == 2)
        {
            cameraGameObject.transform.position = faceV;
            cameraGameObject.transform.rotation = face;
        }
        else if (index == 3)
        {
            cameraGameObject.transform.position = leftV;
            cameraGameObject.transform.rotation = left;
        }
    }
}
