using UnityEngine;
using UnityEngine.UI;

public class AnimalSlot : MonoBehaviour
{
    public string animalName = "No Name :c";
    public int age = 0;
    public string state = "Tired";
    public Sprite animalSprite;
    public Image iconImage;

    GameObject animalDetailsUI;
    private void Start()
    {
        if (iconImage != null){
            Debug.Log("iconImage is not Null");
            animalSprite = iconImage.sprite;
        }

        animalDetailsUI = FindObjectOfType<AnimalDetailsUI>().gameObject;

    }

    public void OnClickAnimal()
    {
        //AnimalDetailsUI.Instance.ShowAnimalDetails(this);
        animalDetailsUI.GetComponent<AnimalDetailsUI>().ShowAnimalDetails(this);
    }
}

