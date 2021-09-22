using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject retryMenu;
    HealthBarBehaviour healthBar;
    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBarBehaviour>();
    }

    private void OnEnable()
    {
        healthBar.onHealthBarEmpty += OnHealthBarEmpty;
    }

    private void OnDisable()
    {
        healthBar.onHealthBarEmpty -= OnHealthBarEmpty;
    }

    private void OnHealthBarEmpty()
    {
        retryMenu.SetActive(true);
    }

}
