using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float jumpStrength = 8;
    public KeyCode jumpKey = KeyCode.Space;

    private Rigidbody rb;
    private Transform defaultParent;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultParent = transform.parent;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
        }
        else if (Input.GetKeyUp(jumpKey) && rb.velocity.y > 0) {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, rb.velocity.z);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            for (int i = 0; i < collision.contactCount; i++) {
                var contact = collision.GetContact(i);
                if (contact.normal.y > 0.5) {
                    isGrounded = true;
                    
                    transform.parent = contact.otherCollider.gameObject.transform;
                    return;
                }
            }
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.gameObject.transform == transform.parent)
        {
            isGrounded = false;
            transform.parent = defaultParent;
        }
    }
}
