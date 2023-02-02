# RESTAPI
rest api test

Objectives:

1. Develop a REST API that accepts user credentials and returns a JWT token if the credentials are valid.
2. Store the JWT token securely on the client side and retrieve it for subsequent requests.
3. Implement a request handler that sends the JWT token in the Authorization header for all authenticated requests.
4. Implement a request handler that verifies the JWT token on the server side and returns an error if the token is invalid.

Instructions:

0. Create a new Unity project.
1. Implement a REST API that accepts the user's email and password and returns a JWT token if the credentials are valid.
2. Store the JWT token securely on the client side using the PlayerPrefs class.
3. Implement a request handler that sends the JWT token in the Authorization header for a mockup profiles endpoint.
4. Implement a request handler that verifies the JWT token on the server side and returns an error if the token is invalid.
5. Create a simple UI that allows the player to log in and log out, and displays the results of the authentication process.
Test the authentication process by logging in and making authenticated request that would return player profile.

Open the project in Unity.
Run the project. 
User login will ask for username and password.
