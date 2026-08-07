using Metaphor.Engine;
using NetCord;
using NetCord.Gateway;
using NetCord.Logging;
using NetCord.Rest;
using NetCord.Services;
using NetCord.Services.ApplicationCommands;
GatewayClient client = new(new BotToken(File.ReadAllText("E:\\Shhhhhh\\SplorrBot.txt")), new GatewayClientConfiguration
{
    Intents = default,
    Logger = new ConsoleLogger(),
});
ApplicationCommandService<ApplicationCommandContext> applicationCommandService = new();
applicationCommandService.AddSlashCommand(new SlashCommandBuilder("splorr", "SPLORR!", HandleSPLORR));
applicationCommandService.AddUserCommand(new UserCommandBuilder("Username", (User user) => user.Username));
applicationCommandService.AddMessageCommand(new MessageCommandBuilder("Length", (RestMessage message) => message.Content.Length.ToString()));
applicationCommandService.AddModules(typeof(Program).Assembly);
client.InteractionCreate += async interaction =>
{
    if (interaction is not ApplicationCommandInteraction applicationCommandInteraction)
        return;
    var result = await applicationCommandService.ExecuteAsync(new ApplicationCommandContext(applicationCommandInteraction, client));
    if (result is not IFailResult failResult)
        return;
    try
    {
        await interaction.SendResponseAsync(InteractionCallback.Message(failResult.Message));
    }
    catch
    {
    }
};
await applicationCommandService.RegisterCommandsAsync(client.Rest, client.Id);
await client.StartAsync();
await Task.Delay(-1);
static string HandleSPLORR(ApplicationCommandContext context, string message)
{
    return Host.HandleMessage(context.User.Id, message);
}
