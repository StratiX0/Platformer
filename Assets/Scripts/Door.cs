using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] int startPoint;

    public Transform[] points;

    private int i; // index of the current point array

    [SerializeField] float openingSpeed;

    public bool openDoor;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckDoorState();
    }

    private void CheckDoorState()
    {
        if (openDoor)
        {
            i = 1;
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, openingSpeed * Time.deltaTime);
        }
        else
        {
            i = 0;
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, openingSpeed * Time.deltaTime);
        }
    }
}
