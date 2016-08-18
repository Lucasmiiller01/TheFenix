using UnityEngine;
using System.Collections;

public class CarBehaviuor : MonoBehaviour {
    private Rigidbody2D rb;
    public string direction;
    public string type;
    [SerializeField]
    private Sprite[] sprites;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        switch (type)
        {
            case "Cheers":
                this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        
                break;
            case "Education":
                this.GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
            case "Safety":
                this.GetComponent<SpriteRenderer>().sprite = sprites[1];
                this.GetComponent<Animator>().enabled = true;
                break;
            
        }

    }
    void FixedUpdate ()
    {
        if (direction != null)
        {
            if (direction.Equals("Left"))
            {
                if (transform.position.x > -3f)
                    rb.velocity = Vector2.left * 5;
                else Destroy(this.gameObject);
            }
            
            else if (transform.position.x < 5f)
            {
               rb.velocity = Vector2.right * 5;
               this.GetComponent<SpriteRenderer>().flipX = true;
                this.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else Destroy(this.gameObject);
        }
        else Destroy(this.gameObject);
        
    }
}
