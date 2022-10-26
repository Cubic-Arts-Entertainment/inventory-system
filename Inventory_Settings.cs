using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Settings : MonoBehaviour
{
    [Header("Inventory Settings")][Space(5)]
    public int collectionDistance;
    public int inventorySize;
    public string inventoryTag;
    [TextArea]
    public string inventoryFullMessage;
    
    [Header("Inputs")][Space(5)]
    public KeyCode interactiveKey = KeyCode.E;
    public KeyCode firstItem = KeyCode.Alpha1;
    public KeyCode secondItem = KeyCode.Alpha2;
    public KeyCode thirdtem = KeyCode.Alpha3;
    public KeyCode fourthItem = KeyCode.Alpha4;
    public KeyCode fifthItem = KeyCode.Alpha5;
}
