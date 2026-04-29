using UnityEngine;

//[CreateAssetMenu(fileName = "PowerSO", menuName = "ScriptableObjects/Power")]

public class PowerSO : ScriptableObject
{
    public GameObject PowerPrefab;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public bool IsAutomatic = false;
    //public GameObject HitVFXPrefab;
    public int MagazineSize = 7;
}

