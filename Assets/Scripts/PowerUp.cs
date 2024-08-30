using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int attackPower;
    public int health;

    public void Awake()
    {
        if(gameObject.tag != "PowerUp")
        {
            gameObject.tag = "PowerUp";
        }
    }
}
