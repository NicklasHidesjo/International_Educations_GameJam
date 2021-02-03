using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIDisplayer : MonoBehaviour
{
    [SerializeField] Color notCollected = Color.red;
    [SerializeField] Color collected = Color.green;

    [SerializeField] Text item0 = null;
    [SerializeField] Text item1 = null;
    [SerializeField] Text item2 = null;
    [SerializeField] Text item3 = null;
    [SerializeField] Text item4 = null;
    [SerializeField] Text item5 = null;
    [SerializeField] Text item6 = null;
    [SerializeField] Text item7 = null;
    [SerializeField] Text item8 = null;
    [SerializeField] Text item9 = null;

    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        item0.text = ItemType.Lamp.ToString();
        item1.text = ItemType.Key.ToString();
        item2.text = ItemType.Bones.ToString();
        item3.text = ItemType.RottenFlesh.ToString();
        item4.text = ItemType.Skulls.ToString();
        item5.text = ItemType.Flashlight.ToString();
        item6.text = ItemType.Brain.ToString();
        item7.text = ItemType.Potion.ToString();
        item8.text = ItemType.Arm.ToString();
        item9.text = ItemType.Head.ToString();
    }

    public void SetPickUpText(ItemType type)
    {
        switch(type)
        {
            case ItemType.Lamp:
                item0.text = type.ToString();
                item0.color = Color.green;
                break;
            case ItemType.Key:
                item1.text = type.ToString();
                item1.color = Color.green;
                break;
            case ItemType.Bones:
                item2.text = type.ToString();
                item2.color = Color.green;
                break;
            case ItemType.RottenFlesh:
                item3.text = type.ToString();
                item3.color = Color.green;
                break;
            case ItemType.Skulls:
                item4.text = type.ToString();
                item4.color = Color.green;
                break;
            case ItemType.Flashlight:
                item5.text = type.ToString();
                item5.color = Color.green;
                break;
            case ItemType.Brain:
                item6.text = type.ToString();
                item6.color = Color.green;
                break;
            case ItemType.Potion:
                item7.text = type.ToString();
                item7.color = Color.green;
                break;
            case ItemType.Arm:
                item8.text = type.ToString();
                item8.color = Color.green;
                break;
            case ItemType.Head:
                item9.text = type.ToString();
                item9.color = Color.green;
                break;
            default:
                Debug.LogWarning("Added one that doesnt exist");
                break;
        }
    }
}
