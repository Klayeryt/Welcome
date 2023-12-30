# Welcome

CS2 Plugin C#

- Requires CounterStrikeSharp version 143

# EN - Language

Create a folder for the plugin called Welcome

plugins/Welcome

Config/Welcome/Welcome.json

```
{
  "PluginName": "[Welcome] | ",
  "Timer": 10, // Welcome delay
  "WelcomePlayerOneEnable": "true", // "true"|"1"/"false"|"0"
  "WelcomePlayerAllEnable": "true", // "true"|"1"/"false"|"0"
  "DisconnectPlayerAllEnable": "true", // "true"|"1"/"false"|"0"
  "WelcomeText": " {RED}---------------------------------{ENTER} {LIGHTBLUE}Welcome on server {PLAYERNAME} {ENTER} Now map: {MAP} {ENTER} Players online: {PLAYERS}/{MAXPLAYERS} {ENTER} {RED}Your IP: {IPUSER} {ENTER} {RED}------------------------------ ", // Greeting for one player
  "disconnectAllText": " {RED} {PLAYERNAME} disconnect to reason: {REASON} ", // The message is all when the player is disconnected
  "WelcomeAllText": " {RED} {PLAYERNAME} connected to server {ENTER} His IP address: {IPUSER} ", // Announcement of the player's entry
  "ConfigVersion": 1
}
```

Variables:

"WelcomePlayerOneEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {STEAMID} - Player STEAMID
- {IPUSER} - Player IP Address
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

"WelcomePlayerAllEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {STEAMID} - Player STEAMID
- {IPUSER} - Player IP Address
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

"DisconnectPlayerAllEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

Colors:
{GREEN}
{BLUE}
{RED}
{SILVER}
{MAGENTA}
{GOLD}
{DEFAULT}
{LIGHTBLUE}
{LIGHTPURPLE}
{LIGHTRED}
{LIGHTYELLOW}
{YELLOW}
{GREY}
{LIME}
{OLIVE}
{ORANGE}
{DARKRED}
{DARKBLUE}
{BLUEGREY}
{PURPLE}

# Future plans:
- ~~To deal with colored text~~(Done)
- ~~Add more functions by type {MAXPLAYERS}/ {PLAYERNAME}~~(Done)
- Add a plugin to discord
- Micro-corrections

------------------------------------------------------------------------------------------------------------

# RU - Language
Создайте папку для плагина с названием Welcome

plugins/Welcome

Config/Welcome/Welcome.json

```
{
  "PluginName": "[Welcome] | ",
  "Timer": 10, // Задержка приветсвия для одного игрока
  "WelcomePlayerOneEnable": "true", // "true"|"1"/"false"|"0"
  "WelcomePlayerAllEnable": "true", // "true"|"1"/"false"|"0"
  "DisconnectPlayerAllEnable": "true", // "true"|"1"/"false"|"0"
  "WelcomeText": " {RED}---------------------------------{ENTER} {LIGHTBLUE}Welcome on server {PLAYERNAME} {ENTER} Now map: {MAP} {ENTER} Players online: {PLAYERS}/{MAXPLAYERS} {ENTER} {RED}Your IP: {IPUSER} {ENTER} {RED}------------------------------ ", // Приветсвие для одного игрока
  "disconnectAllText": " {RED} {PLAYERNAME} disconnect to reason: {REASON} ", // Уведомление о отключении игрока для всех
  "WelcomeAllText": " {RED} {PLAYERNAME} connected to server {ENTER} His IP address: {IPUSER} ", // Уведомление о заходе игрока для всех
  "ConfigVersion": 1
}
```

Переменные:

"WelcomePlayerOneEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {STEAMID} - Player STEAMID
- {IPUSER} - Player IP Address
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

"WelcomePlayerAllEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {STEAMID} - Player STEAMID
- {IPUSER} - Player IP Address
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

"DisconnectPlayerAllEnable":
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {REASON} - the reason for logging out of the server
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {PLAYERS} - The current number of players on the server

Цвета для чата:
{GREEN}
{BLUE}
{RED}
{SILVER}
{MAGENTA}
{GOLD}
{DEFAULT}
{LIGHTBLUE}
{LIGHTPURPLE}
{LIGHTRED}
{LIGHTYELLOW}
{YELLOW}
{GREY}
{LIME}
{OLIVE}
{ORANGE}
{DARKRED}
{DARKBLUE}
{BLUEGREY}
{PURPLE}

# Планируется в будущем:
- ~~Сделать цвета для чата~~(Готово)
- ~~Сделать больше переменных по типу: {MAXPLAYERS}/ {PLAYERNAME}~~(Готово)
- Добавить плагин в дискорд
- Микро-исправления
