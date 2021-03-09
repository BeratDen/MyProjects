using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereControlScript : MonoBehaviour
{
    public float sensivity = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        RotarePlayerBody();
    }
    private float rotateY = 0;
    private float rotateX = 0;
    private void RotarePlayerBody()
    {
        rotateY += sensivity * Input.GetAxis("Mouse Y") * -1;
        rotateX += sensivity * Input.GetAxis("Mouse X");
        rotateY = Mathf.Clamp(rotateY, -70, 70);
        transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
    }
}
