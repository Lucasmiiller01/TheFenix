using UnityEngine;
using System.Collections;

public class SpawnCarController : MonoBehaviour {
    public bool rigth;
    public GameObject car;
    [SerializeField]
    private GameController gameController;

    void Start ()
    {
        StartCoroutine(CarSpawn());
    }
	
    IEnumerator CarSpawn()
    {
        int random = Random.Range(0, 2);
        yield return new WaitForSeconds(0.5f);
        if (rigth)
        {
            GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
            gameObject.transform.parent = this.transform;
            gameObject.GetComponent<CarBehaviuor>().direction = "Left";
            gameObject.GetComponent<CarBehaviuor>().type = "Cheers";
        }

        else
        {

            GameObject gameObject = (GameObject)Instantiate(car, this.transform.position, car.transform.rotation);
            gameObject.transform.parent = this.transform;
            gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
            gameObject.GetComponent<CarBehaviuor>().type = "Education";
        }
        yield return new WaitForSeconds(1f);
        if(random.Equals(0) && rigth)
        {
            
            GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
            gameObject.transform.parent = this.transform;
            gameObject.GetComponent<CarBehaviuor>().direction = "Left";
            gameObject.GetComponent<CarBehaviuor>().type = "Safety";
            
        }
        else if(!rigth)
        {
            GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
            gameObject.transform.parent = this.transform;
            gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
            gameObject.GetComponent<CarBehaviuor>().type = "Safety";
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(CarSpawn());    
    }
}
