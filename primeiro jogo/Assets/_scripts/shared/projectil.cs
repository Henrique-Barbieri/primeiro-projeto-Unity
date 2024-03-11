using UnityEngine;

public class projectil : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    [SerializeField] private GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<enemy>(out var enemy)){
            enemy.lifeMenager.TakDamage(1);
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
