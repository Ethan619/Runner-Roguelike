using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI attackPower;
    [SerializeField]Image healthBar;

    public void UpdateHealth(int health, int maxHealth)
    {
        this.healthBar.fillAmount = (float)health/(float)maxHealth;
    }

    public void UpdateAttackPower(int attackPower)
    {
        this.attackPower.text = attackPower.ToString();
    }
    



}
