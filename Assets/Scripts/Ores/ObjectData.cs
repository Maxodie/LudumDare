using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public Ore objectData;

    public GameObject blockBelow;

    public void LoadObjectData(Ore objectData)
    {
        this.objectData = objectData;
        
        GetComponent<SpriteRenderer>().sprite = objectData.sprites[0];
    }
}
