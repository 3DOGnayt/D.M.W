using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject _sameObject;
    [SerializeField] private CreateWeaponController _controller;
    public GameObject _gameObject;

    private void Start()
    {
        _gameObject = gameObject;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 2, 1) + 0.5f, transform.position.z);
        gameObject.transform.Rotate(0, 30 * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            if (_controller._weapon.Contains(_sameObject) == true)
            {
                Destroy(gameObject);
            }
            else
            {
                _controller._weapon.Add(_sameObject);
                _controller.CreateWeapon(_controller._weapon.Count - 1);
                Destroy(gameObject);
            }            
        }
    }
}
