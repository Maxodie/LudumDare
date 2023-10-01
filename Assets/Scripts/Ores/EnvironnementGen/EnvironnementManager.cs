using UnityEngine;

public class EnvironnementManager : MonoBehaviour
{
    [SerializeField] GameObject[] environnementObjects;

    int firstObjectIndex = 0;

    public void DeplaceEnvironnement()
    {
        float environnementWidth = environnementObjects[firstObjectIndex].GetComponent<SpriteRenderer>().size.x;

        environnementObjects[firstObjectIndex].transform.position += new Vector3(environnementWidth * 2, 0);

        firstObjectIndex++;
    }
}
