using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    Vector3 direction = Vector3.right;
    int currDirection = 0;
    [SerializeField] float speed = 2f;
    int newDir = 0;
    bool inCollision, gameStarted;


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
        /*if (!gameStarted)
            return;*/
        transform.position += direction * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        inCollision = true;

        Collided();
        StartCoroutine(CheckEdge());
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        inCollision = false;
    }

    void Collided()
    {
        newDir = Random.Range(0, 4);

        while (newDir == currDirection)
        {
            newDir = Random.Range(0, 4);
        }

        Debug.Log("newDir = " + newDir);
        GetDirection(newDir);

    }

    //Calculating direction based on collision
    void GetDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                direction = Vector3.right;
                currDirection = 0;
                break;
            case 1:
                direction = Vector3.left;
                currDirection = 1;
                break;
            case 2:
                direction = Vector3.up;
                currDirection = 2;
                break;
            case 3:
                direction = Vector3.down;
                currDirection = 3;
                break;

            default:
                Debug.Log("Invalid direction");
                break;
        }
    }

    IEnumerator CheckEdge()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("inCollision = " + inCollision);

        if (inCollision)
            Collided();
    }

}
