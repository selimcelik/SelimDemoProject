using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSwiperControl : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float throwForseInXandY = 0.1f;

    [SerializeField]
    float throwForseInZ = 1f;

    Rigidbody rb;
    private bool blueswipeStart = false;
    public static bool blueswipCreator=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        blueswipCreator = false;
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "blue")
                {
                    Debug.Log("blue");
                    blueswipeStart = true;
                    var green = GameObject.FindGameObjectWithTag("green");
                    greenSwiperControl greenSwipe = green.GetComponent<greenSwiperControl>();
                    greenSwipe.enabled = false;
                }

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && blueswipeStart)
        {

            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && blueswipeStart)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwForseInXandY, -direction.y * throwForseInXandY, throwForseInZ / timeInterval);
            var green = GameObject.FindGameObjectWithTag("green");
            greenSwiperControl greenSwipe = green.GetComponent<greenSwiperControl>();
            greenSwipe.enabled = true;
            blueswipeStart = false;
            Invoke("blueswipCreate", 1);
            Destroy(gameObject, 7f);

        }

    }

    private void blueswipCreate()
    {
        blueswipCreator = true;
    }


}
