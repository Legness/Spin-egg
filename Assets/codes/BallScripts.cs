using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallScripts : MonoBehaviour
{
    public int coin;
    public GameObject panel;
    public GameObject egg;
    [SerializeField] Text coinText;
    [SerializeField] GameObject Ball;
    bool direction = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            coin++;
            coinText.text = coin.ToString();
        }
        if (other.gameObject.tag == "Enemy")
        {
            coin = PlayerPrefs.GetInt("Coins") + coin;
            PlayerPrefs.SetInt("Coins", coin);
            Destroy(other.gameObject);
            Time.timeScale = 0f;
            panel.SetActive(true);
            egg.SetActive(false);
        }
    }

    void Update()
    {
        if (direction == false)
            Ball.transform.Rotate(0, 0, 240 * Time.deltaTime);
        else
            Ball.transform.Rotate(0, 0, -240 * Time.deltaTime);

    }
    public void ChangeDirection()
    {
        direction = !direction;
    }
}
