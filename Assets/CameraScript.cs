using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int Height;
    public int Width;

    public void Awake()
    {
        MatchCamera();
    }

    private void Start()
    {
        
    }

    private void OnValidate()
    {
        MatchCamera();
    }

//Checks for the camera
    private void MatchCamera()
    {
        var cam = GetComponent<Camera>();
        if (cam == null) return;

        var position = cam.ViewportToWorldPoint(Vector3.zero);
        var up = cam.ViewportToWorldPoint(Vector3.up) - position;
        var right = cam.ViewportToWorldPoint(Vector3.right) - position;

        var matchSize = Mathf.Max(Height, Width * up.magnitude / right.magnitude);

        cam.orthographicSize = matchSize;
    }
}
