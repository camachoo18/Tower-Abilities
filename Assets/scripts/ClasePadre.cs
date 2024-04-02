using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClasePadre : MonoBehaviour
{
    [SerializeField] protected string abilityName;
    [SerializeField] public float CoolDown;
    // [SerializeField] public Sprite sprite;
    public float elapsedCoolDown = 0;

    public abstract void Trigger(Vector3 direction);

    public IEnumerator coolDownCouroutine()
    {
        while (elapsedCoolDown <= CoolDown)
        {
            elapsedCoolDown += Time.deltaTime;
            print(elapsedCoolDown);
            yield return null;
        }
    }
}
