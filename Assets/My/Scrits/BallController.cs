using UnityEngine;

public class BallController : MonoBehaviour
{
    public float kickForce = 10f;
    public float spinForce = 2.5f;
    public float magnusFactor = 0.3f; // ลด Magnus Effect

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KickBall();
        }
    }

    void KickBall()
    {
        Vector3 forwardForce = transform.forward * kickForce;
        rb.velocity = forwardForce;

        // ใช้แรงหมุนแนวข้าง (ไม่ใช่ขึ้นบน)
        Vector3 spinDirection = Vector3.right;
        rb.AddTorque(spinDirection * spinForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        ApplyMagnusEffect();
    }

    void ApplyMagnusEffect()
    {
        // ลด Magnus Effect และปรับแกนหมุนให้ถูกต้อง
        Vector3 magnusForce = magnusFactor * Vector3.Cross(rb.velocity, Vector3.right);
        rb.AddForce(magnusForce, ForceMode.Force);

        // จำกัดความเร็วหมุนเพื่อป้องกันการลอยขึ้นฟ้า
        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, 3f);
    }
}