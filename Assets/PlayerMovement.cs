using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public static Action gameOver;
    public static PlayerMovement Instance;

    Vector3 targetPosition;
    [SerializeField] private float speed = 5f;
    bool gameStarted;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.gameOver += GameFinished;
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
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(target.x, target.y, transform.position.z);
            StartCoroutine(MoveObject(targetPosition));
        }
    }

    //Moving player on click
    IEnumerator MoveObject(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            gameOver();
        }
    }

}
