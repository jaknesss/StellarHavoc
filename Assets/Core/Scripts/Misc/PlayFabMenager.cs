using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabMenager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    

    public void RegisterButton(){

        if(passwordInput.text.Length < 6){
            messageText.text = "Password Troppo Corta!";
            return;
        }

        var request = new RegisterPlayFabUserRequest{
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        messageText.text = "Registered and Logged in!";
        messageText.color = Color.green;
    }

    public void LoginButton(){
        var request = new LoginWithEmailAddressRequest{
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    }

    public void resetPasswordButton(){
        var request = new  SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "E299D"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, onPasswordreset, OnError);
    }

    void onPasswordreset(SendAccountRecoveryEmailResult result){
        messageText.text = "Reset Email Spedita!";
    }


    // Start is called before the first frame update
    void Start(){
        //Login();   
    }

    void Login(){
        var request = new LoginWithCustomIDRequest {

            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result){
        messageText.text = "Logged in";
        messageText.color = Color.green;
    }


    void OnError(PlayFabError error){
        messageText.text = error.ErrorMessage;
        messageText.color = Color.red;
        Debug.Log(error.GenerateErrorReport());
    }



}
