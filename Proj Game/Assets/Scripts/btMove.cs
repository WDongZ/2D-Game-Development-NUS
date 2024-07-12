using UnityEngine;

public class byMove : MonoBehaviour
{
    public float minScale = 0.5f; 
    public float maxScale = 1.5f; 
    public float speed = 2.0f;

    private Vector3 initialScale;
    private float scaleFactor;
    private bool scalingUp = true;

    void Start()
    {
        initialScale = transform.localScale;
        scaleFactor = 0;
    }

    void Update()
    {
        if (scalingUp)
        {
            scaleFactor += Time.deltaTime * speed;
            if (scaleFactor >= 1)
            {
                scaleFactor = 1;
                scalingUp = false;
            }
        }
        else
        {
            scaleFactor -= Time.deltaTime * speed;
            if (scaleFactor <= 0)
            {
                scaleFactor = 0;
                scalingUp = true;
            }
        }

        float scaleValue = Mathf.Lerp(minScale, maxScale, scaleFactor);
        transform.localScale = initialScale * scaleValue;
    }
}
