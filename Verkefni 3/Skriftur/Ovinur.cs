using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;
using static UnityEditor.ShaderData;

public class Ovinur : MonoBehaviour
{
    public static int health = 100; //líf óvinar
    public TextMeshProUGUI stigTexti; //texti fyrir stig
    public TextMeshProUGUI healthTexti; //texti fyrir líf
    public Transform player; //leikmaður sem óvinur eltir
    private Rigidbody rb; //rigidbody óvinar
    private Vector3 movement; //stefna til að hreyfa
    public float detectionRadius = 20f; //radíus sem óvinur nemur leikmann
    public float hradi = 5f; //hreyfingarhraði
    private Animator animator; //til að spila hlaupaanim
    public bool hlaupa = false; //ekki notað núna
    private int teljari = 0; //telur högg frá kúlu

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //nær í rigidbody
        animator = GetComponent<Animator>(); //nær í animator
    }

    void Update()
    {
        Vector3 stefna = player.position - transform.position; //stefna að leikmanni
        float distanceToPlayer = stefna.magnitude; //fjarlægð að leikmanni

        if (distanceToPlayer <= detectionRadius)
        {
            stefna.y = 0f; //passar að óvinur fari ekki upp
            stefna.Normalize(); //normaliserar stefnuna
            movement = stefna;
            animator.SetTrigger("hlaupa"); //spilar hlaupaanim

            if (stefna != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(stefna); //snýr óvin að leikmanni
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5f * Time.deltaTime); //slétt snúningur
            }
        }
        else
        {
            movement = Vector3.zero; //ef leikmaður er fjarri
        }
    }

    private void FixedUpdate()
    {
        Hreyfing(movement); //kallar á hreyfingu í physics tíma
    }

    void Hreyfing(Vector3 stefna)
    {
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime)); //hreyfir óvin áfram
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Leikmaður fær í sig óvin");
            TakeDamage(10); //leikmaður tekur skaða
            gameObject.SetActive(false); //óvinur hverfur
        }
        if (collision.collider.tag == "kula")
        {
            teljari = teljari + 1; //telur skot
            if (teljari == 3)
            {
                teljari = 0; //núlstillir teljara
                Destroy(gameObject); //eyðir óvin
                main.stig += 2.5f; //bætir stig
                stigTexti.text = "Stig: " + main.stig.ToString(); //uppfærir stigtexta
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; //dregur úr lífi
        Debug.Log("health er núna" + (health).ToString());
        healthTexti.text = "Health: " + health.ToString(); //uppfærir líftexta
        if (health <= 0)
        {
            SceneManager.LoadScene(0); //fer í aðalvalmynd
            health = 100; //endurstillir líf
        }
    }
}
