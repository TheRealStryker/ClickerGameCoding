using UnityEngine;
using TMPro;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public UpgradesManager upgradesManager;
    public Data data;

    [SerializeField] private TMP_Text beansText;
    [SerializeField] private TMP_Text beansClickPowerText;

    public BigDouble ClickPower()
    {
        return 1 + data.clickUpgradeLevel;
    }

    public void Start()
    {
        data = new Data();
        data.beans = 0;

        upgradesManager.StartUpgradeManager();
    }

    public void Update()
    {
        beansText.text = data.beans + " Beans";
        beansClickPowerText.text = "+" + ClickPower() + " Beans";
    }
    
    public void GenerateBeans()
    {
        data.beans += ClickPower();
    }

}
