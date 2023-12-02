using System;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Entities;
using System.Reflection;

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
            var MaxPlayer = Server.MaxPlayers.ToString();
            var Userid = eventr.Userid;
            var serverChatMessage = ReplaceMessageTags(Config.WelcomeText, playerName, MaxPlayer);
            AddTimer(Config.Timer, () => {
                Userid.PrintToChat($"{serverChatMessage}");
                Console.WriteLine(serverChatMessage);
            });
        }
        return HookResult.Continue;
    }

    public string ReWriteColor(string text) {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{text}");
        Console.BackgroundColor = ConsoleColor.Black;
        return text;
    }

    private string ReplaceMessageTags(string message, string player, string maxplayer)
    {
        var replacedMessage = message
                                .Replace("{PLAYERNAME}", player)
                                .Replace("{MAXPLAYERS}", maxplayer);

        return replacedMessage;
    }
}