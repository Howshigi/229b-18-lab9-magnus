using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float torqueAmount = 10f; // กำหนดแรงบิด (Torque)
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // คลิกขวาเพื่อหมุน
        {
            rb.AddTorque(Vector3.up * torqueAmount, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // กด Spacebar เพื่อหยุดการหมุน
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}