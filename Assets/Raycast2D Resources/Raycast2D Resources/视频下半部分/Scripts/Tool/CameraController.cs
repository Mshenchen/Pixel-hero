using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed;

    [SerializeField] private float minX, minY, maxX, maxY;
    public bool isShack;
    private Vector3 shackActive;
    private float shackAmplitude;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        Follow();
        RestrictCamera();
        ShackCamera(shackAmplitude);
    }
    public void ShackCamera(float shackAmplitude)
    {
        if (shackAmplitude > 0)
        {
            shackActive = new Vector3(Random.Range(-shackAmplitude, shackAmplitude), Random.Range(-shackAmplitude, shackAmplitude), 0);
            shackAmplitude -= Time.deltaTime;
        }
        else
        {
            shackActive = Vector3.zero;
        }
        if (isShack)
        {
            transform.position += shackActive;

        }
    }
    void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), smoothSpeed * Time.deltaTime);
    }
    void RestrictCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                        Mathf.Clamp(transform.position.y, minY, maxY), -10);
    }
    //private void LateUpdate()
    //{
    //    transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothSpeed * Time.deltaTime);
    //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
    //                                    Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    //}

}
