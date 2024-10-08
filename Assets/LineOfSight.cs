using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurretStates
{
    IDEL,
    SHOOT
}

public class LineOfSight : MonoBehaviour
{
    [SerializeField] Transform target;
    TurretStates state = TurretStates.IDEL;

    float timeTilShoot = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Vector3 forwardDirction = transform.forward;

        float dot = Vector3.Dot(forwardDirction, directionToTarget);

        if (dot > 0.5f)
        {
            state = TurretStates.SHOOT;
            // Debug.Log("He's right in front of you");
        }
        else //(dot < - 0.5f)
        {
            state = TurretStates.IDEL;
            // Debug.Log("He's behind you");
        }
        switch (state)
        {
            case TurretStates.IDEL:
                UpdateIdle();
                break;
            case TurretStates.SHOOT:
                UpdateShoot(); 
                break;
        }

    }

    void UpdateIdle()
    {
        Debug.Log("waiting");
    }
    void UpdateShoot()
    {
        timeTilShoot -= Time.deltaTime;

        if (timeTilShoot <= 0)
        {
            Debug.Log("BANG");
            timeTilShoot = 2.0f;
        }
    }
}
