using UnityEngine;

public class UFO : Enemies
{
    [SerializeField] private GameObject FlashObject;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            DestroyUFO();
        }
        else if (col.CompareTag("Side"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // стабилизация изображения
        transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // уничтожение НЛО
    private void DestroyUFO()
    {
        Instantiate(FlashObject, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);

        ScoreManager.AddScore(scoreHeft);
    }
}