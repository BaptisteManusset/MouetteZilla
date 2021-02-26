using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillController : MonoBehaviour
{

    [SerializeField] Image fill;

    [SerializeField] FloatReference value;
    [SerializeField] FloatReference valueMax;

    public void UpdateMe()
    {
        fill.fillAmount = value.Value / valueMax.Value;
    }

    private void FixedUpdate()
    {
        UpdateMe();
    }
}
