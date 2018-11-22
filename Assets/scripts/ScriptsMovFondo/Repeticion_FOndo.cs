using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeticion_FOndo : MonoBehaviour {

    public float speed;
    public float endX;
    public float startX;

    private void LateUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;

        }

    }

}
