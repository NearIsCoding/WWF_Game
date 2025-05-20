using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimalDetailsUI : MonoBehaviour
{
    public static AnimalDetailsUI Instance;

    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text stateText;
    public Image animalImage;
    public Button closeButton;

    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
        
        panel.SetActive(false);
        closeButton.onClick.AddListener(ClosePanel);
    }

    public void ShowAnimalDetails(AnimalSlot animal)
    {
        panel.SetActive(true);
        nameText.text = "Nombre: " + animal.animalName;
        ageText.text = "Edad: " + animal.age;
        stateText.text = "Estado: " + animal.state;
        animalImage.sprite = animal.animalSprite;

        
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}

