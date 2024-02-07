using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour, IPlaneItemActions
{
    private Vector2 touchStartPos; //Начальная позиция касания

    private Vector3 mouseStartPos;//Начальная позиция
    private Vector3 mouseEndPos;//Конечная позиция

    private Quaternion startRotation;//Стартовая позиция

    public float rotationSpeed = 2.0f;//Скорость вращения объекта

    private void Start()
    {
        startRotation = transform.rotation;
    }
    public void OnDrag(Vector3 pos)
    {
        //Проверяем, есть ли касания на экране
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);//Получаем первое касание

            //Проверяем состояние касания
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;//Запоминаем начальную позицию касания
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.position - touchStartPos;//Вычисляем разницу между текущей и начальной позицией касания

                float rotationAmount = touchDelta.x * rotationSpeed * Time.deltaTime;//Изменяем поворот объекта по оси Y на основе движения пальца
                transform.Rotate(Vector3.up, -rotationAmount);
       
                touchStartPos = touch.position;//Обновляем начальную позицию касания
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

        Vector3 mouseDelta = mouseEndPos - mouseStartPos;//Вычисляем разницу в позиции мыши между начальной и текущей позицией

        float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;//Изменяем угол поворота объекта по оси Y на основе разницы в позиции мыши
        transform.Rotate(Vector3.up, -rotationAmount);

        mouseStartPos = mouseEndPos;//Обновляем начальную позицию мыши для следующего кадра
    }
    private void OnMouseUp()
    {
        transform.rotation = startRotation;
    }
}
