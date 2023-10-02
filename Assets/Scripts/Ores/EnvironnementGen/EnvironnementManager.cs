using UnityEngine;

public class EnvironnementManager : MonoBehaviour
{
    [SerializeField] GameObject[] environnementObjects;

    int firstObjectIndex = 0;

    float[] xInintials = new float[2];

    private void Start()
    {
        xInintials[0] = environnementObjects[0].transform.position.x;
        xInintials[1] = environnementObjects[1].transform.position.x;
    }

    public void DeplaceEnvironnement()
    {
        float environnementWidth = environnementObjects[firstObjectIndex].GetComponent<SpriteRenderer>().size.x;

        environnementObjects[firstObjectIndex].transform.position += new Vector3(environnementWidth * 2, 0);

        firstObjectIndex++;
    }


    public void ResetEnvironnement()
    {
        environnementObjects[0].transform.position = new Vector3(xInintials[0], environnementObjects[0].transform.position.y);
        environnementObjects[1].transform.position = new Vector3(xInintials[1], environnementObjects[1].transform.position.y);

    }
}
