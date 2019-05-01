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
        VictoryGroup.blocksRaycasts = true;
    }
    public void Death()
    {
        hideGroups();
        DeathGroup.alpha = 1;
        DeathGroup.interactable = true;
        DeathGroup.blocksRaycasts = true;
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
        IntroGroup.blocksRaycasts = false;

        DeathGroup.alpha = 0;
        DeathGroup.interactable = false;
        DeathGroup.blocksRaycasts = false;

        VictoryGroup.alpha = 0;
        VictoryGroup.interactable = false;
        VictoryGroup.blocksRaycasts = false;
    }
}
