using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;

namespace HockeyNewsBot
{
    public class Bot
    {
        private DiscordSocketClient _discordClient { get; set; }
        private string _token { get; set; }
        private Settings _settings { get; set; }
        private News _news { get; set; }
        private Timer _newsTimer { get; set; }
        public Bot(Settings settings)
        {
            _settings = settings;
            _discordClient = new DiscordSocketClient();
            _discordClient.Log += LogAsync;
            _discordClient.Ready += ReadyAsync;
            _discordClient.MessageReceived += MessageReceivedAsync;
        }

        public async Task Start()
        {
            _news = new News(_settings);
            await _discordClient.LoginAsync(TokenType.Bot, _settings.DiscordBotToken);
            await _discordClient.StartAsync();

            _newsTimer = new Timer(
                callback: new TimerCallback(GetNews),
                state: null,
                dueTime: new TimeSpan(0, 0, 0),
                period: new TimeSpan(0, 5, 0)
            );
        }

        private async void GetNews(object timerState)
        {
            var data = await _news.GetNews();

            var toSend = new List<Article>();
            using (var db = new HockeyNewsBotContext())
            {
                foreach (var n in data.NewsArticles)
                {
                    var uuId = n.Attributes.Uuid.ToString();

                    var exists = await db.Articles.AnyAsync(a => a.UuId == uuId);

                    if (!exists)
                    {
                        try
                        {
                            var article = new Article
                            {
                                UuId = uuId,
                                ArticleId = uuId,
                                Headline = n.Attributes.Headline,
                                Source = n.Attributes.SourceUrl?.ToString() ?? "",
                                Value = n.Attributes.News.Value,
                                PublishedOn = DateTimeOffset.FromUnixTimeSeconds(n.Attributes.Created).DateTime.ToString("o")
                            };
                            toSend.Add(article);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.StackTrace);
                        }
                    }

                }
                if (toSend.Count > 0)
                {
                    db.AddRange(toSend);
                }
                await db.SaveChangesAsync();
            }

            //await SendNews(toSend);
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            Console.WriteLine(message.Content);

            if (message.Author.Id == _discordClient.CurrentUser.Id)
            {
                return;
            }

            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("pong!");
            }
        }

        public async Task SendNews(List<Article> articles)
        {
            var channelId = _settings.DiscordNewsChannelId;
            var channel = _discordClient.GetChannel(channelId) as IMessageChannel;
            foreach (var a in articles)
            {
                await channel.SendMessageAsync($"{a.Headline}\n{a.Value}\n{a.Source ?? ""}");
            }
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"{_discordClient.CurrentUser} is connected!");
            return Task.CompletedTask;
        }

        private Task LogAsync(LogMessage message)
        {
            return Task.CompletedTask;
        }
    }
}
