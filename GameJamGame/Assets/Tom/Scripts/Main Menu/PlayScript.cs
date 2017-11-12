
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{

    public void OnClick()
    {
        //Debug.Log("Play Button Clicked");
        SceneManager.LoadScene("main");
    }
}
