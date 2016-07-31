using UnityEngine;
using System.Collections;

public class CarBehaviuor : MonoBehaviour {
    private Rigidbody2D rb;
    public string direction;
    public string type;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        switch (type)
        {
            case "Cheers":
                this.GetComponent<SpriteRenderer>().color = Color.red;
                
                break;
            case "Education":
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case "Safety":
                this.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            
        }

    }
    void FixedUpdate ()
    {
        if (direction != null)
        {
            if (direction.Equals("Left"))
                if(transform.position.x > -6f)
                    rb.velocity = Vector2.left;
                else Destroy(this.gameObject);
            else if (transform.position.x < 6f)
                rb.velocity = Vector2.right;
            else Destroy(this.gameObject); 
        }
        else Destroy(this.gameObject);
        
    }
}
