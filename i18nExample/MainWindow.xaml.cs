using i18n;
using i18n.Interfaces;
using i18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace i18nWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitI18n();
            InitializeComponent();
        }

        void InitI18n() 
        {
            new I18n(new i18nConfig() { InitLanguage = "en", Loader = new MyImplementedITranslateLoader() });
        }

        private void LangSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = (((ComboBox)sender).SelectedItem as ComboBoxItem).Content as string; 
            I18n.ChangeLanguage(value);
        }
    }


    public class MyImplementedITranslateLoader : ITranslateLoader
    {

        public async Task<Dictionary<string, string>> LoadTranslate(string language)
        {
            // here can be hhtp request or read local json file
            return await TestValue(language);
        }



        Task<Dictionary<string, string>>  TestValue(string language) 
        {
            return Task.Run(() =>
            {
                var englishValue = new Dictionary<string, string>()
                {
                    ["common.key.value"] = "[English] Is not valid value! please set valid value",
                    ["common.key.price"] = "[English] Item price 1000$",
                    ["common.key.count"] = "[English] Count eq 1000",
                };

                var russianValue = new Dictionary<string, string>()
                {
                    ["common.key.value"] = "[Russian] Не верное значение. Установите верное значение",
                    ["common.key.price"] = "[Russian] Цена предмета 1000$",
                    ["common.key.count"] = "[Russian] Количество равно 1000 шт",
                };

                return language == "en" ? englishValue: russianValue;
            });
        }

    }
}
