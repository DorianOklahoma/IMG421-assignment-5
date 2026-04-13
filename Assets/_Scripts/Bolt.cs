using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5f);
    }

    void Update()
    {
        Vector3 direction = transform.position - (transform.position + GetComponent<Rigidbody>().velocity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Projectile latest = Projectile.GetLatestProjectile();
        if (latest == null) return;
        if (!latest.awake) return;

        if (collision.gameObject == latest.gameObject)
        {
            latest.RemoveProjectile();
        }
    }
}
