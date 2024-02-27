using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _chelengeMenu;
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private GameObject _weaponIcon;
    //[SerializeField] private GameObject _weaponSwitch;
    [SerializeField] private GameObject _points;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private CreateWeaponController _createWeaponController;

    private Player _player;

    private void Start()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0f;
            _player.GetComponent<Player>().enabled = false;
            _pauseMenu.SetActive(false);
            _chelengeMenu.SetActive(false);
            _weaponIcon.SetActive(false);
            //_weaponSwitch.SetActive(false);
            _points.SetActive(false);
            _finishMenu.SetActive(true);

            _playerInventory._weaponSaved = _createWeaponController._weaponList;
            Debug.Log("Save inventory Finish");
        }
    }
}
