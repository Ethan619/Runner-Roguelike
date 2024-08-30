using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    public void OnObjectCollision(GameObject collision)
    {
        if (collision.CompareTag("Wall"))
        {
            //Kill? Hurt? Do we even really need the walls?
        }else if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy.AttackPower > player.AttackPower)
            {
                player.Health -= enemy.AttackPower - player.AttackPower;
            }
                Destroy(enemy);
            
        }else if (collision.CompareTag("PowerUp"))
        {
            PowerUp powerUp = collision.GetComponent<PowerUp>();
            player.Health += powerUp.health;
            player.AttackPower += powerUp.attackPower;
        }
    }
}
