using UnityEngine;

public class HabitDetector : MonoBehaviour
{
    private AnimalDisplay currentAnimal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Animal is in range. Press E to view details.");
        AnimalDisplay animal = other.GetComponent<AnimalDisplay>();
        GameController.chosenAnimal = animal; 
        if (animal != null)
        {
            currentAnimal = animal;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        AnimalDisplay animal = other.GetComponent<AnimalDisplay>();
        if (animal != null && animal == currentAnimal)
        {
            currentAnimal = null;
            AnimalDetailsManager.Instance.HidePanel();
        }
    }

    private void Update()
    {
        if (currentAnimal != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Opening animal panel.");
            AnimalDetailsManager.Instance.ShowPanel();
        }
    }
}
