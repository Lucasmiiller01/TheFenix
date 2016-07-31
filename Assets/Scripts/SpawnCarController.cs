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
	
	void Update ()
    {
	    
	}
    IEnumerator CarSpawn()
    {
        int random = Random.Range(1, 8);
        Debug.Log(random);
        yield return new WaitForSeconds(2f);
        if (rigth)
        {
          
                if(gameController.props.x > random)
                {
                    GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
                    gameObject.transform.parent = this.transform;
                    gameObject.GetComponent<CarBehaviuor>().direction = "Left";
                    gameObject.GetComponent<CarBehaviuor>().type = "Cheers";
                }
                else if(gameController.props.y > random)
                {
                    GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
                    gameObject.transform.parent = this.transform;
                    gameObject.GetComponent<CarBehaviuor>().direction = "Left";
                    gameObject.GetComponent<CarBehaviuor>().type = "Education";
                }
                else if(gameController.props.z > random)
                {
                    GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
                    gameObject.transform.parent = this.transform;
                    gameObject.GetComponent<CarBehaviuor>().direction = "Left";
                    gameObject.GetComponent<CarBehaviuor>().type = "Safety";
                }

        }

        else
        {
            if (gameController.props.x > random)
            {
                GameObject gameObject = (GameObject)Instantiate(car, this.transform.position, car.transform.rotation);
                gameObject.transform.parent = this.transform;
                gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
                gameObject.GetComponent<CarBehaviuor>().type = "Cheers";
            }
            else if (gameController.props.y > random)
            {
                GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
                gameObject.transform.parent = this.transform;
                gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
                gameObject.GetComponent<CarBehaviuor>().type = "Education";
            }
            else if(gameController.props.z > random)
            {
                GameObject gameObject = (GameObject) Instantiate(car, this.transform.position, car.transform.rotation);
                gameObject.transform.parent = this.transform;
                gameObject.GetComponent<CarBehaviuor>().direction = "Rigth";
                gameObject.GetComponent<CarBehaviuor>().type = "Safety";
            }
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(CarSpawn());
    }
}
