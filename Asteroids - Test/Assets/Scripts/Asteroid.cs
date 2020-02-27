using UnityEngine;

public class Asteroid : Enemies
{
    [SerializeField] private int size;
    [SerializeField] private GameObject FlashObject;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            DestroyAsteroid();
        }
        else if (col.CompareTag("Side"))
        {
            Destroy(gameObject);
        }
    }

    // уничтожение астероида
    private void DestroyAsteroid()
    {
        Instantiate(FlashObject, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);

        ScoreManager.AddScore(scoreHeft);
        size--;

        switch (size)
        {
            case 2:
                EnemiesCreator.BranchAsteroid(EnemiesCreator.ListAsteroidObject[1], gameObject, Random.Range(1, 3));

                float r = Random.Range(0f, 1f);

                if (r <= 0.5f)
                {
                    EnemiesCreator.BranchAsteroid(EnemiesCreator.ListAsteroidObject[2], gameObject, Random.Range(1, 3));
                }
                break;
            case 1:
                EnemiesCreator.BranchAsteroid(EnemiesCreator.ListAsteroidObject[2], gameObject, Random.Range(0, 4));
                break;
        }
    }
}