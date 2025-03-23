using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // Breytur fyrir hreyfingu
    public float speed = 0.2f; // Hraði áfram og aftur á bak
    public float sideways = 0.2f; // Hreyfing til hliðar
    public float jump = 0.2f; // Stökkhæð

    // Stigatalning
    public static int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        Debug.Log("byrja"); // Prentar "byrja" í console þegar leikurinn byrjar
    }

    // Uppfært í hverjum ramma
    void FixedUpdate()
    {
        // Hreyfing leikmanns
        if (Input.GetKey(KeyCode.UpArrow)) // Áfram
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Til baka
        {
            transform.position += -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Vinstri
        {
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space)) // Hoppa
        {
            transform.position += transform.up * jump;
        }

        // Snúa leikmanni
        if (Input.GetKey("f")) // Snúa til hægri
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g")) // Snúa til vinstri
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey("q")) // Núllstilla snúning
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        // Athugar hvort leikmaður hefur dottið af pallinum
        if (transform.position.y <= -1)
        {
            Endurræsa();
        }

        // Athugar hvort leikmaður hefur náð markmiði
        if (transform.position.x >= 30)
        {
            LoadNextScene();
        }
    }

    // Hleður næsta borð eða byrjar aftur ef leikurinn er búinn
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Hleður næsta borð
        }
        else
        {
            SceneManager.LoadScene(0); // Byrjar aftur ef búið er með öll borð
        }
    }

    // Þegar leikmaður rekst á eitthvað
    void OnCollisionEnter(Collision collision)
    {
        // Ef leikmaður rekst á hlutur
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count += 1; // Bætir við 1 stigi
            SetCountText(); // Uppfærir stigatöflu
        }
        if (collision.collider.tag == "peningur")
        {
            collision.collider.gameObject.SetActive(false);
            count += 5; // Bætir við 5 stigum
            SetCountText();
        }
        if (collision.collider.tag == "hindrun")
        {
            collision.collider.gameObject.SetActive(false);
            count -= 3; // Dregur 3 stig frá
            SetCountText();
        }
    }

    // Uppfærir textann sem sýnir stig
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        // Ef leikmaður hefur engin stig eða minna
        if (count <= 0)
        {
            this.enabled = false; // Koma í veg fyrir að leikmaður hreyfist
            countText.text = "Dauður " + count.ToString() + " stigum";

            StartCoroutine(Bida()); // Bíður í 2 sekúndur og endurræsir leikinn
        }
    }

    // Bíður í 2 sekúndur og endurræsir leikinn
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(2);
        Endurræsa();
    }

    // Byrjar leikinn frá fyrsta borði
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }

    // Endurræsir leikinn
    public void Endurræsa()
    {
        SceneManager.LoadScene(0);
    }
}
