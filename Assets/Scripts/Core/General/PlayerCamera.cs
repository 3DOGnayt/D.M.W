using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraMoveSpeed = 2;
    [SerializeField] private float _changePositionX;
    [SerializeField] private float _changePositionY;
    [SerializeField] private float _changePositionZ;

    private Vector3 _target;

    private void Update()
    {
        if (_player)
        {
            Vector3 position = Vector3.Lerp(transform.position, _target, _cameraMoveSpeed * Time.deltaTime);
            transform.position = position;
            
            _target = new Vector3(
                _player.transform.position.x + _changePositionX,
                _player.transform.position.y + _changePositionY,
                _player.transform.position.z + _changePositionZ);
        }
    }
}