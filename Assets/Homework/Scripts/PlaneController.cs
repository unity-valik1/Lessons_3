using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour, IPlaneItemActions
{
    private Vector2 touchStartPos; // Начальная позиция касания.
    private Quaternion startRotation; // Стартовая позиция.

    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;

    public float rotationSpeed = 2.0f; // Скорость вращения объекта.
    private void Start()
    {
        startRotation = transform.rotation;
    }
    public void OnDrag(Vector3 pos)
    {
        // Проверяем, есть ли касания на экране.
        if (Input.touchCount > 0)
        {
            // Получаем первое касание.
            Touch touch = Input.GetTouch(0);

            // Проверяем состояние касания.
            if (touch.phase == TouchPhase.Began)
            {
                // Запоминаем начальную позицию касания.
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Вычисляем разницу между текущей и начальной позицией касания.
                Vector2 touchDelta = touch.position - touchStartPos;

                // Изменяем поворот объекта по оси Y на основе движения пальца.
                float rotationAmount = touchDelta.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, -rotationAmount);

                // Обновляем начальную позицию касания.
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

        // Вычисляем разницу в позиции мыши между начальной и текущей позицией.
        Vector3 mouseDelta = mouseEndPos - mouseStartPos;

        // Изменяем угол поворота объекта по оси Y на основе разницы в позиции мыши.
        float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, -rotationAmount);

        // Обновляем начальную позицию мыши для следующего кадра.
        mouseStartPos = mouseEndPos;
    }
    private void OnMouseUp()
    {
        transform.rotation = startRotation;
    }
}
