using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;    // Takip edilecek nesne
    [SerializeField] Vector3 offset;  // Ne kadar uzaklıktan takip edecek 

    [SerializeField] float lerpValue;   // Takip etme yumuşaklığı

    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;  // Hedef obje ile arasındaki takip mesafesini toplar
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);   // Kamera hareket eder
    }
}
