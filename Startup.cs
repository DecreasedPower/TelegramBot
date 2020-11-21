using System;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MechoPudge
{
    public class Startup
    {
        static TelegramBotClient telegramBotClient;
        public Startup(IConfiguration configuration)
        {
            telegramBotClient = new TelegramBotClient("1445211144:AAGMB1Uo0rZALL4Z5il7QCm3pzXSBdXFyR8");
            telegramBotClient.GetMeAsync();
            telegramBotClient.OnMessage += Bot_OnPudge;
            telegramBotClient.OnMessage += Bot_OnHello;
            telegramBotClient.StartReceiving();
            Configuration = configuration;
        }
        static async void Bot_OnHello (object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text.ToUpper() == "/HELLO")
                {
                    await telegramBotClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        "You look nice meat. Oh, i mean mate");
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        static async void Bot_OnPudge(object sender, MessageEventArgs e)
        {
            string[] pudgePics = new string[]
            {
                "https://lh3.googleusercontent.com/pw/ACtC-3ceemo-4jflozPZaY87UAUB5eZ7NVECLHk7cQldBB-C2eRH1aQmBhoLqO8G9vCcAeTpuJlElUk1iH-TLHelOR0-8hts26HoPQW_9j0YSWnadg1Tziw7uw0ighfj4IxLyxaJ2oWkzBBIK2pi-gVZgJyL=w1168-h657-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3fLkkI__jg4jHHZ1FwS7OjP0DbRiszGLofNqkq-zvOpTzm-x7IhpETd5GOO32b8bdDNE9sAx6UarmLqXi-Gbaa7UEyZohS-jNimiBdIy2ETnvE_FDR7mBAavbdcWyDTgauw94zowDGJirvnr4-qY6FZ=w1168-h657-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3dZ5Gi0SrmKxOIMCrkW_1D5oe59BHoLANwU0enNee95VK1zx_HEnlE6cLpc5ARv0EzmhiH776AyOSBhhCv-G32jUrgSBfbSQrbANIA9ackOlV1FDGQdPx6uWcN96EO6FMZrcpeVHiLDSycyz4UpBylj=w1168-h657-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3dE01ElLkXZEww9GX1ahQjN2hn7rdqtY4ZFxsxFIZE7d2ZMTsM-1Ck4xxS5zMjKYFJZKhZ0wce1Giv510PFns_MP_KAAYCz1Pw740umZvlOl8x26PFK5E4vbgl-Pc5ePARB4YqbdZlqpuX4XvRwp7RZ=w1366-h554-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3fwE8M5STI9-kDGi9ImYhtr05sivUCpb3gV8TH5OVJ6SQfA8GhJqapplM7Ol0-l8BzP9mW0wAwvk9J2GYD2dMeB9mTvIa5vjL6ULCY20QX5xigXeQtAMy08clsQHl8qi4tddkV-HGQAqMBXsCLGqHId=w512-h288-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3epVGT8kygsvw5T0Z3LUPTm4SLr3y0MFsnBK5ky4Z4N4PKvFBSprbXzFkCXXStkVV9G5RgtujqeepmEPtlVsUrpKm8pxRUZVteVBfQMfVznIlKZzxTEWyh_bj29dMlyXC_bJYUB_0SW2a3gmZgmA1LM=w512-h288-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3eEXIGYYtUum9Gs1ZC8L6OlcuPpu6lgAzfAr73TeOXWbJxvXsQyOCMwyMW2M04HFZ1NfNRIpbrQSJo-Vq1cSsTpJgKabKKb_bX0Qg9xgapdFlRBI0WNoV6__S-PQkuJjquOKR1IWKsYOmUHm4jXyYau=w1168-h657-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3eFWED7I9cFtbP3YQiskgnp1tdKVYiulDW824Am_uRsZ5s9MdM0GT2xVoPcAJf74OeKLpEyKU23zZHLNTQnLGyoU-prKhhUAEceD-Eq2CNdUSBssJeZh5N-6PxpxACVFe9xFmCkMrX1Z54YkokjOYnk=w512-h288-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3cTgGTevjSSArjZdxc2jhz3dJE1McVn6aNIQCKCbl3OUNDswgTHXHx4fLdznxqw-ATsziGLlNOc5GJSEC86JAKzQNU_K0Czei9fsEqep9d0KkHiLd121d8e_ikgObf6KmQ4nG0I6YYoiEu4bahHGSC-=w1200-h630-no?authuser=0",
                "https://lh3.googleusercontent.com/pw/ACtC-3c78On5TjJUWqpvQzNqpJkqCuTKJoXyxgs4E3x2blvWuL1HASVgjaqq6S16yWQauOixKq0KdghKY8HQEswdflhVveuOl2lKdSydbHhHMQJ8cPzaGHi_4tAj5lH912hoo3IqdKzfg1kKqg_Fmm26LYeY=w355-h474-no?authuser=0"
            };
            try
            {
                if (e.Message.Text.ToUpper() == "/PUDGE")
                {
                    var rand = new Random();
                    var result = rand.Next(10);
                    if (result == 9)
                    {
                        await telegramBotClient.SendPhotoAsync(
                            chatId: e.Message.Chat,
                            photo: pudgePics[9],
                            caption: "Вы открыли секретного пуджа! Поздравляю!");
                    }
                    else
                    {
                        await telegramBotClient.SendPhotoAsync(
                              chatId: e.Message.Chat,
                              photo: pudgePics[rand.Next(8)],
                              caption: "Someone needed a bucha?");
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }
        public IConfiguration Configuration { get; }
    }
}
