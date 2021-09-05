using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reset moveDelta
        moveDelta = Vector2.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Debug.Log(x);
        Debug.Log(y);

        moveDelta = new Vector2(x, y);

        // Swap Dirrection, left or right

        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector2(1,1);
        }
        else if (moveDelta.x<0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Make this thing move!
            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            //Make this thing move!
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);
        }


    }

}
