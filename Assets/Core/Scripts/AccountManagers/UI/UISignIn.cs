using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISignIn : MonoBehaviour {

    [SerializeField] TextMeshProUGUI errorText;
    [SerializeField] Canvas canvas;

    public GameObject menuLoginButton;
    public GameObject usernameLoggedIn;
    string username, password;


    void OnEnable () {
        UserAccountManager.OnSignInFailed.AddListener (OnSignInFailed);
        UserAccountManager.OnSignInSuccess.AddListener (OnSignInSuccess);
    }

    void OnDisable () {
        UserAccountManager.OnSignInFailed.RemoveListener (OnSignInFailed);
        UserAccountManager.OnSignInSuccess.RemoveListener (OnSignInSuccess);
    }

    void OnSignInFailed (string error) {
        errorText.gameObject.SetActive(true);
        errorText.text = error;
    }

    void OnSignInSuccess () {
        menuLoginButton.SetActive(false);
        usernameLoggedIn.SetActive(true);
        errorText.color = Color.green; 
        errorText.text = "Succesfull Login";
    }

    public void UpdateUsername (string _username) {
        username = _username;
    }

    public void UpdatePassword (string _password) {
        password = _password;
    }

    public void SignIn () {
        UserAccountManager.Instance.SignIn (username, password);
    }

}