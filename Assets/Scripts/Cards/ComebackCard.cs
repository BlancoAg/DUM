using UnityEngine;

public class ComebackCard : MonoBehaviour, ICard
{
    public Vector3 savedPosition;
    public bool mark = false;
    public GameObject ComeBackCardMark;

    
    public AudioSource sauce;
    public AudioClip clip;
    public AudioClip cancel;

    public AudioClip NoneToDestroy;
    private bool ready;

    public string tell_description()
    {
        return "test";
    }

    public void card_preparation(bool status, GameObject handGameObject)
    {
        if (!status)
        {
            ready = false;
            return;
        }
        ready = status;
    }

public void cast_card(GameObject handGameObject)
{
    var player = handGameObject;

    // Verificar si la tecla Alt está presionada
    if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
    {
        // Verificar si existe una marca antes de intentar destruirla
        GameObject existingMark = GameObject.Find("ComeBackCardMark(Clone)");
        if (existingMark != null)
        {
            Destroy(existingMark);
            sauce.PlayOneShot(cancel); // Reproducir sonido al destruir la marca
            mark = false;
        }
        else
        {
            sauce.PlayOneShot(NoneToDestroy); // Reproducir sonido si no hay marca que destruir
        }
    }
    else
    {
        if (mark)
        {
            player.transform.position = savedPosition;
            sauce.PlayOneShot(clip);
            GameObject existingMark = GameObject.Find("ComeBackCardMark(Clone)");
            if (existingMark != null)
            {
                Destroy(existingMark);
                sauce.PlayOneShot(cancel); // Reproducir sonido al destruir la marca
            }
            mark = false;
        }
        else
        {
            savedPosition = player.transform.position;
            Vector3 pos = player.transform.position;
            Instantiate(ComeBackCardMark, pos + new Vector3(0, 1, 0), Quaternion.identity);
            mark = true;
        }
        ready = false;
    }
}
}