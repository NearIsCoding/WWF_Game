using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcesManager : MonoBehaviour
{
    public int maxInventory = 10;
    public int food;
    public int medicine;
    public int toys;

    private void Start()
    {
        food = 3;
        medicine = 2;
        toys = 1;
    }

    public void AddToInventory(int addFood, int addMedicine, int addToys)
    {
        for (int i = 0; i < addFood; i++)
        {
            food += 1;
            if (IsInventoryMax())
            {
                return;
            }
        }
        for (int i = 0; i < addMedicine; i++)
        {
            medicine += 1;
            if (IsInventoryMax())
            {
                return;
            }
        }
        for (int i = 0; i < addToys; i++)
        {
            toys += 1;
            if (IsInventoryMax())
            {
                return;
            }
        }
    }

    public void Feed()
    {
        if (HasResource(food))
        {
            GameController.chosenAnimal.data.satiety += 1;
            GameController.chosenAnimal.data.trust += 1;
            food -= 1;
            AnimalDetailsManager.Instance.UpdateResourcesUI();
        }
    }
    public void Heal()
    {
        if (HasResource(medicine))
        {
            GameController.chosenAnimal.data.health += 1;
            GameController.chosenAnimal.data.trust += 1;
            medicine -= 1;
            AnimalDetailsManager.Instance.UpdateResourcesUI();
        }
    }
    public void Play()
    {
        if (HasResource(toys))
        {
            GameController.chosenAnimal.data.happiness += 1;
            GameController.chosenAnimal.data.trust += 1;
            toys -= 1;
            AnimalDetailsManager.Instance.UpdateResourcesUI();
        }
    }

    public bool HasResource(int resource)
    {
        if (resource > 0)
        {
            return true;
        }
        return false;
    }

    public bool IsInventoryMax()
    {
        if (food + medicine + toys == maxInventory)
        {
            Debug.Log("Inventory is full");
            return true;
        }
        return false;
    }
    
    public void UpdateInventorysize()
    {
        maxInventory += 5;
    }
}
