using UnityEngine;
using System.Collections;

public class PaperController : MonoBehaviour {
    [SerializeField]
    private Vector3 effectsProps;
    [SerializeField]
    private Vector3[] effectsPropsPref;
    [SerializeField]
    private int myValue;
    [SerializeField]
    private GameObject[] Stamps;

    public void SetValue(int value)
    {
        myValue = value;
        effectsProps = effectsPropsPref[myValue];
        ActivedStamps();
    }

    public Vector3 GetEffectsProps()
    {
        return effectsProps;
    }
    void ActivedStamps()
    {
        if (effectsProps.x > 0) Stamps[0].SetActive (true);
        else Stamps[0].SetActive(false);
        if (effectsProps.y > 0) Stamps[1].SetActive(true);
        else Stamps[1].SetActive(false);
        if (effectsProps.z > 0) Stamps[2].SetActive(true);
         else Stamps[2].SetActive(false);
    }
}
