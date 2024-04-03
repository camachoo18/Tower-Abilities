using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] List<Ability> abilities;
    int selectedAbilityIndex = 0;


     void Start()
    {
        for(int i = 0; i < abilities.Count; i++)
        {
            abilities[i].PlayerTransform(transform);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedAbilityIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedAbilityIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedAbilityIndex = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selectedAbilityIndex = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            selectedAbilityIndex = 4;

            Vector3 globalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            globalPos.z = transform.position.z;
            Vector3 direction = (globalPos - transform.position).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            abilities[selectedAbilityIndex].Trigger(direction,this);
        }

    }
}
