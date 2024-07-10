using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        transform.position = new Vector3(transform.position.x + xInput * moveSpeed * Time.deltaTime,
                                         transform.position.y + yInput * moveSpeed * Time.deltaTime,
                                         transform.position.z);
        GetComponent<Camera>().orthographicSize = slider.value;
    }
}
