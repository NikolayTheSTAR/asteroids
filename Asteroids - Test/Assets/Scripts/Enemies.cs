using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int scoreHeft;
    
    protected void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}