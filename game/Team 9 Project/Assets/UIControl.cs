using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{

    public CanvasGroup IntroGroup;
    public CanvasGroup DeathGroup;
    public CanvasGroup VictoryGroup;

    // Start is called before the first frame update
    void Start()
    {
        hideGroups();
        StartCoroutine(Intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Victory()
    {
        hideGroups();
        VictoryGroup.alpha = 1;
        VictoryGroup.interactable = true;
    }
    public void Death()
    {
        hideGroups();
        DeathGroup.alpha = 1;
        DeathGroup.interactable = true;
    }
    public IEnumerator Intro()
    {
        hideGroups();
        IntroGroup.alpha = 1;
        yield return new WaitForSeconds(5);
        hideGroups();
        //IntroGroup.interactable = true;
    }

    private void hideGroups()
    {
        IntroGroup.alpha = 0;
        IntroGroup.interactable = false;

        DeathGroup.alpha = 0;
        DeathGroup.interactable = false;

        VictoryGroup.alpha = 0;
        VictoryGroup.interactable = false;
    }
}
