using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    private int _lifes = 3;
    private int _money = 1000;
    public int[] _moneyCoef;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public TMP_Text _moneyText;

    void Start()
    {
        for (int i = 0; i < _lifes; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        _moneyCoef = new int[] { 5, 10, 120 };
    }

    [System.Obsolete]
    public void decreaseLife()
    {
        this._lifes -= 1;
        hearts[this._lifes].sprite = emptyHeart;
        if (this._lifes == 0)
        {
            //FindObjectOfType<EndManager>().PauseGame();
            SceneManager.LoadScene(0);
        }

    }
    public void increaseMoney(int moneyIncrease)
    {
        this._money += moneyIncrease;

        PlayerPrefs.SetInt("BestScore", this._money);

        _moneyText.text = "Points: " + this._money + "$";
    }
}
