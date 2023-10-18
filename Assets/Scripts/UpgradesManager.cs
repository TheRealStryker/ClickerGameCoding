using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;

    public Upgrades clickUpgrade;

    public string clickUpgradeName;

    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMult;

    public void StartUpgradeManager()
    {
        clickUpgradeName = "Beans Per Click";
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMult = 1.5;
    }
    
    public void UpdateClickUpgradeUI() 
    {
        clickUpgrade.LevelText.text = controller.data.clickUpgradeLevel.ToString();
        clickUpgrade.CostText.text = "Cost: " + Cost().ToString("F2") + " Beans";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }

    public BigDouble Cost()
    { 
        return clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMult, controller.data.clickUpgradeLevel); 
    }
    public void BuyUpgrade()
    {
        if (controller.data.beans >= Cost())
        {
            controller.data.beans -= Cost();
            controller.data.clickUpgradeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }
}
