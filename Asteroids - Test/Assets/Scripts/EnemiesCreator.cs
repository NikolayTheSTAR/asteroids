using System.Collections.Generic;
using UnityEngine;

public class EnemiesCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> listAsteroidObject = new List<GameObject>();
    [SerializeField] private GameObject UFOObject;
    public static List<GameObject> ListAsteroidObject;
    private static Transform tran;

    private const float diffractionForce = 0.33f; // предел преломления после взрыва
    private const float sideLimitX = 8.65f; // крайняя позиция по X (для генерации)
    private const float sideLimitY = 5.6f; // крайняя позиция по Y (для генерации)
    private const float sleepTime = 1; // время промежутка между созданием астероидов
    private const float centerIncline = 30; // наклонение к центру

    private float time; // счётчик времени

    void Start()
    {
        tran = transform;
        ListAsteroidObject = listAsteroidObject;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > sleepTime)
        {
            time = 0;

            float r = UnityEngine.Random.Range(0f, 1f);

            if (r < 0.4f)
            {
                GenerateEnemy(listAsteroidObject[0]);
            }
            else if (r <= 0.7f)
            {
                GenerateEnemy(listAsteroidObject[1]);
            }
            else if (r <= 0.8f)
            {
                GenerateEnemy(UFOObject);
            }
        }
    }

    // генерация враждебного объекта
    public static void GenerateEnemy(GameObject enemyObject)
    {
        Vector2 createPosition = new Vector2(); // позиция создания
        float rotationZ; // разворот по оси Z
        float r = UnityEngine.Random.Range(0f, 1f);

        // слева
        if (r <= 0.25f)
        {
            createPosition.x = -sideLimitX;
            createPosition.y = UnityEngine.Random.Range(-sideLimitY, sideLimitY);
            rotationZ = UnityEngine.Random.Range(0 - centerIncline, -180 + centerIncline);
        }
        // сверху
        else if (r <= 0.5f)
        {
            createPosition.x = UnityEngine.Random.Range(-sideLimitX, sideLimitX);
            createPosition.y = sideLimitY;
            rotationZ = UnityEngine.Random.Range(90 + centerIncline, 270 - centerIncline);
        }
        // справа
        else if (r <= 0.75f)
        {
            createPosition.x = sideLimitX;
            createPosition.y = UnityEngine.Random.Range(-sideLimitY, sideLimitY);
            rotationZ = UnityEngine.Random.Range(0 + centerIncline, 180 - centerIncline);
        }
        // снизу
        else
        {
            createPosition.x = UnityEngine.Random.Range(-sideLimitX, sideLimitX);
            createPosition.y = -sideLimitY;
            rotationZ = UnityEngine.Random.Range(90 - centerIncline, -90 + centerIncline);
        }

        Instantiate(enemyObject, createPosition, Quaternion.Euler(0, 0, rotationZ), tran);
    }

    // отделение астероида (после взрыва)
    public static void BranchAsteroid(GameObject asteroidObject, GameObject basedObject, int amount = 1)
    {
        Quaternion diffractedQuaternion; // преломлённый кватернион

        for (int i = 0; i < amount; i++)
        {
            diffractedQuaternion = basedObject.transform.localRotation;
            diffractedQuaternion.z += UnityEngine.Random.Range(-diffractionForce, diffractionForce);

            Instantiate(asteroidObject, basedObject.transform.position, diffractedQuaternion, tran);
        }
    }
}