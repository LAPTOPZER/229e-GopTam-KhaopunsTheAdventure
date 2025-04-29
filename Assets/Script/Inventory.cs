using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public int pointCount = 0;
    public int ammoCount = 0;

    public TMP_Text pointText;
    public TMP_Text ammoText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateUI();
    }

    public void Collect(ItemType type, int amount)
    {
        switch (type)
        {
            case ItemType.Point:
                pointCount += amount;
                break;
            case ItemType.Ammo:
                ammoCount += amount;
                break;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (pointText != null)
            pointText.text = $"x {pointCount}";

        if (ammoText != null)
            ammoText.text = $"x {ammoCount}";
    }
}
