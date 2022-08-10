using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "country-flags-db", menuName = "Country Flags DB")]
public class CountryFlagsDB : ScriptableObject
{
    [SerializeField] private Sprite[] _spriteFlags;

    public Sprite GetRandomFlag()
    {
        return _spriteFlags[Random.Range(0, _spriteFlags.Length)];
    }
}
