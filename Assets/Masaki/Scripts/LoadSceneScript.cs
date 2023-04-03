using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    private AudioSource audiosource;
    private AudioClip audioclip;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audioclip = (AudioClip)Resources.Load("決定ボタンを押す38");
    }

    public void LoadBattleScene()
    {
        audiosource.PlayOneShot(audioclip);
        SceneManager.LoadScene("BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
