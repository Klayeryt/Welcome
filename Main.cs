using System;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Entities;
using System.Reflection;
using System.IO.Compression;
using System.Drawing;
using CounterStrikeSharp.API.Modules.Cvars;

namespace Main;
public class ConnectInfoConfig : BasePluginConfig
{
    [JsonPropertyName("PluginName")] public string Name { get; set; } = "[Welcome] | "; // Неа, тебе нельзя это трогать 0_0
    [JsonPropertyName("Timer")] public float Timer { get; set; } = 10.0f; // КД после захода
    [JsonPropertyName("WelcomeText")] public string WelcomeText { get; set; } = ""; // Сюда вписывать текст, когда сгенерируется конфиг!
}

public class Main : BasePlugin, IPluginConfig<ConnectInfoConfig>
{
    public override string ModuleName => "Welcome";
    public override string ModuleAuthor => "Xenomoros";
    public override string ModuleVersion => "v0.1";

    public ConnectInfoConfig Config { get; set; }

    public void OnConfigParsed(ConnectInfoConfig config)
    {
        Config = config;
    }

    public override void Load(bool hotReload)
    {
        ReWriteColor($"{Config.Name} Plugin has been enebled :)");
        ReWriteColor($"{Config.Name} Plugin version - {ModuleVersion}");
    }
     
    [GameEventHandler]
    public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
    {
        if(!@event.Bot) {
            var eventr = @event;
            var playerName = @event.Name;
            var Userid = eventr.Userid;
            var serverChatMessage = ReplaceMessageTags(Config.WelcomeText, playerName);
            //var serverAllChatMessage =
            AddTimer(Config.Timer, () => {
                Userid.PrintToChat(serverChatMessage);
                //Console.WriteLine(serverChatMessage);
            });
        }
        return HookResult.Continue;
    }

    public string ReWriteColor(string text) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{text}");
        Console.ForegroundColor = ConsoleColor.White;
        return text;
    }

    private string ReplaceMessageTags(string message, string playerName)
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
                                    .Replace("{PLAYERNAME}", playerName.ToString());

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