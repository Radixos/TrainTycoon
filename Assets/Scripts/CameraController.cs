using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;

    public float panSpeed = 20f;
    public float panBorderThickness = 5f;
    public Vector2 panLimit;

    public float rotateSpeed = 50f;
    public float rotateAmount = 50f;
    public Vector2 rotateLimit;

    public float scrollSpeed = 20f;
    public float minY = 5f;
    public float maxY = 30f;

    void Update()
    {
        CameraMoveAndScroll();
        CameraRotate();
        CameraReset();
    }

    void CameraMoveAndScroll()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }

    void CameraRotate()
    {
        Vector3 origin = MainCamera.transform.eulerAngles;
        Vector3 destination = origin;

        if (Input.GetMouseButtonDown(2))
        {
            //destination.x -= Input.GetAxis("Mouse Y") * rotateAmount;
            //destination.y += Input.GetAxis("Mouse X") * rotateAmount;
            //destination.y += Input.GetAxis("Mouse X") * rotateAmount * Time.deltaTime;
        }

        float rotate1, rotate2;
        rotate1 = CalculateAngle(left.transform.forward);
        rotate2 = CalculateAngle(right.transform.forward);

        if (Input.GetKey("q") && rotate1 > 0f)
        {
            destination.y -= rotateAmount * Time.deltaTime;
            Debug.Log(rotate1);
        }

        if (Input.GetKey("e") && rotate2 < 0f)
        {
            destination.y += rotateAmount * Time.deltaTime;
            Debug.Log(rotate2);
        }

        //if (destination != origin)
        //{
        //    Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * rotateSpeed);
        //}

        //destination.y = Mathf.Clamp(destination.y, - rotateLimit.y, rotateLimit.y);
        
        transform.eulerAngles = new Vector3(60f, destination.y, 0f);
    }

    void CameraReset()
    {
        if (Input.GetKey("r"))
        {
            transform.position = new Vector3(0f, 18f, -10f);
            transform.eulerAngles = new Vector3(60f, 0f, 0f);
        }
    }

    public GameObject left;
    public GameObject right;

    float CalculateAngle(Vector3 forward)
    {
        float angle = 0;

        Vector3 CamForward = transform.forward;
        forward.y = 0f;
        CamForward.y = 0f;
        float magnitude1 = forward.magnitude;
        float magnitude2 = CamForward.magnitude;

        float dot = Vector3.Dot(forward, CamForward);
        angle = dot / (magnitude1 * magnitude2);

        angle = Mathf.Acos(angle);
        angle *= Mathf.Rad2Deg;

        float sgn = Mathf.Sign(Vector3.Dot(Vector3.up, Vector3.Cross(forward, CamForward)));
        angle *= sgn;

        return angle;
    }
}