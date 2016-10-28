using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private bool next;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject myParent;
    [SerializeField]
    private GameObject Etapa1;
    [SerializeField]
    private GameObject Etapa2;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(next)
        {
            Camera.main.GetComponent<Animator>().SetBool("back", true);
            gameController.SetEtapa(1);
            myParent.SetActive(false);
            Etapa1.SetActive(false);
            Etapa2.SetActive(true);

        }
        else
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}