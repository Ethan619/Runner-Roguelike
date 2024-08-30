using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int attackPower;
    public int AttackPower { get => attackPower; }

    void Awake()
    {
        if (gameObject.tag != "Enemy")
        {
            gameObject.tag = "Enemy";
        }
    }
}
