using System;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Core.Translations;


namespace Main;
public class ConnectInfoConfig : BasePluginConfig
{
    [JsonPropertyName("PluginName")] public string Name { get; set; } = "[Welcome] | ";
    [JsonPropertyName("Timer")] public float Timer { get; set; } = 10.0f;
    [JsonPropertyName("WelcomePlayerOneEnable")] public string WelcomePlayerOneEnable { get; set; } = "true"; 
    [JsonPropertyName("WelcomePlayerAllEnable")] public string WelcomePlayerAllEnable { get; set; } = "true";
    [JsonPropertyName("DisconnectPlayerAllEnable")] public string DisconnectPlayerAllEnable { get; set; } = "true";  
    [JsonPropertyName("WelcomeText")] public string WelcomeText { get; set; } = " {RED}---------------------------------{ENTER} {LIGHTBLUE}Welcome on server {PLAYERNAME} {ENTER} Now map: {MAP} {ENTER} Players online: {PLAYERS}/{MAXPLAYERS} {ENTER} {RED}Your IP: {IPUSER} {ENTER} {RED}------------------------------ ";
    [JsonPropertyName("disconnectAllText")] public string disconnectAllText { get; set; } = " {RED} {PLAYERNAME} disconnect to reason: {REASON} ";
    [JsonPropertyName("WelcomeAllText")] public string WelcomeAllText { get; set; } = " {RED} {PLAYERNAME} connected to server";
}

public class Main : BasePlugin, IPluginConfig<ConnectInfoConfig>
{
    public override string ModuleName => "Welcome";
    public override string ModuleAuthor => "Xenomoros";
    public override string ModuleVersion => "1.0.0";
    public ENetworkDisconnectionReason Reason { get; set; }

    public ConnectInfoConfig Config { get; set; }

    public void OnConfigParsed(ConnectInfoConfig config)
    {
        Config = config;
    }

    public override void Load(bool hotReload)
    {
        ReWriteColor($"-------------------------------------------");
        ReWriteColor($"{Config.Name} Plugin has been enebled :)");
        ReWriteColor($"{Config.Name} Plugin version - {ModuleVersion}");
        ReWriteColor($"-------------------------------------------");
        ReWriteColor("ConVars status: ");
        if(Config.WelcomePlayerAllEnable == "false" || Config.WelcomePlayerAllEnable == "0") {
            ReWriteColor("WelcomePlayerAllEnable(-None-)");
        }
        else if (Config.WelcomePlayerAllEnable == "true" || Config.WelcomePlayerAllEnable == "1") {
            ReWriteColor("WelcomePlayerAllEnable(-Enable-)");
        }

        if (Config.WelcomePlayerOneEnable == "false" || Config.WelcomePlayerOneEnable == "0") {
            ReWriteColor("WelcomePlayerOneEnable(-None-)");
        }
        else if (Config.WelcomePlayerOneEnable == "true" || Config.WelcomePlayerOneEnable == "1") {
            ReWriteColor("WelcomePlayerOneEnable(-Enable-)");
        }

        if (Config.DisconnectPlayerAllEnable == "false" || Config.DisconnectPlayerAllEnable == "0") {
            ReWriteColor("DisconnectPlayerAllEnable(-None-)");
        }
        else if (Config.DisconnectPlayerAllEnable == "true" || Config.DisconnectPlayerAllEnable == "1") {
            ReWriteColor("DisconnectPlayerAllEnable(-Enable-)");
        }
    }
    
    [GameEventHandler]
    public HookResult OnPlayerConnectFull(EventPlayerConnectFull @event, GameEventInfo info)
    {
        string ipuser = @event.Userid.IpAddress;
        var playerName = @event.Userid.PlayerName;
        var eventr = @event;
        var userid = @event.Userid;
        var steamId = @event.Userid.SteamID.ToString();
        if(Config.WelcomePlayerAllEnable == "true" || Config.WelcomePlayerAllEnable == "1") {
            if(!@event.Userid.IsBot) {
                Server.PrintToChatAll(ReplaceMessageTags(Config.WelcomeAllText, playerName, String.Empty, ipuser, steamId));
            }
        }
        else {}

        if(Config.WelcomePlayerOneEnable == "true" || Config.WelcomePlayerOneEnable == "1") {
            if(!@event.Userid.IsBot) {
                AddTimer(Config.Timer, () => {
                    userid.PrintToChat(ReplaceMessageTags(Config.WelcomeText, playerName, String.Empty, ipuser, steamId));
                });
            }
        }
        else {}
        return HookResult.Stop;
    }

