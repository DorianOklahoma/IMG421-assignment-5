using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    static private int totalHits = 0;

    void OnCollisionEnter(Collision collision)
    {
        Projectile latest = Projectile.GetLatestProjectile();
        if (latest == null) return;
        if (!latest.awake) return;

        if (collision.gameObject == latest.gameObject)
        {
            latest.RemoveProjectile();
            totalHits++;
        }
    }

    public static int GetTotalHits()
    {
        return totalHits;
    }
    public static void ResetHits()
    {
        totalHits = 0;
    }
}
