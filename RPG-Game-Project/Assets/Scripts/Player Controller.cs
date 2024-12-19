using JetBrains.Annotations;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed = 5f;
    public float jumpHeight = 50f;
    bool onGround = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = 0;

        if (onGround)
        {
            jump = jumpHeight;
        }


        Vector3 movement = new Vector3(horizontal, jump, 0) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}

