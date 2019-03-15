using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Items")]
public class Item : ScriptableObject
{
    // Blueprint that all other scriptable object will inherit from

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
}
