using UnityEngine;

public class StoneStance : MonoBehaviour, ICard
{
    public bool stoned = false;
    private bool ready;
    public GameObject Wind;
    private ParticleSystem WindEffect;
    public GameObject StoneStanceIcon;

    public float weight;

    void Start()
    {
        // Initialize WindEffect if needed
        // WindEffect = Wind.GetComponent<ParticleSystem>();
        // WindEffect.Stop();
    }

    public string tell_description()
    {
        return "test";
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        // Since we are casting directly, this can be simplified or removed
        ready = status;
    }

    public void cast_card(GameObject handGameObject)
    {
        var player = handGameObject.GetComponent<PlayerMainScript>();
        if (ready)
        {
            // Ensure the stone status is updated and visual/sound effects are triggered
            handGameObject.GetComponent<Hand>().PlaySound();
            // WindEffect.Play(); // Uncomment if you want to play the wind effect
            player.stone_status(true, weight);
        }
    }

    void Update()
    {
        // Get all objects tagged as "Player" and "Puppet"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] puppets = GameObject.FindGameObjectsWithTag("Puppet");
        GameObject[] allObjects = new GameObject[objects.Length + puppets.Length];
        objects.CopyTo(allObjects, 0);
        puppets.CopyTo(allObjects, objects.Length);

        foreach (GameObject obj in allObjects)
        {
            if (Input.GetMouseButton(1) && obj.GetComponent<PuppetController>().inControl) // Check if left mouse button is being held down and object is in control
            {
                cast_card(obj);
            }
            else
            {
                // Reset status when the button is released
                var player = obj.GetComponent<PlayerMainScript>();
                if (player.stoned)
                {
                    player.stone_status(false, weight);
                }
                ready = false;
            }
        }
    }
}
