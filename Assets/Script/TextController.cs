using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    TMP_Text ui;
    [SerializeField] string format = "{0}";
    [SerializeField] bool hideEgalOnZero = false;
    [SerializeField] bool round = false;


    [Space(30)]
    [SerializeField] FloatReference value;
    private void Awake()
    {
        ui = GetComponent<TMP_Text>();
    }
    public void UpdateMe()
    {
        if (hideEgalOnZero && value.Value == 0)
        {
            ui.text = "";
        } else
        {
            ui.text = string.Format(format, round ? Mathf.Round(value.Value) : value.Value);
        }
    }

    private void FixedUpdate()
    {
        UpdateMe();
    }
}
