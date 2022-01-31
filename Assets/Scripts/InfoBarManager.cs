using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarManager : MonoBehaviour
{
    public static InfoBarManager instance;
    private void Awake()
    {
        instance = this;
    }

    public Text infoBarText1;
    public Text infoBarText2;
    public Animator infoBarAnimator;

    public void SendInfoBar(string varText)
    {
        infoBarText1.text = "You just picked up";
        infoBarText2.text = varText;
        StartCoroutine(BarWait());
    }

    public void SendSpecial(string varTextOne, string varTextTwo)
    {
        infoBarText1.text = varTextOne;
        infoBarText2.text = varTextTwo;
        StartCoroutine(BarWait());
    }

    public IEnumerator BarWait()
    {
        yield return new WaitForSeconds(2f);
        infoBarAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
