using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatedPoolBullets : MonoBehaviour
{
    public static CreatedPoolBullets Instance;

    [Serializable]
    public struct BulletInfo
    {
        public enum BulletType
        {
            Gun,
            SGun,
            Shotgun,
            SniperRifle,
            Granadelauncher,
            Eye
        }

        public BulletType _type;
        public GameObject _prefab;
        public int _bulletCount;
    }

    [SerializeField] private List<BulletInfo> objectsInfo;

    private Dictionary<BulletInfo.BulletType, Pool> pools;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        InitPool();
    }

    private void InitPool()
    {
        pools = new Dictionary<BulletInfo.BulletType, Pool>();

        var emptyContainer = new GameObject();

        foreach (var bullet in objectsInfo)
        {
            var container = Instantiate(emptyContainer, transform, false);
            container.name = bullet._type.ToString();

            pools[bullet._type] = new Pool(container.transform);

            for (int i = 0; i < bullet._bulletCount; i++)
            {
                var magazin = InstantiateObject(bullet._type, container.transform);
                pools[bullet._type].Objects.Enqueue(magazin);
            }
        }
        Destroy(emptyContainer);
    }

    private GameObject InstantiateObject(BulletInfo.BulletType type, Transform parent)
    {
        var allBullets = Instantiate(objectsInfo.Find(x => x._type == type)._prefab, parent);
        allBullets.SetActive(false);
        return allBullets;
    }

    public GameObject GetObject(BulletInfo.BulletType type)
    {
        var bullet = pools[type].Objects.Count > 0 ? pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        bullet.SetActive(true);

        return bullet;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IBullet>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }
}
