using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCover : MonoBehaviour
{
    [Header("Inscribed")]
    public Sprite[] cloudSprites;
    public int numClouds = 40;
    public Vector3 minPos = new Vector3(-20, -5, -5);
    public Vector3 MaxPos = new Vector3(300, 40, 5);
    [Tooltip("For scaleRange, x is the min value, and y is the max value.")]
    public Vector2 scaleRange = new Vector2(1, 4);

    [Header("Dynamic")]
    public List<GameObject> cloudInstances;

    void Start()
    {
        Transform parentTrans = this.transform;
        GameObject cloudGO;
        Transform cloudTrans;
        SpriteRenderer sRend;
        float scaleMult;
        for (int i = 0; i < numClouds; i++)
        {
            cloudGO = new GameObject();
            cloudInstances.Add(cloudGO);

            cloudTrans = cloudGO.transform;
            sRend = cloudGO.AddComponent<SpriteRenderer>();

            int spriteNum = Random.Range(0, cloudSprites.Length);
            sRend.sprite = cloudSprites[spriteNum];
            
            cloudTrans.position = RandomPos();
            cloudTrans.SetParent(parentTrans, true);

            scaleMult = Random.Range(scaleRange.x, scaleRange.y);
            cloudTrans.localScale = Vector3.one * scaleMult;
        }
    }

    void FixedUpdate()
    {
        foreach (GameObject cloud in cloudInstances)
        {
            cloud.transform.position += Vector3.right * MissionDemolition.wind * Time.fixedDeltaTime;
            if (cloud.transform.position.x > MaxPos.x)
            {
                Vector3 pos = cloud.transform.position;
                pos.x = minPos.x;
                pos.y = Random.Range(minPos.y, MaxPos.y);
                pos.z = Random.Range(minPos.z, MaxPos.z);
                cloud.transform.position = pos;
            } else if (cloud.transform.position.x < minPos.x)
            {
                Vector3 pos = cloud.transform.position;
                pos.x = MaxPos.x;
                pos.y = Random.Range(minPos.y, MaxPos.y);
                pos.z = Random.Range(minPos.z, MaxPos.z);
                cloud.transform.position = pos;
            }
        }
    }

    Vector3 RandomPos()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(minPos.x, MaxPos.x);
        pos.y = Random.Range(minPos.y, MaxPos.y);
        pos.z = Random.Range(minPos.z, MaxPos.z);
        return pos;
    }
}
