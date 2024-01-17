using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public static Action gameOver;
    public static PlayerMovement Instance;

    Vector3 targetPosition;
    [SerializeField] private float speed = 5f;
    bool gameStarted, collided, gamestarted;

    Rigidbody2D playerRigidBody;
    Vector2 movePosition;



    private void Awake()
    {
        Instance = this;
        movePosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.gameOver += GameFinished;
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void GameFinished()
    {
        Destroy(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        /* if (!gameStarted)
             return;*/

        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(target.x, target.y);

           /* if (targetPosition.x > 7.5f)
                targetPosition.x = 7.5f;
            if (targetPosition.x < -7.5f)
                targetPosition.x = -7.5f;
            if (targetPosition.y > 3.5f)
                targetPosition.y = 3.5f;
            if (targetPosition.y < -3.5f)
                targetPosition.y = -3.5f;*/

            //StartCoroutine(MoveObject(targetPosition));
        }
    }

    //Moving player on click

    private void FixedUpdate()
    {
        if (!gameStarted)
            return;

        /* while (Vector2.Distance(transform.position, targetPosition) > 0.1f *//*&& !collided*//*)
         {*/
        //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
        //new Vector2(target.x, target.y), Time.deltaTime * speed);
        playerRigidBody.MovePosition(Vector2.MoveTowards(playerRigidBody.transform.position, targetPosition, speed * Time.deltaTime));

        //}
        collided = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;

        if (collision.collider.CompareTag("Enemy"))
        {
            gameOver();
        }
    }

}
