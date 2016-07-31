using UnityEngine;
using System.Collections;

public class CarBehaviuor : MonoBehaviour {
    private Rigidbody2D rb;
    public string direction;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate ()
    {
        if (direction != null)
        {
            if (direction.Equals("Left"))
                rb.velocity = Vector2.left;
            else rb.velocity = Vector2.right;
        }
        else Destroy(this.gameObject);
    }
}
