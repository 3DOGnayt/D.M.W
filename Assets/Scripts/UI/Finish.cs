using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private GameObject _pauseMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _pauseMenu.SetActive(false);
            _finishMenu.SetActive(true);
        }
    }
}
