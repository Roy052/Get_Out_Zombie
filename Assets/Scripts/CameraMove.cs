using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : Singleton
{
    private Vector3 Origin;
    private Vector3 StartPos;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    private bool drag = false;
    float delay = 0f;
    float time = 1f;
    

    private void Start()
    {
        Vector3 zombiePos = zombieAI.transform.position;
        zombiePos.z = -10f;
        ResetCamera = zombiePos;
    }


    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if(drag == false)
            {
                drag = true;
                Origin = Camera.main.transform.position;
                StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
                Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - StartPos;

        }
        else
        {
            drag = false;
            Difference = Vector3.zero;
            Origin = Vector3.zero;
        }

        if (drag && Difference.magnitude > 2f)
        {
            Camera.main.transform.position = Origin - Difference * 0.5f;
        }

        if (Input.GetMouseButton(1))
            Camera.main.transform.position = ResetCamera;

    }
}
