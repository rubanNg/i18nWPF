using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace i18n
{
    /// <summary>
    /// Логика взаимодействия для Translate.xaml
    /// </summary>
    public partial class Translate : UserControl
    {
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string), typeof(Translate));

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(string), typeof(Translate), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(UpdateTranslate)));

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public Translate()
        {
            InitializeComponent();
            I18nLocaleStorage.Languagechange += I18nLocaleStorageLanguagechange;
        }

        private void I18nLocaleStorageLanguagechange(object sender, EventArgs e)
        {
            var value = I18nLocaleStorage.GetKeyValue(Key);
            SetValue(ResultProperty, value);
        }

        static void UpdateTranslate(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventValue)
        {
            var key = (string)eventValue.NewValue;
            dependencyObject.SetValue(ResultProperty, I18nLocaleStorage.GetKeyValue(key));
        }
    }
}
