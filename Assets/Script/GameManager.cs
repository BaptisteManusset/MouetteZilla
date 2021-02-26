using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    static public GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Duplicate GameManager");
        }
    }
    #endregion



    #region heal
    [Header("Vie")]
    public bool gameOver = false;

    public FloatReference heal;
    public FloatReference healMax;

    public UnityEvent gameOverAction;
    public UnityEvent winAction;

    public static float GetHealth() => GameManager.instance.heal.Value;
    public static void SetHealth(float value) => GameManager.instance.heal.Value = value;
    public static void AddHealth(float value) => GameManager.instance.heal.Value += value;
    #endregion

    #region score
    [Header("Score")]
    public FloatReference score;
    public float scoreToWin;
    public static bool win = false;
    public static void AddScore(float value) => GameManager.instance.score.Value += value;
    public static void SetScore(float value) => GameManager.instance.score.Value = value;
    public static float GetScore() => GameManager.instance.score.Value;
    #endregion

    [HideInInspector] public bool cursorIsLocked = true;


    [Header("Effect")]
    public GameObject seagull;
    public GameObject explosionPrefab;

    [Header("Technique")]
    public GameObject scrapCollector;

    private void Start()
    {
        SetScore(0);
        SetHealth(healMax.Value);
        GameManager.instance.gameOver = false;


        SoundManager.PlayMusic(SoundLibrary.instance.musicLevel, 1, true, false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        LockUpdate();


        if (score.Value >= scoreToWin)
        {
            Win();
        }

    }



    private void LockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIsLocked = true;
        }

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void Damage(float value)
    {
        if (GameManager.instance.gameOver) return;
        GameManager.instance.heal.Value -= value;


        if (GameManager.instance.heal.Value <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    [ContextMenu("Loose")]
    private void GameOver()
    {
        Time.timeScale = 0;
        GameManager.instance.gameOver = true;
        GameManager.instance.gameOverAction.Invoke();
        GameManager.instance.heal.Value = 0;
        cursorIsLocked = false;
    }

    [ContextMenu("Win")]
    private void Win()
    {
        Time.timeScale = 0;
        GameManager.win = true;
        GameManager.instance.winAction.Invoke();
        GameManager.instance.heal.Value = 999999999;
        cursorIsLocked = false;
    }



}
