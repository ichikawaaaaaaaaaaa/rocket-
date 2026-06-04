using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 8f;

    private Vector2 direction;

    public void Initialize(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.Translate(
            direction * speed * Time.deltaTime,
            Space.World
        );
    }

    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            GameManager.Instance.AddScore(100);

            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}