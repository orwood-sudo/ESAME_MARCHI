using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    int currentMoney = 0;

    //Funzione che mi aumenta i soldi in base a un valore dato da Enemy
    public void IncreaseMoney(int enemyValue)
    {
        currentMoney += enemyValue;
        moneyText.text = currentMoney.ToString();
    }

    public int getMoneyAmount()
    {
        return currentMoney;
    }

    //Funzione che mi spende i soldi
    public void PayMoney(int cost)
    {
        currentMoney -= cost;
    }

}
