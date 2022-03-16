using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject panel;
    public GameObject click;
    public GameObject egg;
    [SerializeField] Text StartText;
    public GameObject StartTextG;
    public GameObject CoinTextG;



    void Start()
    {
        StartCoroutine(StartTree());
    }
    public void Pause()
    {
        panel.SetActive(true);
        click.SetActive(false);
    
        Time.timeScale = 0f;
    }
    public void continuegame()
    {
       
        panel.SetActive(false);
        Time.timeScale = 1f;
        click.SetActive(true);
     
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void ToGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    IEnumerator StartTree()
    {
        yield return new WaitForSeconds(1);
        StartText.text = "3";
        StartCoroutine(StartTwo());
    }
    IEnumerator StartTwo()
    {
        yield return new WaitForSeconds(1);
        StartText.text = "2";
        StartCoroutine(StartOne());
    }
    IEnumerator StartOne()
    {
        yield return new WaitForSeconds(1);
        StartText.text = "1";
        StartCoroutine(StartO());
    }
    IEnumerator StartO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1);
        StartTextG.SetActive(false);
        egg.SetActive(true);
        CoinTextG.SetActive(true);
    }
}
