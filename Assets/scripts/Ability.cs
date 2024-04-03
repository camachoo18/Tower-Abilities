using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField] protected string abilityName;
    [SerializeField] public float CoolDown;
    // [SerializeField] public Sprite sprite;
    public float elapsedCoolDown = 0;

    public abstract void PlayerTransform(Transform player);
    public abstract void Trigger(Vector3 direction, MonoBehaviour mbCoroutine);

    public IEnumerator coolDownCouroutine()
    {
        while (elapsedCoolDown <= CoolDown)
        {
            elapsedCoolDown += Time.deltaTime;
           // print("Duración del cooldown -->: " + elapsedCoolDown);
            yield return null;
        }
    }
}
