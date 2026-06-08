using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects / Floor Tile Data ")]
public class FloorPuzzleScriptableObject : ScriptableObject
{
    public int iD;
    public Material onMaterial;
    public Material offMaterial;
}
