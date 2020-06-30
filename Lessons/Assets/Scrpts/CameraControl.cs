using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform target; //за кем следить 
    [SerializeField] private float smoothSpeed; // скорость отставания
    [SerializeField] private float MinX, MinY, MaxX, MaxY; //координаты предела

    private void Start() //фуннкция выполняет дейсвие 1 раз при запуске
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()//выполняе дейсвие после каждого кадра
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -4.77f), smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX),
                                         Mathf.Clamp(transform.position.y, MinY, MaxY),
                                         transform.position.z);
    }
}
