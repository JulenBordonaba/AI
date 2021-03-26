using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public Camera enemyCamera;

    public Transform target;

    public delegate void TargetEvent(Entity target);

    public TargetEvent OnTargetViewed;
    public TargetEvent OnTargetDesapeared;

    public float viewDistance = Mathf.Infinity;

    [Header("View repeat rate")]
    public int checksPerFrame = 10;
    public float checkStartTime = 0;
    
    public List<Entity> visibleEntities = new List<Entity>();

    private void Start()
    {
        InvokeRepeating("GetTarget", checkStartTime, 1f / checksPerFrame);
    }

    private void GetTarget()
    {
        visibleEntities = GetVisibleEntities();
        if (visibleEntities == null) return;
        if (visibleEntities.Count <= 0) return;


    }



    private List<Entity> GetVisibleEntities()
    {
        if (Entity.activeEntities.Count <= 0) return null;

        List<Entity> visibleEntities = new List<Entity>();

        foreach(Entity e in Entity.activeEntities)
        {
            if (!(e is IEnemyTarget)) continue;
            if(IsVisibleInCamera(e.transform, enemyCamera))
            {
                visibleEntities.Add(e); 
            }
        }

        return visibleEntities;
    }

    private bool IsVisibleInCamera(Transform t, Camera cam)
    {
        if (IsInCameraFrustum(t.position, cam))
        {
            Ray ray = new Ray();
            ray.origin = cam.transform.position;
            ray.direction = t.position - cam.transform.position;

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                float dist = Vector3.Distance(hit.point, cam.transform.position);

                if (dist< viewDistance)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsInCameraFrustum(Vector3 point, Camera cam)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(point);
        float distance = Vector3.Distance(point, cam.transform.position);

        if (screenPoint.z < 0) return false;

        if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {
            if(distance<cam.farClipPlane && distance>cam.nearClipPlane)
            {
                return true;
            }
        }

        return false;
    }

    public Entity Target
    {
        get
        {
            if (visibleEntities == null) return null;
            if(visibleEntities.Count<=0) return null;

            return visibleEntities[0];
        }
    }
    
}
