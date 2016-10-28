using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject opening;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private GameObject select;

    private GameObject previousScene;
    private GameObject nextScene;

    private Animator anim;

    private bool fadeDone = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EndOpening()
    {
        mainMenu.SetActive(true);
        opening.SetActive(false);
    }

    public void TestButton() {
        print(Random.Range(0,1000));
    }

    public void PlayButton(){
        anim.SetBool("Fade", true);
        previousScene = mainMenu;
        nextScene = select;
    }

    public void SettingsButton()
    {
        anim.SetBool("Fade", true);
        previousScene = mainMenu;
        nextScene = settings;
    }

    public void InfoButton()
    {
        anim.SetBool("Fade", true);
        previousScene = mainMenu;
        nextScene = credits;
    }

    public void BackSettButton()
    {
        anim.SetBool("Fade", true);
        previousScene = settings;
        nextScene = mainMenu;
    }

    public void BackInfoButton()
    {
        anim.SetBool("Fade", true);
        previousScene = credits;
        nextScene = mainMenu;
    }

    public void BackSelectButton()
    {
        anim.SetBool("Fade", true);
        previousScene = select;
        nextScene = mainMenu;
    }

    public void Vereador()
    {
        print("VEREADOR");
    }

    public void Prefeito()
    {
        Application.LoadLevel(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void FadeDone() {
        nextScene.SetActive(true);
        anim.SetBool("Fade", false);
    }
}
