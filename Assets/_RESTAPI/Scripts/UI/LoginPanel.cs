//**************************************************
// LoginPanel.cs
//
// Battle Crafters LLC 2023
//**************************************************

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCrafters
{
	public class LoginPanel : MonoBehaviour
	{
		[SerializeField] GameObject loginPane;
		[SerializeField] TMP_InputField userNameInput;
		[SerializeField] TMP_InputField passwordInput;
		[SerializeField] Button loginButton;
		[SerializeField] Button loginButton2;
		[SerializeField] TextMeshProUGUI resultText;
		
		[SerializeField] GameObject logoutPane;

		void Start()
		{
			userNameInput.text = PlayerPrefs.GetString("RESTAPI_UserName", "");
			resultText.text = "";
			logoutPane.SetActive(false);
		}

		void Update()
		{
			loginPane.SetActive(!FauxClientServer.Instance.user.Validated);
			logoutPane.SetActive(FauxClientServer.Instance.user.Validated);

			if (loginPane.activeSelf)
			{
				loginButton.interactable = loginButton2.interactable = !string.IsNullOrEmpty(userNameInput.text) && !string.IsNullOrEmpty(passwordInput.text);
				if (FauxClientServer.Instance.user.FailedVerification)
				{
					resultText.text = "Login failed. Try again.";
				}
			}
		}

		public void ClickedLogin()
		{
			FauxClientServer.Instance.user.username = userNameInput.text;
			FauxClientServer.Instance.user.Password = passwordInput.text;

			resultText.text = "";

			PlayerPrefs.SetString("RESTAPI_UserName", userNameInput.text);

			Debug.Log("User is being validated");

			FauxClientServer.Instance.user.Validate();
		}

		public void ClickedLoginFail()
		{
			FauxClientServer.Instance.user.Validated = false;
			FauxClientServer.Instance.user.FailedVerification = true;
			passwordInput.text = "";
		}

		public void ClickedLogout()
		{
			resultText.text = "";
			FauxClientServer.Instance.user.Validated = false;
			FauxClientServer.Instance.user.FailedVerification = false;
			passwordInput.text = "";
			logoutPane.SetActive(false);
			loginPane.SetActive(true);
		}
	}
}
