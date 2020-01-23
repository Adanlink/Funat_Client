# Funat_Client
## Description
This repository saves the client made for a Project of Investigation for my highschool. It is made with Unity. Also the server for which it is thought is for [Funat Server](https://github.com/Adanlink/Funat_Server "Funat Server").

![In Game](https://i.gyazo.com/a30f74c98c0d09cb41e325eb7c33bfc8.png "In Game")
## How to make it work
### Preparation
I recommend you to install [Unity Hub](https://unity3d.com/es/get-unity/download "Unity Hub").
Once you add this repository as a Unity Project it will tell you the version used by it. Then you can download the right version of the Editor and open it.

### Important note
The IP and Port which the client uses to connect are hardcoded in multiple places (and that should not be like that, I know):
- Assets/Scripts/UserInterface/StartMenu/Login.prefab
- Assets/Scripts/UserInterface/StartMenu/Register.prefab
- Assets/Scripts/Networking/NetworkInitializer.prefab

### Finally
When you end having the Project ready then build it and try running it.