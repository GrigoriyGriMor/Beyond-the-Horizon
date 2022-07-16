using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour {
    private static ConsoleScript instance;
    public static ConsoleScript Instance => instance;

    [SerializeField] private GameObject Console;
    [SerializeField] private Text ConsoleText;

    [SerializeField] private Button ClearConsole;

    [Header("FPS Target Frame")]
    [SerializeField] private int fpsTargetFrame = 144;

    void Awake() {
        instance = this;

        DontDestroyOnLoad(gameObject);

        ClearConsole.onClick.AddListener(() => CleareConsoleText());
    }

    private void Start() {
        if (fpsTargetFrame >= 30) Application.targetFrameRate = fpsTargetFrame;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Tilde)) {
            if (Console.activeInHierarchy) {
                Console.SetActive(false);
            }
            else {
                Console.SetActive(true);
            }
        }
    }

    private void OnEnable() {
        Application.logMessageReceived += AddConsoleText;
        Application.logMessageReceivedThreaded += AddConsoleText;
    }

    private void OnDisable() {
        Application.logMessageReceived -= AddConsoleText;
        Application.logMessageReceivedThreaded -= AddConsoleText;
    }

    public void ExitThisGame() {
        Application.Quit();
    }

    public void CleareConsoleText() {
        ConsoleText.text = "Вывод \n";
    }

    int i = 0;
    public void AddConsoleText(string error, string name = "Enter: ") {
        i += 1;
        ConsoleText.text += $"\n{i}) {name} {error}";
    }

    public void AddConsoleText(string logString, string stackTrace, LogType type) {
        i += 1;
        ConsoleText.text += $"\n{i}) {type} {logString} \n {stackTrace}";
    }
}
