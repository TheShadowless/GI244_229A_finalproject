using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField]private Vector3 offset = new Vector3(3, 3, -12);
      

    private void Awake()
    {
        transform.position = target.position + offset;
    }
    void LateUpdate()
    {
        /*
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        */
    }
}

