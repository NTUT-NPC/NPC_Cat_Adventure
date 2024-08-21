using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class LoadingController : MonoBehaviour
{
    private Text text;
    IEnumerator Start()
    {
        text = GetComponent<Text>();
        text.DOColor(Color.black, 1);
        yield return new WaitForSeconds(1);
        text.DOColor(Color.white, 1);
        yield return new WaitForSeconds(1);
        text.DOColor(Color.black, 1);
        yield return new WaitForSeconds(1);
        text.DOColor(Color.white, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
