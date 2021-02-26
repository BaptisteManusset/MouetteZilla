using UnityEngine;

[CreateAssetMenu()]
public class IntReference : TReference
{
    private int value;
    new public int Value { get => value; set => this.value = value; }
}
