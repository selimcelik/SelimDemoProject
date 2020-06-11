using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenSwiperControl : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float throwForseInXandY = 0.5f;

    [SerializeField]
    float throwForseInZ = 10f;

    Rigidbody rb;
    private bool swipeStart = false;

    public static bool greenswipCreator = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        greenswipCreator = false;
        if (Input.touchCount>0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.tag == "green")
                {
                    Debug.Log("green");
                    swipeStart = true;
                    var blue = GameObject.FindGameObjectWithTag("blue");
                    blueSwiperControl blueSwipe = blue.GetComponent<blueSwiperControl>();
                    blueSwipe.enabled = false;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && swipeStart)
        {

            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && swipeStart)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(-direction.x * throwForseInXandY, -direction.y * throwForseInXandY, throwForseInZ / timeInterval);
            var blue = GameObject.FindGameObjectWithTag("blue");
            blueSwiperControl blueSwipe = blue.GetComponent<blueSwiperControl>();
            blueSwipe.enabled = true;
            swipeStart = false;
            Invoke("greenswipCreate", 1);
            Destroy(gameObject, 7f);

        }
    }

    private void greenswipCreate()
    {
        greenswipCreator = true;
    }
}
