using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour, IPlaneItemActions
{
    private Vector2 touchStartPos; // ��������� ������� �������.
    private Quaternion startRotation; // ��������� �������.

    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;

    public float rotationSpeed = 2.0f; // �������� �������� �������.
    private void Start()
    {
        startRotation = transform.rotation;
    }
    public void OnDrag(Vector3 pos)
    {
        // ���������, ���� �� ������� �� ������.
        if (Input.touchCount > 0)
        {
            // �������� ������ �������.
            Touch touch = Input.GetTouch(0);

            // ��������� ��������� �������.
            if (touch.phase == TouchPhase.Began)
            {
                // ���������� ��������� ������� �������.
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // ��������� ������� ����� ������� � ��������� �������� �������.
                Vector2 touchDelta = touch.position - touchStartPos;

                // �������� ������� ������� �� ��� Y �� ������ �������� ������.
                float rotationAmount = touchDelta.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, -rotationAmount);

                // ��������� ��������� ������� �������.
                touchStartPos = touch.position;
            }
        }

    }
    public void OnUp(PlaneController planeController)
    {
        startRotation = transform.rotation;
    }


    private void OnMouseDown()
    {
        mouseStartPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        mouseEndPos = Input.mousePosition;

        // ��������� ������� � ������� ���� ����� ��������� � ������� ��������.
        Vector3 mouseDelta = mouseEndPos - mouseStartPos;

        // �������� ���� �������� ������� �� ��� Y �� ������ ������� � ������� ����.
        float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, -rotationAmount);

        // ��������� ��������� ������� ���� ��� ���������� �����.
        mouseStartPos = mouseEndPos;
    }
    private void OnMouseUp()
    {
        transform.rotation = startRotation;
    }
}
