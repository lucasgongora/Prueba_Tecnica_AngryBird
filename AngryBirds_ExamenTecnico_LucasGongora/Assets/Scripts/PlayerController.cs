
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    public float maxSpeed;
    private Rigidbody2D rb;
    private bool canDrag = true;
    private Vector3 distance;

    [SerializeField] private GameObject[] charactersPrefabs;
    //[SerializeField] private CharacterSelection characterSelection;
    [SerializeField] private int characterSelected;
    public int CharacterSelected { get => characterSelected; set => characterSelected = value; }

    void Start()
    {
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
    }
}
