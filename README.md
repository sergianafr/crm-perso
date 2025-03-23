# crm-perso
## Setting up google authentication
``dotnet add package Microsoft.AspNetCore.Authentication.Google --version 8.0.0``
- add to appsetting.json

``
"Authentication": {
    "Google": {
      "ClientId": "VOTRE_CLIENT_ID",
      "ClientSecret": "VOTRE_CLIENT_SECRET"
    }
  }``