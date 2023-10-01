using UnityEngine;

public class EnvironnementManager : MonoBehaviour
{
    [SerializeField] GameObject[] environnementObjects;

    public void DeplaceEnvironnement()
    {
        float environnementWidth = environnementObjects[0].GetComponent<SpriteRenderer>().size.x;

        environnementObjects[0].transform.position += new Vector3(environnementWidth * 2, 0);
    }
}
