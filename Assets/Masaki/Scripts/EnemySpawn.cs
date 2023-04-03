using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn instance;
    public GameObject Enemy;
    public GameObject Player;
    public bool flg;
    public GameObject button;
    public Button btn;
    public GameObject Clear;
    public int clear;
    public AudioSource audio;
    public AudioClip clip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
        flg = true;
        btn.onClick.AddListener(LoadTitleScen);
        button.SetActive(false);
        clear = 0;
        audio = GetComponent<AudioSource>();
        clip = (AudioClip)Resources.Load("決定ボタンを押す38");
    }

    private void Update()
    {
        if(flg==false)
        {
            button.SetActive(true);
            Clear.SetActive(false);
            //Debug.Log("GameOver");
        }

        if(clear == 10)
        {
            Player.SetActive(false);
            button.SetActive(true);
            Debug.Log("Clear!");
        }
    }

    void LoadTitleScen()
    {
        audio.PlayOneShot(clip);
        SceneManager.LoadScene("Title");
    }

    private void Spawn()
    {
        Vector2 randpos = new Vector2(transform.position.x ,Random.Range(-4.6f, 4.6f));
        Instantiate(Enemy, randpos, Enemy.transform.rotation);
    }
}
