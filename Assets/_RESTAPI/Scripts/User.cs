//**************************************************
// User.cs
//
// Battle Crafters LLC 2023
//
//This would be a common class shared with client and server
//**************************************************

using UnityEngine;

namespace BattleCrafters
{
	[System.Serializable]
	public class User
	{
		public string username; //could be name or email
		public string password;

		public string Password
		{
			get => Utility.XOREncryptDecrypt(password);
			set => password = Utility.XOREncryptDecrypt(value);
		}

		bool _validated = false;
		public bool Validated
		{
			get => _validated;
			set => _validated = value;
		}

		bool _failedVerification = false;
		public bool FailedVerification
		{
			get => _failedVerification;
			set => _failedVerification = value;
		}

		//Unity advises against using constructors but...
		//public User(string userID, string password)
		//{
		//	this.userID = userID;
		//	this.password = password;
		//}

		public void Validate()
		{
			Validated = false;

			Debug.Log("Encrytped: " + password);

			string jstring = ToJSON();
			Debug.Log("JSON: " + jstring);

			Password = password;
			Debug.Log("Decrytped: " + password);

			FauxClientServer.Instance.CLIENT_Post("Validate");

			FromJSON(jstring);
		}

		public string ToJSON()
		{
			return JsonUtility.ToJson(this);
		}

		public void FromJSON(string jstring)
		{
			User u = JsonUtility.FromJson<User>(jstring);
			username = u.username;
			password = u.password;
		}
    }
}
