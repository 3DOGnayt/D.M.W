using System.Threading.Tasks;
using UnityEngine;

public class SGun : Bullet, IWeapon, IDamage
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _sgun;

    public int _damage => 2;

    private void Start()
    {
        _sgun = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SGunFire();
        }
        else if (Input.GetMouseButton(0))
        {
            Task t = Task.Run(() => { SGunFire();});
            Task.Delay(1000); // ’уй знает как оно работает. видосики в студию
        }
    }

    private void FixedUpdate()
    {
        transform.position = _sgun.position;
        transform.rotation = _sgun.rotation;        
    }

    public void SGunFire()
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bullet.Init(_damage);
    }
}
