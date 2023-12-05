using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menulist : MonoBehaviour
{
    public GameObject menulist;//²Ëµ¥ÁÐ±í

    [SerializeField] private bool menukeys = true;
    [SerializeField] private AudioSource bgmSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menukeys)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                menulist.SetActive(true);
                menukeys = false;
                Time.timeScale = (0);
                bgmSound.Pause();
            }

        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menulist.SetActive(false) ;
            menukeys = true;
            Time.timeScale = (1);
            bgmSound.Play();
        }
        
    }
}
