using UnityEngine;

public class TReference : ScriptableObject
{
    private dynamic value;
    public dynamic Value { get => value; set => this.value = value; }
}
