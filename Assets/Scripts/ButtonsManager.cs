using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public Cannon cannon;
    public TextMeshProUGUI upgradeCostText;
    public Button thisButton;
    public MoneyManager money;

    int costIndex = 0;
    int cannonCost = 0;

    private void Awake()
    {
        UpdateCost();
    }

    public void Update()
    {
        if (cannonCost > money.getMoneyAmount() || costIndex >= cannon.costs.Length)
        {
            thisButton.interactable = false;
        } else
        {
            thisButton.interactable = true;
        }
    }

    public void UpgradeButton()
    {        
        if (costIndex < cannon.costs.Length-1)
        {            
            money.PayMoney(cannon.costs[costIndex]);
            costIndex++;
            UpdateCost();
            cannon.Upgrade();

        }else
        {
            costIndex++;
            GameOverManager gameOverManager = FindAnyObjectByType<GameOverManager>();
            thisButton.interactable = false;

            gameOverManager.maxCannon++;
            upgradeCostText.text = "max";            
        }        
    }
    public void UpdateCost()
    {
        cannonCost = cannon.costs[costIndex];
        upgradeCostText.text = cannonCost.ToString();
    }
}
