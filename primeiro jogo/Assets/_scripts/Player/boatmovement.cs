using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatmovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float moveSpeed;
    private float rotationAngle = 0;
    [SerializeField] private float rotationSpeed = 2;
    [SerializeField] [Range(0,1)] private float driftfactor = 1;
    [SerializeField] private float dragfactor = 3;
    [SerializeField] private float maxspeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate() {
        aplicarrotacao();
        ApplyDrift();
        applyspeed();
    }
    void applyspeed(){
        if(movement.y == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, dragfactor, Time.deltaTime);
        } 
        else 
        {
            rb.drag = 0;
        }
        var velocityup = Vector2.Dot(transform.up, rb.velocity);
        if(velocityup > maxspeed) return; // indo para frente
        if(velocityup < (-maxspeed * 0.5)) return; // indo para baixo
         rb.AddForce(transform.up * movement.y * moveSpeed, ForceMode2D.Force);
    }
    void aplicarrotacao(){
        rotationAngle = rotationAngle - (movement.x * rotationSpeed);
        rb.MoveRotation(rotationAngle);
    }
    void ApplyDrift(){
        Vector2 velocityup = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 velocityright = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = velocityup + velocityright * driftfactor;
    }
}
