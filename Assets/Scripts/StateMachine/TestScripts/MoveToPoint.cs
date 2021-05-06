using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera mainCamera;
    public LayerMask hitLayers;
    public SoundSource soundSource;

    private SoundData walkSoundData = new SoundData();

    // Update is called once per frame
    void Update()
    {
        soundSource.CastAudio(WalkSoundData);
        if (Input.GetMouseButtonDown(0))
        {
            agent.SetDestination(MouseToWorldPoint());
        }
    }

    public Vector3 MouseToWorldPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hitLayers))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private SoundData WalkSoundData
    {
        get
        {
            if (walkSoundData == null) walkSoundData = new SoundData();
            walkSoundData.castPosition = transform.position;
            walkSoundData.power = agent.velocity.magnitude * 5;
            walkSoundData.id = "1234";
            return walkSoundData;
        }
    }
}
