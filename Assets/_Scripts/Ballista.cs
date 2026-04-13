using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballista : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float minimumDistance = 50f;
    public float shootForce = 1f;
    public float shootCooldown = 1f;
    public float offset = 0f;
    public GameObject projectilePrefab;
    private GameObject bow;
    private float lastShootTime = -Mathf.Infinity;

    void Start()
    {
        bow = transform.Find("Bow").gameObject;
    }

    void Update()
    {
        Projectile latest = Projectile.GetLatestProjectile();
        if (latest == null) return;
        if (!latest.awake) return;

        // shoot at current possition of latest projectile
        if (GameManager.ballistaDifficulty == 1) 
        {
            Vector3 direction = latest.transform.position - bow.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    
            bow.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            float distance = direction.magnitude;
            if (distance < minimumDistance)
            {
                if (Time.time - lastShootTime >= shootCooldown)
                {
                    shoot();
                    lastShootTime = Time.time;
                }
            }
        }
        // shoot at predicted position of latest projectile
        else if (GameManager.ballistaDifficulty == 2)
        {
            Vector3 toTarget = latest.transform.position - bow.transform.position;
            float distance = toTarget.magnitude;
            float timeToHit = distance / shootForce * (1f + offset);
            
            Vector3 predictedPosition = latest.transform.position + latest.GetComponent<Rigidbody>().velocity * timeToHit;
            Vector3 direction = predictedPosition - bow.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bow.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (distance < minimumDistance)
            {
                if (Time.time - lastShootTime >= shootCooldown)
                {
                    shoot(predictedPosition);
                    lastShootTime = Time.time;
                }
            }
        }
    }

    private void shoot(Vector3 target = new Vector3())
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = bow.transform.position;
        Vector3 direction;
        if (target != Vector3.zero)
        {
            direction = (target - bow.transform.position).normalized;
        } else
        {
            direction = (Projectile.GetLatestProjectile().transform.position - bow.transform.position).normalized;
        }
        projectile.GetComponent<Rigidbody>().velocity = direction * shootForce;
    }
}
