using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : Ability
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] List<Transform> bulletSpawList;
    

    public override void Trigger(Vector3 direction)
    {

        if(elapsedCooldown == 0)
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
        else if(elapsedCooldown >= coolDown)
        {
            elapsedCooldown = 0;
        }
    }
}
