using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    private bool isSelect, onBox;

    private GameObject box;
    private Vector3 mousePos;
    private Vector3 inicialPos;

    [SerializeField]
    private GameController gameController;
    public static Vector3 auxProps;
    public static float multCooldown;

    void Start()
    {
        inicialPos = this.transform.position;
    }

    #region DropObject
    void DropObject()
    {
        isSelect = false;
        gameController.isPick = false;
        if(onBox)
        {
            box.GetComponent<BoxScript>().SumMoney();
            this.gameObject.SetActive(false);
        }

    }
    #endregion

    #region OnTriggerEnterAndExit
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Box"))
        {
            onBox = true;
            box = coll.gameObject;

        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Box"))
        {
            onBox = false;
        }
    }
    #endregion

    void Update()
    {
        RayCast();

        if (isSelect)
        {
            FollowMouse();
            if (Input.GetMouseButtonUp(0)) DropObject();
        }
        if (!isSelect)
            this.transform.position = Vector2.Lerp(this.transform.position, inicialPos, 0.05f);
    }
    #region RayCast
    void RayCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = getWorldPosition(Input.mousePosition);
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(ray, new Vector2(0, 0));

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider.gameObject != null)
                {
                    if (hit.collider != null && hit.collider.isTrigger && hit.collider.gameObject.Equals(this.gameObject) && !gameController.isPick)
                    {
                        isSelect = true;
                        gameController.isPick = true;
                    }
                }

                else
                {
                    isSelect = false;
                }
            }
        }
    }
    #endregion

    #region FallowMouse
    private void FollowMouse()
    {
        mousePos = getWorldPosition(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
    #endregion
    private void PropsAffect()
    {
        gameController.props += auxProps;
        if (!gameController.checkProps) gameController.checkProps = true;
        auxProps = Vector3.zero;

    }

    private void FollowMouse(Transform i)
    {
        this.GetComponent<Rigidbody2D>().MovePosition(i.position);
    }
    #region GetWorldPosition
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
    #endregion
    
}
