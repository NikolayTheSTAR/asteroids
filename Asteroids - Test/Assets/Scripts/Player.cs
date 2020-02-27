using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletObject; // пуля
    [SerializeField] private Transform bulletsParent; // родительский объект пуль
    [SerializeField] private GameObject flashObject; // взрыв
    [SerializeField] private GameObject restartTextObject; // объект рестарта
    private Transform bulletCreateDot; // точка, в которой создаются пули
    private const float moveSpeed = 3;
    private const float rotationSpeed = 200;

    void Start()
    {
        bulletCreateDot = transform.Find("bulletCreateDot");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(false);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
    }

    // движение
    private void Move(bool forward)
    {
        transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime * (forward ? 1 : -1)));
    }

    // поворот
    private void Rotate(bool right)
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * (right ? -1 : 1)));
    }

    // выстрел
    private void Shot()
    {
        Quaternion bulletQuaternion = transform.localRotation;
        Instantiate(bulletObject, new Vector2 (bulletCreateDot.position.x, bulletCreateDot.position.y), bulletQuaternion, bulletsParent);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Die();
        }
    }

    // смерть
    private void Die()
    {
        Destroy(gameObject);
        Instantiate(flashObject, transform.position, Quaternion.identity);
        restartTextObject.SetActive(true);
    }
}