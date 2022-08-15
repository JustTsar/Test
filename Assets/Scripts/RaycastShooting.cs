using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class RaycastShooting : MonoBehaviour, IPoolable
{
    [SerializeField] private Bullet _bulletPreFab;

    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _bulletSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                GameObject bullet = LeanPool.Spawn(_bulletPreFab.gameObject, _bulletSpawn);
                bullet.GetComponent<Rigidbody>().AddForce((raycastHit.transform.position - bullet.transform.position) * _bulletSpeed * Time.deltaTime , ForceMode.Impulse);
                Debug.DrawRay(_bulletSpawn.transform.position, raycastHit.transform.position - bullet.transform.position, Color.black, 2f);
            }

        }
    }

    public void OnDespawn()
    {
        
    }

    public void OnSpawn()
    {
        
    }
}
