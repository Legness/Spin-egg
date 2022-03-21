using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallScripts : MonoBehaviour
{
    public int coin;
    public int record;
    public GameObject panel;
    public GameObject egg;
    public GameObject NewRecord;
   
    [SerializeField] Text coinText;
    [SerializeField] Text recordText;
    [SerializeField] GameObject Ball;
    bool direction = false;
    
    void Start()
    {
        record = PlayerPrefs.GetInt("Record");
        recordText.text = record.ToString();
    }
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
            if (record < coin)
            {
                PlayerPrefs.SetInt("Record", coin);
                NewRecord.SetActive(true);
               
            }

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
