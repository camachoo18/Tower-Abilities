using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : ClasePadre
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] List<Transform> bulletSpawList;
   
    public override void Trigger(Vector3 direction)
    {
        if(elapsedCoolDown == 0)
        {

            for (int i = 0; i < bulletSpawList.Count; i++)
            {
            GameObject projectileInstance = Instantiate(
                bulletPrefab,
                bulletSpawList[i].position,
                Quaternion.identity
            );


            LinearMovement linearMovementComponent = projectileInstance.GetComponent<LinearMovement>();
            linearMovementComponent.SetSpeedAndDirection(speed, direction);
            Destroy(projectileInstance, 0.9f);
            }
            StartCoroutine(coolDownCouroutine());
        }
        else if(elapsedCoolDown >= CoolDown)
        {
            elapsedCoolDown = 0;
        }
    }
}
