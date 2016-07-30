using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

    private bool isSelect;
    private bool onPaper;
    private bool quit;
    [SerializeField]
    private string myType; 
    private GameObject paper;
    private Vector3 mousePos;

    [SerializeField]
    private GameObject movedObject;


    // Use this for initialization
    void Start ()
    {
	 
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Paper"))
        {
            onPaper = true;
            paper = coll.transform.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Paper"))
        {
            onPaper = false;
            if(!quit) paper = null;
        }
    }
    void OnMouseDown()
    {
        isSelect = true;
        Cursor.visible = false;
    }
    void OnMouseUp()
    {
        isSelect = false;
        Cursor.visible = true;
        if (onPaper)
        {
            switch (myType)
            {
                case "Cheers":
                    if (paper != null && !paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(2).transform.position = this.transform.position;
                        paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
                  
                    }
                    break;
                case "Education":
                    if (paper != null && !paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(1).transform.position = this.transform.position;
                        paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
            
                    }
                    break;
                case "Safety":
                    if (paper != null && !paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
                    {
                        paper.transform.GetChild(0).transform.position = this.transform.position;
                        paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        
                    }
                    break;
                case "Stamp":
                    if (paper != null && !paper.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled && !paper.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled && !paper.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled)
                        Debug.Log("Não está preenchida!!");
                    else
                        QuitScreen();


                    break;
                default:
                            
                    break;
            }
            
        }
            
    }
    // Update is called once per frame
    void Update () {
        if (isSelect)
        {
            if (movedObject != null)
                FollowMouse(movedObject);
            else
                FollowMouse();
        }
        if (paper != null && quit.Equals(true) && myType.Equals("Stamp"))
            if(paper.transform.position.x < 3f) paper.transform.position += Vector3.right;
        else if(myType.Equals("Stamp"))
        {
            Destroy(paper);
            paper = null;
        }
    }

    private void FollowMouse()
    {
        mousePos = getWorldPosition(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
    private void QuitScreen()
    {
        if (paper != null) quit = true;
    }

    private void FollowMouse(GameObject i)
    {
        mousePos = getWorldPosition(Input.mousePosition);
        i.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    // Following method calculates world's point from screen point as per camera's projection type
    public Vector3 getWorldPosition(Vector3 screenPos)
    {
        Vector3 worldPos;
        if (Camera.main.orthographic)
        {
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = Camera.main.transform.position.z;
        }
        else
        {
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.transform.position.z));
            worldPos.x *= -1;
            worldPos.y *= -1;
        }
        return worldPos;
    }
}
