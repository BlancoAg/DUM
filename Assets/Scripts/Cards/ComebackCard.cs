using UnityEngine;

public class ComebackCard : MonoBehaviour, ICard
{
    public Vector3 savedPosition;
    public bool mark = false;
    public GameObject ComeBackCardMark;

    public AudioClip clip;
    public AudioSource sauce;
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
        if (mark)
        {
            player.transform.position = savedPosition;
            //sauce.PlayOneShot(clip);
            Destroy(GameObject.Find("ComeBackCardMark(Clone)"));
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