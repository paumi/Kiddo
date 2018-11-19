using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement_Pau : MonoBehaviour {

    public Transform target;
    public float softness;
    private Vector3 desfase;

    // Use this for initialization
    void Start () {
        softness = 5f;
        desfase = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + desfase;
        transform.position = Vector3.Lerp(transform.position, targetPosition, softness * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 3.5f, -10f);

    }
}
