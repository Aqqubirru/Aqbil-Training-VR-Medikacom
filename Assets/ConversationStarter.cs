using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;  // Pastikan kamu menggunakan plugin atau paket ini

public class ConversationStarter : MonoBehaviour
{
    // Referensi untuk percakapan yang akan dimulai
    [SerializeField] private NPCConversation myConversation; // Percakapan yang dipicu oleh objek ini

    // Update is called once per frame
    void Update()
    {
        // Mengecek apakah pemain menekan tombol 'E' saat berada di dalam trigger
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartConversation();
        }
    }

    // Fungsi untuk memulai percakapan jika pemain berada dalam trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))  // Pastikan player memiliki tag "Player"
        {
            // Mengaktifkan prompt atau memberi tahu pemain bahwa mereka bisa menekan tombol untuk memulai percakapan
            Debug.Log("Tekan E untuk berbicara.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Jika player berada di dalam trigger dan menekan tombol 'E'
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();  // Memulai percakapan
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Logika ketika pemain keluar dari trigger, bisa menampilkan pesan atau reset status
            Debug.Log("Keluar dari area percakapan.");
        }
    }

    // Fungsi untuk memulai percakapan menggunakan ConversationManager
    private void StartConversation()
    {
        // Memastikan ConversationManager instance ada dan mulai percakapan
        if (myConversation != null)
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
        else
        {
            Debug.LogWarning("Conversation tidak ditentukan! Pastikan referensi myConversation diatur.");
        }
    }
}
