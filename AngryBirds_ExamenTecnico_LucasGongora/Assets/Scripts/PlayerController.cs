
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    public float maxSpeed;
    private Rigidbody2D rb;
    private bool canDrag = true;
    private Vector3 distance;
    [SerializeField] private GameObject prefabBomb;
    [SerializeField] private GameObject prefabCharacterDivisible1;
    [SerializeField] private GameObject prefabCharacterDivisible2;
    [SerializeField] private GameObject[] charactersPrefabs;
    [SerializeField] private int characterSelected;
    public int CharacterSelected { get => characterSelected; set => characterSelected = value; }

    void Start()
    {
        prefabCharacterDivisible1 = GameObject.Find("PlayerBlue");
        prefabCharacterDivisible2 = GameObject.Find("PlayerBlue");
        prefabBomb = GameObject.Find("BombExplotion");
        prefabBomb.SetActive(false);
        characterSelected = PlayerPrefs.GetInt("selectedCharacter");
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerReady();
        PlayerGo();
    }

    private void PlayerReady()
    {
        charactersPrefabs = GameObject.FindGameObjectsWithTag("CharactersPrefabs");
        foreach (var item in charactersPrefabs)
        {
            item.SetActive(false);
        }
    }

    private void PlayerGo()
    {
        charactersPrefabs[characterSelected].SetActive(true);
    }

    private void OnMouseDrag()
    {
        if (!canDrag) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = mousePosition - pivot.position;
        distance.z = 0;

        if (distance.magnitude > springRange)
        {
              distance = distance.normalized * springRange;
        }
        transform.position = distance + pivot.position;
    }

    private void OnMouseUp()
    {
        if (!canDrag) return;
        canDrag = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -distance.normalized * maxSpeed * distance.magnitude / springRange;
        if (characterSelected !=0 && characterSelected != 2)
        {
            Invoke("ExplotingBombCharacter", 3f);
        }
        else
        {
            if (characterSelected != 0 && characterSelected != 1)
            {
                Invoke("DivisionCharacter", 0.5f);
            }
        } 
    }

    private void ExplotingBombCharacter()
    {
        prefabBomb.SetActive(true);
        charactersPrefabs[characterSelected].SetActive(false);
        Destroy(prefabBomb, 0.2f);
    }
    private void DivisionCharacter()
    {
        Instantiate(prefabCharacterDivisible1, transform.position * 0.1f, Quaternion.identity);
        Instantiate(prefabCharacterDivisible2, transform.position * -0.001f, Quaternion.identity);
    }
}
