using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;
    public Transform animalsContainer;
    public Button addAnimalButton;

    private void Start()
    {
        addAnimalButton.onClick.AddListener(AddNewAnimal);
    }

    void AddNewAnimal()
    {
        Instantiate(animalPrefab, animalsContainer);
    }
}

