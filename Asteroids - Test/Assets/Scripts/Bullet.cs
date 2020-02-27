using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float flySpeed = 6;

    void Update()
    {
        transform.Translate(new Vector3(0, flySpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Side"))
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}