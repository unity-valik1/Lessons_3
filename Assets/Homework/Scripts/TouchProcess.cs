using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchProcess : MonoBehaviour, 
                                          IDragHandler,
                                          IEndDragHandler
{
    [SerializeField] private PlaneController planeController;
    private IPlaneItemActions view;

    private void Start()
    {
        view = GetComponent<PlaneController>();
        planeController = GetComponent<PlaneController>();
        Init(planeController, view);
    }
    public void Init(PlaneController planeController1, IPlaneItemActions listener)
    {

        planeController = planeController1;
        view = listener;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        view.OnDrag(Input.mousePosition);
        Debug.Log("Drag");
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        view.OnUp(planeController);
        Debug.Log("Up");
    }
}
