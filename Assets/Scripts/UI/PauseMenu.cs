using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject tutUI;
    public GameObject tutUILarge;
    public GameObject pauseMenuUI;
    public GameObject ingameUI;
    public GameObject victoryUI;
    public GameObject defeatUI;
    static int playerKillCounter;
    static int enemyKillCounter;
    public TextMeshProUGUI enemyKillCounterValue;
    public TextMeshProUGUI playerKillCounterValue;

    public TextMeshProUGUI enemyManaGatheredValue;
    public TextMeshProUGUI enemyManaSpentValue;

    public TextMeshProUGUI playerManaGatheredValue;
    public TextMeshProUGUI playerManaSpentValue;


    public TextMeshProUGUI basicMinionSpawnCounterValue;
    public TextMeshProUGUI rangedMinionSpawnCounterValue;
    public TextMeshProUGUI tankMinionSpawnCounterValue;
    public TextMeshProUGUI damageMinionSpawnCounterValue;
    public TextMeshProUGUI allMinionSpawnCounterValue;

    public TextMeshProUGUI enemyBasicMinionSpawnCounterValue;
    public TextMeshProUGUI enemyRangedMinionSpawnCounterValue;
    public TextMeshProUGUI enemyTankMinionSpawnCounterValue;
    public TextMeshProUGUI enemyDamageMinionSpawnCounterValue;
    public TextMeshProUGUI enemyAllMinionSpawnCounterValue;

    public bool tut = false;
    public int tutValue = 0;
    public GameObject prev;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "EndScene")
        {
            if (tut == true)
            {
                if (tutValue == 0)
                {
                    SetUI();
                    tutUI.SetActive(true);
                    tutUI.transform.GetChild(1).GetComponent<TMP_Text>().SetText("Welcome to Castle Fight");
                    tutUI.transform.GetChild(2).GetComponent<TMP_Text>().SetText("In Castle Fight you have to destroy the Enemys Castle. It is recommended that you check out this Tutorial if you didnt play before.");


                }
                else if (tutValue == 1)
                {
                    SetUI();
                    tutUI.SetActive(true);
                    prev.SetActive(true);
                    tutUI.transform.GetChild(1).GetComponent<TMP_Text>().SetText("Tutorial");
                    tutUI.transform.GetChild(2).GetComponent<TMP_Text>().SetText("The next Pages will guide you trough the Main parts of the Game. You can skip the Tutorial at any Time by clicking the red cross in the upper right corner.");
                }
                else if (tutValue == 2)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Mana / Manabar");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("While playing you will constantly recieve Mana. Below you see a Example how your Manabar looks like.<br>The Number in the Crystal on the left displays your current Mana.<br>10 Mana is the Maximum u can get.<br>  If enough Mana was collected you can start spawn Minions");
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    tutUILarge.SetActive(true);
                }
                else if (tutValue == 3)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Minions / Spawn");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("You can choose between 4 Minions, which all have different costs and unique Skills in Fight.");

                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    tutUILarge.SetActive(true);


                }
                else if (tutValue == 4)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Minions / Basic Minion");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("A single hardy melee Soldier<br>Medium Health<br>Average Damage<br>Can be spawned by pressing the Card or with the Shortcut Q");
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    tutUILarge.SetActive(true);


                }
                else if (tutValue == 5)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Minions / Ranged Minion");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("A old wise mage casting Fireballs over range at your enemies<br>Low Health<br>Decent Damage<br>Can be spawned by pressing the Card or with the Shortcut W");
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    tutUILarge.SetActive(true);


                }
                else if (tutValue == 6)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Minions / Tank Minion");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("A extreme hardy rock Golem<br>Very High Health<br>Low Damage<br>Can be spawned by pressing the Card or with the Shortcut E");
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    tutUILarge.SetActive(true);

                }
                else if (tutValue == 7)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("Minions / Damage Minion");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("A deadly faction changed Orc who was born to kill<br>High Health<br>High Damage<br>Can be spawned by pressing the Card or with the Shortcut R");
                    tutUILarge.SetActive(true);
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.SetActive(true);

                }
                else if (tutValue == 8)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("GamePlay / MidTower");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("At the middle of the path to the opponents Castle you will pass a magical Tower. If you are able to capture the Tower you will get a slightly Manaregenration boost.<br> The same applies to your opponent");
                    tutUILarge.SetActive(true);
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(true);

                }
                else if (tutValue == 9)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("GamePlay / Killcounter");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("In the top left corner of the in-game screen you can check your kills.<br>Every 5 Kills you will get 1 charge of the Ultimate");
                    tutUILarge.SetActive(true);
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);

                }
                else if (tutValue == 10)
                {
                    SetUI();
                    tutUILarge.transform.GetChild(2).GetComponent<TMP_Text>().SetText("GamePlay / Ultimate");
                    tutUILarge.transform.GetChild(3).GetComponent<TMP_Text>().SetText("If you achieve 5 kills you can Shoot missles from heaven to damage all enemies on field.<br>The charges can be stacked.<br>Can be used by pressing the Icon on the left or with the Shortcut T");
                    tutUILarge.SetActive(true);
                    tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    tutUILarge.transform.GetChild(6).gameObject.transform.GetChild(0).GetComponent<TMP_Text>().SetText("Start Game");
                    tutUILarge.transform.GetChild(6).GetComponent<Image>().color = new Color(255, 0, 0);
                }
                else if (tutValue == 11)
                {
                    CancelTut();
                }
            }
        }
        /*
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            VictoryScreen();
            Debug.Log("NIGGA");
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
       
    }

    public void SetUI()
    {
        if(gameObject.tag != "EndScene")
        { 
        prev.SetActive(false);
        Time.timeScale = 0f;
        ingameUI.SetActive(false);
        tutUI.SetActive(false);
        tutUILarge.SetActive(false);

        //ManaBarBild
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //AllCardsBild
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);

        //MidTowerBild
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(false);

        //SingleCardsBilder
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
        //KillCounterBild
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
        //Ultimate
        tutUILarge.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
    }

    private void Start()
    {
        prev = gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;
        tut = MainMenu.Tutorial;

        if (gameObject.tag == "EndScene")
        {
            int p = Stats.PlayerKillCounter;
            int e = Stats.EnemyKillCounter;
            float pmt = Stats.PlayerManaGathered;
            float pms = Spawn.PlayerManaSpent;

            float ept = EnemyAI.EnemyManaGathered;
            float eps = EnemyAI.EnemyManaSpent;

            int bm = Spawn.BasicMinionSpawnCounter;
            int rm = Spawn.RangedMinionSpawnCounter;
            int tm = Spawn.TankMinionSpawnCounter;
            int dm = Spawn.DamageMinionSpawnCounter;
            int allm = bm + rm + tm + dm;

            int ebm = EnemyAI.EnemyBasicMinionSpawnCounter;
            int erm = EnemyAI.EnemyRangedMinionSpawnCounter;
            int etm = EnemyAI.EnemyTankMinionSpawnCounter;
            int edm = EnemyAI.EnemyDamageMinionSpawnCounter;
            int eallm = ebm + erm + etm + edm;



            enemyKillCounterValue.SetText(string.Format("{0}", e));
            playerKillCounterValue.SetText(string.Format("{0}", p));

            playerManaGatheredValue.SetText(string.Format("{0}", pmt + pms));
            playerManaSpentValue.SetText(string.Format("{0}", pms));

            enemyManaGatheredValue.SetText(string.Format("{0}", ept + eps));
            enemyManaSpentValue.SetText(string.Format("{0}", eps));

            basicMinionSpawnCounterValue.SetText(string.Format("x {0}", +bm));
            rangedMinionSpawnCounterValue.SetText(string.Format("x {0}", +rm));
            tankMinionSpawnCounterValue.SetText(string.Format("x {0}", +tm));
            damageMinionSpawnCounterValue.SetText(string.Format("x {0}", +dm));
            allMinionSpawnCounterValue.SetText(string.Format("x {0}", +allm));

            enemyBasicMinionSpawnCounterValue.SetText(string.Format("x {0}", +ebm));
            enemyRangedMinionSpawnCounterValue.SetText(string.Format("x {0}", +erm));
            enemyTankMinionSpawnCounterValue.SetText(string.Format("x {0}", +etm));
            enemyDamageMinionSpawnCounterValue.SetText(string.Format("x {0}", +edm));
            enemyAllMinionSpawnCounterValue.SetText(string.Format("x {0}", +eallm));
        }
        //tricks out bug
        if (ingameUI != null)
        {
        ingameUI.SetActive(false);
        ingameUI.SetActive(true);
        }
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void Resume()
    {
        if (ingameUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        ingameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        if(ingameUI != null)
        {
        ingameUI.SetActive(false);
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ContinueDefeat()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void VictoryScreen()
    {
        StartCoroutine(VictoryFadeTo(0.7f, 3f));
    }
    public void DefeatScreen()
    {
        StartCoroutine(DefeatFadeTo(0.7f, 3f));
    }
    IEnumerator VictoryFadeTo(float aValue, float aTime)
    {
        ingameUI.SetActive(false);
        victoryUI.SetActive(true);
        float tscale = 1.0f;
        float alpha = gameObject.transform.GetChild(2).GetComponent<Image>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            tscale -= Time.deltaTime / aTime;
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            Time.timeScale = tscale;
            gameObject.transform.GetChild(2).GetComponent<Image>().color = newColor;
            yield return null;
        }
    }

    IEnumerator DefeatFadeTo(float aValue, float aTime)
    {
        ingameUI.SetActive(false);
        defeatUI.SetActive(true);
        float tscale = 1.0f;
        float alpha = gameObject.transform.GetChild(3).GetComponent<Image>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            tscale -= Time.deltaTime / aTime;
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            Time.timeScale = tscale;
            gameObject.transform.GetChild(3).GetComponent<Image>().color = newColor;
            yield return null;
        }
    }


    public void CancelTut()
    {
        SetUI();
        tut = false;
        Time.timeScale = 1f;
        tutUI.SetActive(false);
        ingameUI.SetActive(true);
    }
    public void NextTut()
    {
        tutValue++;
        Debug.Log("tutValue" + tutValue);
    }
    public void PrevTut()
    {
        tutValue--;
        Debug.Log("tutValue" + tutValue);
    }
}
