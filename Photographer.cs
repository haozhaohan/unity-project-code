using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photographer : MonoBehaviour
{
    public float Pitch { get; private set; }

    public float Yaw { get; private set; }

    public float mouseSensitivity = 5;

    public float cameraRotatingSpeed = 80;
    public float cameraYSpeed = 5;
    private Transform _target;
    // Start is called before the first frame update

    void Start()
    {

    }
    public void InitCamera(Transform target)
    {
        _target = target;
        transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        updateRotation();
        UpdatePosition();
    }
    private void updateRotation()
    {
        Yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        Yaw += Input.GetAxis("CameraRateX") * cameraRotatingSpeed * Time.deltaTime;
        Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        Pitch += Input.GetAxis("CameraRateY") * cameraRotatingSpeed * Time.deltaTime;
        Pitch = Mathf.Clamp(value: Pitch, min: -90, max: 90);

        transform.rotation = Quaternion.Euler(x: Pitch, Yaw, z: 0);
    }

    private void UpdatePosition()
    {
        Vector3 position = _target.position;
        float newY = Mathf.Lerp(a: transform.position.y, b: position.y, t: Time.deltaTime * cameraYSpeed);
        transform.position = new Vector3(position.x, newY, position.z);
    }
}
