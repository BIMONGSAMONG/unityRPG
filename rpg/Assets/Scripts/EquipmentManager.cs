using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;
    
    void Awake()
    {
        instance = this;
    }

    #endregion

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    Equipment[] currentEquitment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChaged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChaged onEquipmentChaged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots =System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquitment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItems();
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = Unequip(slotIndex);

        if(onEquipmentChaged != null)
        {
            onEquipmentChaged.Invoke(newItem, oldItem);
        }

        currentEquitment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip (int slotIndex)
    {
        if(currentEquitment[slotIndex] != null)
        {
            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }
            Equipment oldItem = currentEquitment[slotIndex];
            inventory.Add(oldItem);

            currentEquitment[slotIndex] = null;

            if (onEquipmentChaged != null)
            {
                onEquipmentChaged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i= 0; i<currentEquitment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }

    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
