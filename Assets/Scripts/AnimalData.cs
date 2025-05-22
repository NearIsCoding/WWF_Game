using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalData", menuName = "Game/Animal Data")]
public class AnimalData : ScriptableObject
{
    public string animalName;
    [Range(0, 100)] public int health;
    [Range(0, 100)] public int satiety; // (1 - hunger)
    [Range(0, 100)] public int happiness;
    [Range(0, 100)] public int trust;

    public Sprite animalImage;
}