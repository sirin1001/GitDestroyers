using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Extensions;
using Firebase.Auth;
using Gs2.Gs2Identifier.Model;

public class ManageInput : MonoBehaviour
{
    private string _email;
    private string _password;
    private FirebaseAuth _auth;
    ManageAuthLog _log;

    public void getSubmit()
    {
        _auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        _log = transform.Find("Log").GetComponent<ManageAuthLog>();

        var EmailTMP = transform.Find("Email").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>();
        if (EmailTMP.text != null)
        {
            _email = EmailTMP.text;
        }
        var PassTMP = transform.Find("Password").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>();
        if (PassTMP.text != null)
        {
            _password = PassTMP.text;
        }
        
        MailAuth();
    }
    public void getDontUseMail()
    {
        _auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        _log = transform.Find("Log").GetComponent<ManageAuthLog>();
    }
    void MailAuth()
    {
        _auth.CreateUserWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {   
                Debug.Log("[Debug]" + "CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }
    void AnonymouslyAuth()
    {
        _auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }
}
