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
        if (effectsProps.x != 0)
        {
            Stamps[0].SetActive(true);
            if (effectsProps.x > 0)
                Stamps[3].SetActive(true);
            else
                Stamps[4].SetActive(true);
        }
        if (effectsProps.y != 0)
        {
            Stamps[1].SetActive(true);
            if (effectsProps.y > 0)
                Stamps[3].SetActive(true);
            else
                Stamps[4].SetActive(true);
        }
        if (effectsProps.z != 0)
        {
            Stamps[2].SetActive(true);
            if (effectsProps.z > 0)
                Stamps[3].SetActive(true);
            else
                Stamps[4].SetActive(true);
        }
    }
}
