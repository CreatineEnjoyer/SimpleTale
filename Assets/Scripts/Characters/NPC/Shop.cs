using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshPro moneyAmountMesh;
    [SerializeField] private int moneyAmount;

    private void Start()
    {
        moneyAmountMesh.text = moneyAmount.ToString();
    }
}
