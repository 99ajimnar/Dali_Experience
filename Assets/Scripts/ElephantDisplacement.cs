using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantDisplacement : MonoBehaviour
{
    [SerializeField] private GameObject elephant;
    [SerializeField] private Vector3 finalPosition;
    private Vector3 startPosition;
    [SerializeField] private float speed = 0.01f;

    private void Start()
    {
        startPosition = elephant.transform.position;
    }
    void Update()
    {
        if (elephant.transform.position != finalPosition)
        {
            elephant.transform.position = Vector3.MoveTowards(elephant.transform.position, finalPosition, speed);
        }
        else
        {
            elephant.transform.position = startPosition;
        }
    }
}
