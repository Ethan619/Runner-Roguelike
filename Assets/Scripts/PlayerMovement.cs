using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 3f;
    [SerializeField] float verticalSpeed = 2f;

    public UnityEvent<GameObject> onPlayerCollisionEvent;

    void Update()
    {
        transform.position += Vector3.right * runSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        onPlayerCollisionEvent?.Invoke(collision.gameObject);
    }


    public void PrintCollisionMessage(GameObject collidedObject)
    {
        Debug.Log("Player collided with: " + collidedObject.name);
    }
}
