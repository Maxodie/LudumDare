using UnityEngine;

public class EnvironnementManager : MonoBehaviour
{
    [SerializeField] GameObject FloorPrefab;

    [SerializeField] GameObject[] floorObjects;

    public void DeplaceFloor()
    {
        float floorWidth = floorObjects[0].GetComponent<SpriteRenderer>().size.x;

        floorObjects[0].transform.position += new Vector3(floorWidth * 2, 0);
    }
}
