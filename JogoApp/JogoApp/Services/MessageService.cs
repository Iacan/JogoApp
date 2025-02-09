﻿using System.Threading.Tasks;

namespace JogoApp.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await JogoApp.App.Current.MainPage.DisplayAlert("Jogos",message,"Ok");
        }

        public async Task ShowAsync(string title, string message, string text)
        {
            await JogoApp.App.Current.MainPage.DisplayAlert(title, message, text);
        }

        public async Task ShowAsync(string title, string message, string text1, string text2)
        {
            await JogoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }

        public async Task<bool> ShowAsyncBool(string title, string message, string text1, string text2)
        {
            return await JogoApp.App.Current.MainPage.DisplayAlert(title, message, text1, text2);
        }
    }
}
