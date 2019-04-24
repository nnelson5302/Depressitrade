using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakeButton : MonoBehaviour
{

    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    bool clicked;

    void Start()
    {
        definedButton = this.gameObject;
        clicked = false;
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (clicked == false)
       {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    OnClick.Invoke();
                }
               clicked = true;
            }
       }
    }
}