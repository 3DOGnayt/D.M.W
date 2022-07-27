using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private float _angleRotation;
    [SerializeField] private float _hightLevelUpDown;
    [SerializeField] private float _distanceUpDown;
    [SerializeField] private float _intervalRepeating;

    private void Update()
    {
        PingPong();
    }

    private void PingPong()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * _intervalRepeating, _distanceUpDown) + _hightLevelUpDown, transform.position.z);
        gameObject.transform.Rotate(0, _angleRotation * Time.deltaTime, 0, Space.World);
    }
}
