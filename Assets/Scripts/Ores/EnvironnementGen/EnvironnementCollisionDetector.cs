using UnityEngine;

public class EnvironnementCollisionDetector : MonoBehaviour
{
    [SerializeField] EnvironnementManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes");
        manager.DeplaceEnvironnement();
    }
}
