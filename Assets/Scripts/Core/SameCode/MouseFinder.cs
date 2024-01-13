using UnityEngine;

public class MouseFinder : MonoBehaviour, ILookOnMouse
{

    // Supposed, what all obbects how have this, can looc at mouse cursour 

    //private LayerMask _layerMask;
    private Camera _cam;
    //[SerializeField] private Transform _transform;

    private void Start()
    {
        _cam = gameObject.GetComponent<Camera>();
        _cam = Camera.main;
        //_transform = GetComponent<Transform>();
    }

    public void LookOnMouse()
    {
        Ray rayCAM = _cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_cam.transform.position, rayCAM.direction * 20f, Color.green);

        Physics.Raycast(rayCAM, out RaycastHit hit, 50f/*, _layerMask*/);
        Vector3 groundHit = hit.point;
        transform.LookAt(new Vector3(groundHit.x, groundHit.y + 0.5f, groundHit.z));
    }
}
