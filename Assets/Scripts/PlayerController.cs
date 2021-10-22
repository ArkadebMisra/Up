using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float speed;
    public Vector2 screenBounds;
    public bool hitObstacle = false;
    //public Joystick joystick;

    //private variables
    private Rigidbody2D rigidbody;
    private float deltaX;
    private float objectWidth;
    public float movement = 0f;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                                                        Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchpos.x - transform.position.x;
                    break;

                case TouchPhase.Moved:
                    rigidbody.MovePosition(new Vector2(touchpos.x - deltaX, transform.position.y));
                    break;

                case TouchPhase.Ended:
                    rigidbody.velocity = Vector2.zero;
                    break;
            }
        }
        if (transform.position.x > screenBounds.x - objectWidth)
        {
            transform.position = new Vector2(screenBounds.x - objectWidth, transform.position.y);
        }
        else if (transform.position.x < -screenBounds.x + objectWidth)
        {
            transform.position = new Vector2(-screenBounds.x + objectWidth, transform.position.y);
        }

    }
}
