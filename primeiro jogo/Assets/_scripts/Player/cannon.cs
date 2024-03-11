using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] private projectil projectilPrefab;
    [SerializeField] private  Transform firepoint;
    [SerializeField] private float timeBetweenShots = 0.5f;
    private BlinkDamageAnimation blinkDamageAnimation;
    private float shooterCounter = 0;

    private void Awake() {
        blinkDamageAnimation = GetComponent<BlinkDamageAnimation>();
    }
    public void TakeAnimation() => blinkDamageAnimation?.StartAnimation();
    public void EndTakeAnimation() => blinkDamageAnimation?.EndAnimation();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilPrefab, firepoint.position, firepoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            shooterCounter -= Time.deltaTime;
            if (shooterCounter <= 0){
                Instantiate(projectilPrefab, firepoint.position, firepoint.rotation);
                shooterCounter = timeBetweenShots;
            }
        }
    }
}
