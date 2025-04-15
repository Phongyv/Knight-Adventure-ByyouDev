using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool moveRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (moveRight) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale =new Vector3(1,1, 1);
            if (transform.position.x >= rightBound) { 
                moveRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1,1, 1);
            if (transform.position.x <= leftBound)
            {
                moveRight = true;
            }
        }
    }
}
