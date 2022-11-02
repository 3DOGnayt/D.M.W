using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _chelengeMenu;
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private CreateWeaponController _createWeaponController;

    private void Start()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(false);
            _chelengeMenu.SetActive(false);
            _finishMenu.SetActive(true);

            _playerInventory._weaponSaved = _createWeaponController._weaponList;
            Debug.Log("Save inventory Finish");
        }
    }
}
