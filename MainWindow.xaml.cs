using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

[assembly:ArmDot.Client.VirtualizeCode]

namespace WPFObfuscationSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        buttonCheck.Click += (sender, e) =>
        {
            using (var algorithm = SHA256.Create())
            {
                var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(textBoxPassword.Text));
                var readableHash = Convert.ToBase64String(hash);

                MessageBox.Show(
                    owner: this,
                    caption: "Result",
                    messageBoxText: readableHash == "hzTbLivrxGSCjSfDqNEIDuXEbj1W6IXdPikhanYqTu0=" ? "Correct" : "Incorrect",
                    button: MessageBoxButton.OK);
            }
        };
    }
}