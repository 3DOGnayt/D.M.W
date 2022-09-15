using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private MaterialPropertyBlock  _matBlock;
    private MeshRenderer _meshRenderer;
    private Camera _mainCamera;
    private Enemy _enemy;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _matBlock = new MaterialPropertyBlock();
        _enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _meshRenderer.enabled = true;
    }

    private void Update()
    {
        transform.LookAt(_mainCamera.transform);
        transform.rotation = _mainCamera.transform.rotation;

        if (_enemy._maxHp < _enemy._CurrentHp)
        {           
            UpdateParams();
        }
    }

    private void UpdateParams()
    {
        _meshRenderer.GetPropertyBlock(_matBlock);
        _matBlock.SetFloat("_Fill", _enemy._maxHp / _enemy._CurrentHp);
        _meshRenderer.SetPropertyBlock(_matBlock);
    }

    //private void AlignCamera()
    //{
    //    if (_mainCamera != null)
    //    {
    //        transform.LookAt(_mainCamera.transform);
    //        transform.rotation = _mainCamera.transform.rotation;
    //    }
    //}
}