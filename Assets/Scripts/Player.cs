using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]int maxHealth = 50;
    [SerializeField]int health = 50;
    [SerializeField]int attackPower = 1;

    [SerializeField] public UnityEvent<Player> PlayerDeathEvent;

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
        } 
    }
    public int AttackPower { get { return attackPower; } set { attackPower = value; } }


    void Die()
    {
        PlayerDeathEvent.Invoke(this);
    }
}
