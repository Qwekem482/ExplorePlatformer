using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform follow;


    void Update()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y, -10);
    }
}
