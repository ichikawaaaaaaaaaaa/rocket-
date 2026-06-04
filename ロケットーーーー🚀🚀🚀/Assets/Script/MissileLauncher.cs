using System.Reflection;
using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform launchPoint;

    private Vector2 startPos;

    public float cooldownTime = 1.5f;


    private bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            Vector2 endPos = Input.mousePosition;

            Vector2 dir = (endPos - startPos).normalized;

            Shoot(dir);
        }
    }

    void Shoot(Vector2 dir)
    {
        GameObject missile =
            Instantiate(missilePrefab,
            launchPoint.position,
            Quaternion.identity);

        missile.GetComponent<Missile>().Initialize(dir);

        canShoot = false;

        StartCoroutine(Cooldown());
    }

    public void Reload()
    {
        canShoot = true;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        canShoot = true;
    }
}