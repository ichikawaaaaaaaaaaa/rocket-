using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            GameManager.Instance.MeteorHitGround();

            Destroy(other.gameObject);
        }
    }
}