using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public IEnumerator ChangeScene(int index, bool doFade = false)
    {
        if (doFade)
        {
            Animator fadeAnimator = GameObject.FindWithTag("FaderPanel").GetComponent<Animator>();
            fadeAnimator.Play("FadeIn");
        }

        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(index);
    }
}
