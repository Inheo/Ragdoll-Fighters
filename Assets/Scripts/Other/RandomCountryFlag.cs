using UnityEngine;
using UnityEngine.UI;

public class RandomCountryFlag : MonoBehaviour
{
    [SerializeField] private Image _countryFlagImage;
    [SerializeField] private CountryFlagsDB _countryFlagDB;

    private void Start()
    {
        _countryFlagImage.sprite = _countryFlagDB.GetRandomFlag();
    }
}