    [GameEventHandler]
    public HookResult OnPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo info) {
        string playerName = @event.Name;
        var reasonInt = @event.Reason;
        if(Config.DisconnectPlayerAllEnable == "true" || Config.DisconnectPlayerAllEnable == "1") {
            if(@event.Reason.ToString() != "39") {
                string disconnectReasonString = Localizer[((ENetworkDisconnectionReason)reasonInt).ToString()];
                Server.PrintToChatAll(ReplaceMessageTags(Config.disconnectAllText, playerName, disconnectReasonString, String.Empty, String.Empty));
            }
        }
        else {}
        return HookResult.Continue;
    }

    public string ReWriteColor(string text) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{text}");
        Console.ForegroundColor = ConsoleColor.White;
        return text;
    }

    private string ReplaceMessageTags(string message, string playerName, string reason, string ipuser, string SteamPlID)
    {
        var replacedMessage = message
                                    .Replace("{ENTER}", "\u2029")
                                    .Replace("{MAP}", NativeAPI.GetMapName())
                                    .Replace("{TIME}", DateTime.Now.ToString("HH:mm:ss"))
                                    .Replace("{DATE}", DateTime.Now.ToString("dd.MM.yyyy"))
                                    .Replace("{SERVERNAME}", ConVar.Find("hostname")!.StringValue)
                                    .Replace("{IP}", ConVar.Find("ip")!.StringValue)
                                    .Replace("{PORT}", ConVar.Find("hostport")!.GetPrimitiveValue<int>().ToString())
                                    .Replace("{MAXPLAYERS}", Server.MaxPlayers.ToString())
                                    .Replace("{PLAYERS}", Utilities.GetPlayers().Count.ToString())
                                    .Replace("{REASON}", reason)
                                    .Replace("{PLAYERNAME}", playerName.ToString())
                                    .Replace("{IPUSER}", ipuser)
                                    .Replace("{STEAMID}", SteamPlID);

        replacedMessage = ReplaceMessageColors(replacedMessage);

        return replacedMessage;
    }

    private string ReplaceMessageColors(string input) {
        string[] ColorAlphabet = {"{GREEN}", "{BLUE}", "{RED}", "{SILVER}", "{MAGENTA}", "{GOLD}", "{DEFAULT}", "{LIGHTBLUE}", "{LIGHTPURPLE}", "{LIGHTRED}", "{LIGHTYELLOW}", "{YELLOW}", "{GREY}", "{LIME}", "{OLIVE}", "{ORANGE}", "{DARKRED}", "{DARKBLUE}", "{BLUEGREY}", "{PURPLE}"};
        string[] ColorChar = {$"{ChatColors.Green}", $"{ChatColors.Blue}", $"{ChatColors.Red}", $"{ChatColors.Silver}", $"{ChatColors.Magenta}", $"{ChatColors.Gold}", $"{ChatColors.Default}", $"{ChatColors.LightBlue}", $"{ChatColors.LightPurple}", $"{ChatColors.LightRed}", $"{ChatColors.LightYellow}", $"{ChatColors.Yellow}", $"{ChatColors.Grey}", $"{ChatColors.Lime}", $"{ChatColors.Olive}", $"{ChatColors.Orange}", $"{ChatColors.Darkred}", $"{ChatColors.DarkBlue}", $"{ChatColors.BlueGrey}", $"{ChatColors.Purple}"};

        for(int z = 0; z < ColorAlphabet.Length; z++) 
            input = input.Replace(ColorAlphabet[z], ColorChar[z]);


        return input;
    }
}
