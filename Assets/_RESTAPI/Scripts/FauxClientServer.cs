//**************************************************
// FauxClientServer.cs
//
// Battle Crafters LLC 2023
//
// This is just a mimic of a client/server
//**************************************************

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace BattleCrafters
{
	public class FauxClientServer : MonoBehaviour
	{
		//Singleton
		public static FauxClientServer Instance;

		public User user;

		void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
			DontDestroyOnLoad(this);

			user = new User();
		}

		void Start()
		{
			
		}
	
		void Update()
		{
			
		}

		//my example uses a PHP script instead of a dedicated server.  But the concept is the same.
		public void CLIENT_Post(string whateverelse = "")
		{
			StartCoroutine(CRCLIENT_Post(whateverelse));
		}

		IEnumerator CRCLIENT_Post(string whateverelse = "")
		{
			var request = new UnityWebRequest();
			request.url = "https://www.battlecrafters.com/php/validateTEST.php";
			request.method = UnityWebRequest.kHttpVerbPOST;
			request.downloadHandler = new DownloadHandlerBuffer();
			request.uploadHandler = new UploadHandlerRaw(string.IsNullOrEmpty(whateverelse) ? null : Encoding.UTF8.GetBytes(whateverelse));
			request.SetRequestHeader("Accept", "application/json");
			request.SetRequestHeader("Content-Type", "application/json");
			request.SetRequestHeader("Authorization", user.ToJSON());
			request.timeout = 60;

			yield return request.SendWebRequest();

			if (request.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(request.error);
			}
			else
			{
				string result = request.downloadHandler.text;

				//Lets say the server returned the word BADUSER if user was invalid
				if (result.Contains("BADUSER"))
				{
					user.Validated = false;
					user.FailedVerification = true;
					yield return null;
				}
				else
				{
					//lets say we got a valid response from the server that said the user was validated
					user.Validated = true;
					user.FailedVerification = false;

					//the server should respond with token.  Save it to playerprefs.  Just getting it from user now.
					string tokenresponse = user.ToJSON();
					PlayerPrefs.SetString("RESTAPI_UserToken", tokenresponse);
				}

				//do other stuff?
			}
		}
	}
}
