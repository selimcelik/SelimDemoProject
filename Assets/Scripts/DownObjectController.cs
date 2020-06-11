using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObjectController : MonoBehaviour
{
    float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;
        Destroy(gameObject, 5);
    }
}
