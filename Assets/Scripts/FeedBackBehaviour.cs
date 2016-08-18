using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FeedBackBehaviour : MonoBehaviour {
	void Start () {
	
	}
	
	
	void FixedUpdate ()
    {
        
        if (this.GetComponent<Text>().color.a > 0)
        {
            this.GetComponent<Text>().color -= new Color(0, 0, 0, 0.01f);
            this.transform.position += new Vector3(0, 0.02f, 0);
        }
        else Destroy(this.gameObject);
    }
}
