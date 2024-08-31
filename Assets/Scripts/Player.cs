using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]int maxHealth = 50;
    [SerializeField]int health = 50;
    [SerializeField]int attackPower = 1;

    [SerializeField] public UnityEvent<Player> PlayerDeathEvent;
    [SerializeField] public UnityEvent<int> OnAttackPowerChanged;
    [SerializeField] public UnityEvent<int, int> OnHealthChanged;


    public int Health { 
        get { return health; } 
        set { 
            health = value;  
            if(health > maxHealth)
            {
                health = maxHealth;
            }else if(health <= 0)
            {
                Die();
            }
            OnHealthChanged.Invoke(health, maxHealth);
        } 
    }
    public int AttackPower { 
        get { return attackPower; } 
        set { 
            attackPower = value;
            OnAttackPowerChanged.Invoke(attackPower);
        } 
    }


    void Die()
    {
        PlayerDeathEvent.Invoke(this);
    }
}
