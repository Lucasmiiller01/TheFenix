using UnityEngine;
using System.Collections;

public class SpawnCarController : MonoBehaviour {
    public bool rigth;
    public GameObject car;

    void Start () {
        StartCoroutine(CarSpawn());
    }
	
	void Update ()
    {
	    
	}
    IEnumerator CarSpawn()
    {
        yield return new WaitForSeconds(2f);
        if(rigth)
        {
           GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
           gameObject.transform.parent = this.transform;
           gameObject.GetComponent<CarBehaviuor>().direction = "Left";
        }

        else
        {
            GameObject gameObject = (GameObject)Instantiate(car, this.transform.position, car.transform.rotation);
            gameObject.transform.parent = this.transform;
            gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
        }
    }
}
