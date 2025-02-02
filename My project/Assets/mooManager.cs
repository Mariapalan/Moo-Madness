using UnityEngine;

public class MooManager : MonoBehaviour
{
    public static MooManager Instance;

    private float globalMooCooldown = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure it persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (globalMooCooldown > 0)
        {
            globalMooCooldown -= Time.deltaTime;
        }
    }

    public bool CanMoo()
    {
        return globalMooCooldown <= 0f;
    }

    public void TriggerMooCooldown()
    {
        globalMooCooldown = Random.Range(12f, 16f);  // Adjust this to control frequency
        Debug.Log("Global Moo Cooldown Activated! 🐄");
    }
}
