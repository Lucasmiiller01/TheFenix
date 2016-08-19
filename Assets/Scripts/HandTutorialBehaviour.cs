using UnityEngine;
using System.Collections;

public class HandTutorialBehaviour : MonoBehaviour {

    public Transform Target;

    void Start()
    {
    }
    void FixedUpdate()
    {
        transform.position = transform.TransformDirection(Vector3.Lerp(this.transform.position, Target.position, 0.1f));
    }
 
}
