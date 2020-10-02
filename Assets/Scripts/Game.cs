using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    private static Game instance;
    
    public MainMuffin mainMuffin;
    public GameObject littleMuffinPrefab;
    public float littleMuffinTossForce;
    public float littleMuffinLifespan;
    public TMP_Text numMuffinsLabel;

    public static MainMuffin MainMuffin => instance.mainMuffin;

    private int numMuffins;

    private int NumMuffins
    {
        get => numMuffins;
        set
        {
            numMuffins = value;
            UpdateNumMuffinsLabel();
        }
    }

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateNumMuffinsLabel();
    }

    private void UpdateNumMuffinsLabel()
    {
        numMuffinsLabel.text = $"Muffins: {NumMuffins}";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMuffinClicks();
        }
    }

    private void HandleMuffinClicks()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
        {
            if (hit.collider.gameObject.tag == "Muffin")
            {
                Debug.Log($"Clicked on the muffin");

                NumMuffins += 1;
                
                // Animate the main muffin
                mainMuffin.OnClicked();
                
                // Spawn a little muffin and toss it in a random direction
                SpawnLittleMuffin();
            }
        }
    }

    private void SpawnLittleMuffin()
    {
        // Spawn a little muffin and toss it away from the main muffin
        var muffin = Instantiate(littleMuffinPrefab, mainMuffin.transform.position, Quaternion.identity);
        muffin.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * littleMuffinTossForce);
        
        // Remove the little muffin after some time
        Destroy(muffin, littleMuffinLifespan);
        
        // Create a notification of a new muffin being created
        NotificationManager.Notify("+1");
    }
}