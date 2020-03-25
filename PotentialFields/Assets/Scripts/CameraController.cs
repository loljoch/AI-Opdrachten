using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1;
    public float camSize = 15;
    public float zoomSpeed = 2;
    public float lerpSpeed = 1;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(0, 0, camSize);
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        if(vert != 0 || hor != 0)
        {
            targetPos += (Vector3.up * vert + hor * Vector3.right).normalized * moveSpeed;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            camSize += -Mathf.Sign(scroll) * zoomSpeed;
            camSize = Mathf.Clamp(camSize, 2, 20);
            Camera.main.orthographicSize = camSize;
        }

        targetPos.z = -10;

        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
}
