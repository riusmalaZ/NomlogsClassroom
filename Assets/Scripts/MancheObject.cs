using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MancheObjet", order = 1)]
public class MancheObject : ScriptableObject
{
    public int MancheNumber = 0;

    public int NumberSudents = 0;

    public bool CanWindowOpen; 

}
