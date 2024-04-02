using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected string abilityName;
    [SerializeField] public float coolDown;
    [SerializeField] public Sprite sprite;
    public float elapsedCooldown = 0;



    public abstract void Trigger(Vector3 direction);

    public IEnumerator coolDownCouroutine()
    {
        while (elapsedCooldown <= coolDown)
        {
            elapsedCooldown += Time.deltaTime;
            print("Duración del cooldown -->: " + elapsedCooldown);

            yield return null;
        }
    }
}
