using System.Collections;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineTargetGroup))]
public class SetTargets : MonoBehaviour
{   
    private CinemachineTargetGroup _targetGroup;

    public void Start()
    {
        StartCoroutine(SetTargetsFor());
    }

    public IEnumerator SetTargetsFor()
    {
        yield return new WaitForSeconds(1f);
        Unit[] units = FindObjectsOfType<Unit>();

        _targetGroup = GetComponent<CinemachineTargetGroup>();
        _targetGroup.m_Targets = new CinemachineTargetGroup.Target[units.Length];

        for (int i = 0; i < units.Length; i++)
        {
            _targetGroup.m_Targets[i].target = units[i].transform;
            _targetGroup.m_Targets[i].weight = 1;
        }
    }
}