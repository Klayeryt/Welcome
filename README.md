# Welcome

CS2 Plugin C#

# EN - Language

Config/Welcome/Welcome.json

```
{
  "PluginName": "[Welcome] | ",
  "Timer": 10,
  "WelcomeText": " {RED}---------------------------------{ENTER} {LIGHTBLUE} Welcome on server {PLAYERNAME} {ENTER} Now map: {MAP} {ENTER} Players online: {PLAYERS}/{MAXPLAYERS} {ENTER}{RED}------------------------------ ", // Greeting for the player
  "disconnectAllText": " {RED} {PLAYERNAME} disconnect to reason: {REASON} ", // disconnect message for all
  "WelcomeAllText": " {RED} {PLAYERNAME} connected to server", // Welcome message for all
  "ConfigVersion": 1
}
```

Variables:
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {MAXPLAYERS} - The maximum number of players on the server
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

Config/Welcome/Welcome.json

```
{
  "PluginName": "[Welcome] | ",
  "Timer": 10,
  "WelcomeText": " {RED}---------------------------------{ENTER} {LIGHTBLUE} Welcome on server {PLAYERNAME} {ENTER} Now map: {MAP} {ENTER} Players online: {PLAYERS}/{MAXPLAYERS} {ENTER}{RED}------------------------------ ", // Приветствие только для одного игрока(который зашёл на сервер).
  "disconnectAllText": " {RED} {PLAYERNAME} disconnect to reason: {REASON} ", // Сообщение о отключении от сервера игрока({REASON} - Причина).
  "WelcomeAllText": " {RED} {PLAYERNAME} connected to server", // Сообщение о подключении игрока на сервер(для всех)
  "ConfigVersion": 1
}
```

Переменные:
- {MAXPLAYERS} - View max players
- {PLAYERNAME} - View player's name connecting to server;
- {ENTER} - Next line
- {MAP} - Now map
- {TIME} - Time(hh:mm:ss)
- {DATE} - Date(dd.mm.yyyy)
- {SERVERNAME} - Hostname
- {IP} - Server IP address
- {PORT} - Server Port
- {MAXPLAYERS} - The maximum number of players on the server
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

# Future plans:
- ~~Сделать цвета для чата~~(Готово)
- ~~Сделать больше переменных по типу: {MAXPLAYERS}/ {PLAYERNAME}~~(Готово)
- Добавить плагин в дискорд
- Микро-исправления
