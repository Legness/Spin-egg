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
    public Text descriptionTextName;
    public Text descriptionTextAge;
    public Text descriptionTextBio;
    public GameObject Opisanie;
    public GameObject OpisanieButton;
    public GameObject OpisanieButtonZakrit;
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
        Inf();
    }
    public void Inf()
    {
        switch (i)
        {
            case 0: descriptionTextName.text = "���: ��� "; descriptionTextAge.text = "�������: 9 ���"; descriptionTextBio.text = " ���������: ��� ��� ������� ��������� � ����� ���������� ������� ����. �� ������� ��� ����� ����������� �� �� � �����. � ���� ������������ ���� ��������� ��� � ����."; break;
            case 1: descriptionTextName.text = "���: ���� "; descriptionTextAge.text = "�������: 0 ���"; descriptionTextBio.text = " ���������: ��� ��������� ���� � ����� 3� ��� ����� ������"; break;
            case 2: descriptionTextName.text = "���: ����� "; descriptionTextAge.text = "�������: 12 ���"; descriptionTextBio.text = " ���������: ������� �������� �������, ������ BIG NIGGERS. ������ ���� ���� ��, �� ����� ����� ��� �������."; break;
            case 3: descriptionTextName.text = "���: Kaneki Egg "; descriptionTextAge.text = "�������: 20 ���"; descriptionTextBio.text = " ����� �� �������� � ��������, �� � ��� ��� �� ���� ������ ����. �� ��� �������, � ��� ���������� ������ ����. ����� ��������������� �����. 1000-7?"; break;
            case 5: descriptionTextName.text = "���: ����� ������ "; descriptionTextAge.text = "�������: 88 ���"; descriptionTextBio.text = " ���������: ������������ ����� ������ ����. ����� ���� ��������� ��������� ������ 2-�� �������.������� �������� �� �����, ����� � 5 ���."; break;
            case 4: descriptionTextName.text = "���:  ����"; descriptionTextAge.text = "�������: 14 ���"; descriptionTextBio.text = " ���������: ����� ����� ��� �� �� ����� ��� ���. �� ����� �����. ������� ��������. �������� ������� �� ������"; break;
            case 6: descriptionTextName.text = "���:  ��� � ���"; descriptionTextAge.text = "�������: 11 � 7 ���"; descriptionTextBio.text = " ���������: ��� ����� ����� ������ ������-�� �������. �� ���� ����� ��������� ����."; break;
            case 7: descriptionTextName.text = "���:  ����� ������"; descriptionTextAge.text = "�������: 7 ���"; descriptionTextBio.text = " ���������: 1 ���� ����� � 2014 ����. ����� ������ ������."; break;
        }
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
        Inf();
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
        Inf();
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
        Opisanie.SetActive(true);
        OpisanieButton.SetActive(false);

    }
    public void OpisanieZakrit()
    {
        Opisanie.SetActive(false);
        OpisanieButton.SetActive(true);
    }
}
