using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalDetailsManager : MonoBehaviour
{
    public static AnimalDetailsManager Instance;

    public GameObject panel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI happinessText;
    public TextMeshProUGUI trustText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI medicineText;
    public TextMeshProUGUI toysText;

    public Image animalImage;
    public Button closeButton;
    public Button setFree;

    private void Awake()
    {
        Instance = this;
        HidePanel();

        if (closeButton != null)
            closeButton.onClick.AddListener(HidePanel);
    }

    public void ShowPanel()
    {
        var data = GameController.chosenAnimal.data;
        if(!panel.activeSelf){panel.SetActive(true);}
        
        nameText.text = data.animalName;
        healthText.text = $"Health: {data.health}/100";
        hungerText.text = $"Hunger: {data.satiety}/100";
        happinessText.text = $"Happiness: {data.happiness}/100";
        trustText.text = $"Trust: {data.trust}/100";

        if (animalImage != null && data.animalImage != null)
        {
            animalImage.sprite = data.animalImage;
            animalImage.gameObject.SetActive(true);
        }

        if (setFree != null)
            setFree.gameObject.SetActive(data.trust == 100);

        // NUEVO: Mostrar recursos
        PlayerResourcesManager resourceManager = FindObjectOfType<PlayerResourcesManager>();
        if (resourceManager != null)
        {
            foodText.text = $"Food: {resourceManager.food}";
            medicineText.text = $"Medicine: {resourceManager.medicine}";
            toysText.text = $"Toys: {resourceManager.toys}";
        }
    }

    public void UpdateResourcesUI()
    {
        PlayerResourcesManager resourceManager = FindObjectOfType<PlayerResourcesManager>();
        if (resourceManager != null)
        {
            foodText.text = $"Food: {resourceManager.food}";
            medicineText.text = $"Medicine: {resourceManager.medicine}";
            toysText.text = $"Toys: {resourceManager.toys}";
        }
    }


    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
