using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float multiplier;
    public bool horizontalOnly;
    public bool calculateInfHorizontalPos;
    public bool calculateInfVerticalPos;
    public bool isInfinite;

    public GameObject camera;
    private Vector3 startPosition;
    private Vector3 startCameraPosition;
    public float length;
    
    void Start()
    {
        startPosition = transform.position;
        startCameraPosition = camera.transform.position;

        if (isInfinite)
            length = GetComponent<SpriteRenderer>().bounds.size.x;

        CalculateStartPosition();
    }
    
    void FixedUpdate()
    {
        /*transform.position = new Vector3(startPosition.x + (multiplier * camera.transform.position.x), transform.position.y,
            transform.position.z); */

        Vector3 position = startPosition;

        if (horizontalOnly)
            position.x += multiplier * (camera.transform.position.x - startCameraPosition.x);
        else
        {
            position += multiplier * (camera.transform.position - startCameraPosition);
        }

        transform.position = position;

        if (isInfinite)
        {
            float tmp = camera.transform.position.x * (1 - multiplier);
            if (tmp > startPosition.x * length)
                startPosition.x += length;
            else if (tmp < startPosition.x - length)
                startPosition.x -= length;
        }
    }


    void CalculateStartPosition()
    {
        float distX = (camera.transform.position.x - transform.position.x) * multiplier;
        float distY = (camera.transform.position.y - transform.position.y) * multiplier;

        Vector3 tmp = new Vector3(startPosition.x, startPosition.y);

        if (calculateInfHorizontalPos)
            tmp.x = transform.position.x + distX;
        if (calculateInfVerticalPos)
            tmp.y = transform.position.y + distY;
        startPosition = tmp;
    }

}
