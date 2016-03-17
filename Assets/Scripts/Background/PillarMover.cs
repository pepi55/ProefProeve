using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PillarMover : MonoBehaviour
{
    [SerializeField]
    GameObject[] PillarLocations;
    [SerializeField]
    int pillarPerLocation = 5;
    [SerializeField]
    GameObject PillarPrefab;

    [SerializeField]
    float ReturnZDepth = -3f;
    [SerializeField]
    float DistanceBetweenPillars = 1f;
    [SerializeField]
    float moveSpeed = 2f;


    List<Transform> pillars;

    // Use this for initialization
    void Start()
    {
        pillars = new List<Transform>();

        Transform t;
        foreach(GameObject gam in PillarLocations)
            for (int i = 0; i < pillarPerLocation; i++)
            {
                t = CreatePillar(gam.transform);
                t.localPosition = new Vector3(0, 0, (DistanceBetweenPillars * ((i + 1) + ReturnZDepth)));
            }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        foreach (Transform tran in pillars)
        {
            if (tran.position.z < ReturnZDepth)
                tran.localPosition += new Vector3(0, 0, (DistanceBetweenPillars * pillarPerLocation) + ReturnZDepth);

            tran.localPosition -= new Vector3(0, 0, (moveSpeed * Time.deltaTime));
        }
    }

    Transform CreatePillar(Transform newParent)
    {
        GameObject g = Instantiate(PillarPrefab);
        g.SetActive(true);
        g.name = "pillar" + pillars.Count;
        g.transform.SetParent(newParent, false);

        pillars.Add(g.transform);

        return (g.transform);
    }
}

