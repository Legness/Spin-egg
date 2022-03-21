using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectedSkin : MonoBehaviour
{
    SelectedSkin.Data data = new SelectedSkin.Data();
    public int i;

    public GameObject[] AllCharacters;
    public GameObject RightAr;
    public GameObject LeftAr;
    public Text TextPrice;
    public int coins;
    public Text coinsText;
    public GameObject ChButton;
    public GameObject ChBuyButton;
    public GameObject ChText;
    private string statusStr;
    private int check;
    public Text nameT;
    private string name;
    
    [System.Serializable]
    public class Data
    {
        public string currentCharacter = "egg";
        public List<string> haveCharacters = new List<string> { "egg" };


    }
    void Start()
    {
        LeftAr.SetActive(true);
        coins = PlayerPrefs.GetInt("Coins");
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            i = PlayerPrefs.GetInt("CurrentCharacte");
            data = JsonUtility.FromJson<SelectedSkin.Data>(PlayerPrefs.GetString("SaveGame"));
            coins = PlayerPrefs.GetInt("Coins");

        }
        else
        {
            PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));
            RightAr.SetActive(true);
        }
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        AllCharacters[i].SetActive(true);
        if (data.currentCharacter == AllCharacters[i].name)
        {
            ChBuyButton.SetActive(false);
            ChButton.SetActive(false);
            ChText.SetActive(true);
        }
        else if (data.currentCharacter != AllCharacters[i].name)
        {
            StartCoroutine(CheckHaveCharacter());
        }
        RightAr.SetActive(true);
        if (i > 0)
        {
            LeftAr.SetActive(true);

        }
        if (i == AllCharacters.Length)
        {
            RightAr.SetActive(false);
        }
        if (i == 0)
        {
            LeftAr.SetActive(false);
            RightAr.SetActive(true);
        }

        nameT.text = AllCharacters[i].GetComponent<Item>().name;
     
    }
    
    public IEnumerator CheckHaveCharacter()
    {
        while (statusStr != "Check")
        {
            if (data.haveCharacters.Count != check)
            {
                if (AllCharacters[i].name != data.haveCharacters[check])
                {
                    check++;
                }
                else if (AllCharacters[i].name == data.haveCharacters[check])
                {
                    ChBuyButton.SetActive(false);
                    ChButton.SetActive(true);
                    ChText.SetActive(false);
                    check = 0;
                    statusStr = "Check";
                }

            }
            else if (data.haveCharacters.Count == check)
            {
                ChBuyButton.SetActive(true);
                ChButton.SetActive(false);
                ChText.SetActive(false);

                if (AllCharacters[i].GetComponent<Item>().price == 993)
                {
                    TextPrice.text = "1000-7";
                }
                else
                {
                    TextPrice.text = AllCharacters[i].GetComponent<Item>().price.ToString();
                }
                check = 0;
                statusStr = "Check";
            }
        }
        statusStr = "";
        yield return null;
    }
    public void Del()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ArrowRight()
    {

        if (i < AllCharacters.Length)
        {
            if (i == 0)
            {
                LeftAr.SetActive(true);
            }
            AllCharacters[i].SetActive(false);
            i++;
            AllCharacters[i].SetActive(true);
            if (data.currentCharacter == AllCharacters[i].name)
            {
                ChBuyButton.SetActive(false);
                ChButton.SetActive(false);
                ChText.SetActive(true);
            }
            else if (data.currentCharacter != AllCharacters[i].name)
            {
                StartCoroutine(CheckHaveCharacter());
            }
            if (i + 1 == AllCharacters.Length)
            {
                RightAr.SetActive(false);
            }
        }
        nameT.text = AllCharacters[i].GetComponent<Item>().name;
    }
    public void ArrowLeft()
    {

        if (i < AllCharacters.Length)
        {
            AllCharacters[i].SetActive(false);
            i--;
            AllCharacters[i].SetActive(true);
            RightAr.SetActive(true);
            if (data.currentCharacter == AllCharacters[i].name)
            {
                ChBuyButton.SetActive(false);
                ChButton.SetActive(false);
                ChText.SetActive(true);
            }
            else if (data.currentCharacter != AllCharacters[i].name)
            {
                StartCoroutine(CheckHaveCharacter());
            }

            if (i == 0)
            {
                LeftAr.SetActive(false);
            }
        }
        nameT.text = AllCharacters[i].GetComponent<Item>().name;
    }
    public void SelectCh()
    {
        data = JsonUtility.FromJson<SelectedSkin.Data>(PlayerPrefs.GetString("SaveGame"));
        data.currentCharacter = AllCharacters[i].name;
        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));
        ChButton.SetActive(false);
        ChText.SetActive(true);
        PlayerPrefs.SetInt("Skin", i);
    }
    public void BuyCh()
    {
        if (coins >= AllCharacters[i].GetComponent<Item>().price)
        {
            data = JsonUtility.FromJson<SelectedSkin.Data>(PlayerPrefs.GetString("SaveGame"));
            coins = coins - AllCharacters[i].GetComponent<Item>().price;
            data.haveCharacters.Add(AllCharacters[i].name);
            PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(data));
            ChButton.SetActive(true);
            ChBuyButton.SetActive(false);
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("Coins", coins);
        }
    }
    // Update is called once per frame
    public void SceneChange()
    {
        SceneManager.LoadScene(0);
    }
    public void pluscoins()
    {
        coins = coins + 100;
        PlayerPrefs.SetInt("Coins", coins);
        coinsText.text = coins.ToString();
    }
    public void OpisanieOtcrit()
    {
        

    }
    public void OpisanieZakrit()
    {
       
    }
}
