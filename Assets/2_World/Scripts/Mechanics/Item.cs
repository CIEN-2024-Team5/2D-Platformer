using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine }
    [SerializeField] public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    public string itemID;

    [Header("Sound")]
    public AudioClip pickUpSound;
    private AudioSource audioSource;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource ������Ʈ�� �����ϴ�.");
        }
        else
        {
            audioSource.playOnAwake = false; // ������� �ڵ����� ������� �ʵ��� ����
        }
        // �������� �̹� ȹ��Ǿ����� Ȯ���Ͽ�, ȹ��Ǿ����� ��Ȱ��ȭ
        if (PlayerPrefs.GetInt(itemID, 0) == 1)
        {
            //gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                // �������� ȹ�� ���·� ����
                PlayerPrefs.SetInt(itemID, 1);
                PlayerPrefs.Save();

                if (itemID == "DoubleJumpItem")
                {
                    PlayerPrefs.SetInt("DoubleJumpEnabled", 1);
                    PlayerPrefs.Save();
                }
                if (itemID == "BulsonShotRedItem")
                {
                    PlayerPrefs.SetInt("BulsonShotRedEnabled", 1);
                    PlayerPrefs.Save();
                }
                if (itemID == "BulsonShotBlueItem")
                {
                    PlayerPrefs.SetInt("BulsonShotBlueEnabled", 1);
                    PlayerPrefs.Save();
                }

                if (audioSource != null && pickUpSound != null)
                {
                    Debug.Log("����� ���");
                    audioSource.clip = pickUpSound;
                    audioSource.Play();
                }

                //InventoryManager.Instance.AddItem(this);

                // Add the object to the PickedUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                StartCoroutine(DisableAfterSound());
                // Disable
                //gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                // Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            case InteractionType.NONE:
                // NONE Ÿ�Կ����� �⺻������ �ƹ��͵� ���� ����
                break;
            default:
                // Used for custom event
                break;
        }

        // Invoke the custom event
        customEvent.Invoke();
    }

    private IEnumerator DisableAfterSound()
    {
        // ���尡 ����Ǵ� �ð��� ��ٸ� �� ������Ʈ�� ��Ȱ��ȭ
        yield return new WaitForSeconds(audioSource.clip.length);
        gameObject.SetActive(false);
    }
}
