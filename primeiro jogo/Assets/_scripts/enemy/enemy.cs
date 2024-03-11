using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Transform explosionPosition;
    [SerializeField] internal lifeMenager lifeMenager;
    [SerializeField] private int power = 1;
    private void Awake() {
        lifeMenager.OnDie += Handledie;
    }
    private void OnDestroy() {
        lifeMenager.OnDie -= Handledie;
    }
    private void Handledie()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<NewBehaviourScript>(out var boat)){
            if (boat.TakeDamage(power)){
                Instantiate(explosionEffect, explosionPosition.position, transform.rotation);
            }
        }
    }
}
