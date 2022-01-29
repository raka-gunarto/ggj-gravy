using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCreation : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] faces;
    public Sprite[] eyes;
    public Sprite[] hairs;
    public Sprite[] mouths;
    public Sprite[] accessories;
    public Sprite[] noses;
    public GameObject customerprefab;

    void Start() {
        CreateCharacter();
    }

GameObject CreateCharacter()
{
    GameObject newCharacter=GameObject.Instantiate(customerprefab);
    newCharacter.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = faces[Random.Range(0,faces.Length-1)];
    newCharacter.transform.Find("Eyes").GetComponent<SpriteRenderer>().sprite = eyes[Random.Range(0,eyes.Length-1)];
    newCharacter.transform.Find("Hair").GetComponent<SpriteRenderer>().sprite = hairs[Random.Range(0,hairs.Length-1)];
    newCharacter.transform.Find("Mouth").GetComponent<SpriteRenderer>().sprite = mouths[Random.Range(0,mouths.Length-1)];
    if (Random.Range(0,1) <= 0.5)
        newCharacter.transform.Find("Accessories").GetComponent<SpriteRenderer>().sprite = accessories[Random.Range(0,accessories.Length-1)];
    newCharacter.transform.Find("Nose").GetComponent<SpriteRenderer>().sprite = noses[Random.Range(0,noses.Length-1)];

    return newCharacter;
}

}
