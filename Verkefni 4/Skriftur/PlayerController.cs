using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Breytur sem tengjast hreyfingu leikmanns
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    // Breytur sem tengjast lífsorku (heilsu) leikmanns
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    // Breytur sem tengjast tímabundnu ósnertanleika (óviðkvæmni)
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    // Breytur fyrir hreyfianimations
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Breytur sem tengjast eldflaugum (projectiles)
    public GameObject projectilePrefab;

    // Kallað þegar leikurinn byrjar
    void Start()
    {
        MoveAction.Enable(); // Virkja hreyfistýringar
        rigidbody2d = GetComponent<Rigidbody2D>(); // Ná í Rigidbody2D eininguna
        currentHealth = maxHealth; // Stillir upphaflega heilsu
        animator = GetComponent<Animator>(); // Ná í Animator eininguna
    }

    // Kallað á hverri ramma (frame)
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>(); // Les inntak frá leikmanni

        // Uppfærir stefnu ef leikmaður hreyfist
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        // Sendir gögn til Animator til að uppfæra hreyfingar
        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // Athugar hvort leikmaður sé ósnertanlegur og telur niður tíma
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        // Ýtt á 'C' til að skjóta eldflaug
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        // Ýtt á 'X' til að leita að NPC (vin)
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindFriend();
        }

        // Ýtt á 'V' til að fara í aðra senu
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(2);
        }
    }

    // FastUpdate fyrir eðlisfræðilega uppfærslu
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position); // Færir leikmann í nýja stöðu
    }

    // Breytir lífsorku leikmanns, t.d. þegar hann fær skaða eða heilsu
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return; // Leikmaður er ósnertanlegur, enginn skaði
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit"); // Ræsir högg animation
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Passar að heilsan fari ekki undir 0 eða yfir max
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth); // Uppfærir UI heilsumæli
    }

    // Skýtur eldflaug í stefnu sem leikmaður snýr
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 300); // Skýtur með krafti 300
        animator.SetTrigger("Launch");
    }

    // Leitar að NPC (vin) fyrir framan leikmann
    void FindFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                UIHandler.instance.DisplayDialogue(); // Byrjar samræðu UI
            }
        }
    }
}
