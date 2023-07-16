using UnityEngine;

public class CubeSphereCollisionHandler : MonoBehaviour
{
    private float _pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            Rigidbody cubeRb = GetComponent<Rigidbody>();
            Rigidbody sphereRb = collision.gameObject.GetComponent<Rigidbody>();

            if (cubeRb != null && sphereRb != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                sphereRb.AddForce(pushDirection * _pushForce, ForceMode.Impulse);
            }
        }
    }
}