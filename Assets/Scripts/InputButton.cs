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
    private Selector i;
    [SerializeField]
    private GameObject myParent;
    [SerializeField]
    private GameObject Etapa1;
    [SerializeField]
    private GameObject Etapa2;
    [SerializeField]
    private GameObject[] go;

    public void OnPointerDown(PointerEventData eventData)
    {
      
        if (gameController.GetEtapa().Equals(0))
        {
            go[3].SetActive(true);
            go[2].SetActive(true);
            go[1].SetActive(false);
            go[0].SetActive(false);
            gameController.updateProps = false;
            Camera.main.GetComponent<Animator>().SetBool("back", true);
            gameController.SetEtapa(1);
            Tutorial.inTuto = false; 

        }
        else
        {
            if (gameController.GetEtapa().Equals(1))
            {
                if (next)
                {   
                    Camera.main.GetComponent<Animator>().SetBool("back", true);
                    if(Tutorial.inTuto2)
                    {
                        gameController.SetEtapa(1);
                        myParent.SetActive(false);
                        go[0].SetActive(true);
                        go[1].SetActive(false);
                        Etapa1.SetActive(false);
                        Etapa2.SetActive(true);
                        gameController.NewProps();
                        gameController.OnCreate();                        
                        go[2].GetComponent<Tutorial>().Continue();                        

                    }
                    else
                    {
                        gameController.SetEtapa(1);
                        myParent.SetActive(false);
                        Etapa1.SetActive(false);
                        Etapa2.SetActive(true);
                        gameController.NewProps();
                        gameController.OnCreate();
                    }
                }
                else
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
            else
            {
                if (next)
                {
                    Application.LoadLevel(2);
                }
                else
                {
                    myParent.SetActive(false);
                    gameController.updateProps = false;
                    Etapa1.SetActive(false);
                    Etapa2.SetActive(true);
                    gameController.NewProps();
                    gameController.OnCreate();
                    i.Resetao();

                    Camera.main.GetComponent<Animator>().SetBool("back", true);
                }
            }
        }
  
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}