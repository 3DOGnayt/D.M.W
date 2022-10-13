using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _chelengeMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Time.timeScale = 0f;
            _chelengeMenu.SetActive(false);
            _pauseMenu.SetActive(false);
            _finishMenu.SetActive(true);
        }
    }
}
