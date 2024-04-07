using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shot Ability")]
public class ShotAbility : Ability
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField]int spawnCount ;
    //[SerializeField] List<Transform> bulletSpawList;
    [SerializeField] Transform bulletSpawnPoint;
    List<Transform> spawn;

        void Update()
    {
        if (isCooldown && abilityIcon != null)
        {
            abilityIcon.fillAmount = Mathf.Clamp01(1 - (elapsedCooldown / cooldown));
        }
    }


    public override void PlayerTransform(Transform player)
    {
        bulletSpawnPoint = player.Find("SpawnPoint");
        spawn = new List<Transform>();
        for(int i = 0; i < bulletSpawnPoint.childCount; i++)
        {
            spawn.Add(bulletSpawnPoint.GetChild(i));            
        }
    }



    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine)
    {
        if(elapsedCoolDown == 0)
        {

            for (int i = spawnCount; i < spawn.Count; i++)
            {
            GameObject projectileInstance = Instantiate(
                bulletPrefab,
                spawn[i].position,
                Quaternion.identity
            );


            LinearMovement linearMovementComponent = projectileInstance.GetComponent<LinearMovement>();
            linearMovementComponent.SetSpeedAndDirection(speed, direction);
            Destroy(projectileInstance, 0.9f);
            }
            mbCoroutine.StartCoroutine(coolDownCouroutine());

        }
        else if(elapsedCoolDown >= CoolDown)
        {
            elapsedCoolDown = 0;
        }
    }
}
