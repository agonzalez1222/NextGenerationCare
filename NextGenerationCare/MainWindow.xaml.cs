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

namespace NextGenerationCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        public short ValidateUsername(string UserName)
        {
            if(UserName.Length < 5)
            {
                return 1; 
            }
            return 0;
        }

        public void BtnLogin_Click(Object sender, RoutedEventArgs e)
        {
            if (ValidateUsername(strUserName.Text) == 1)
            {
                lblValidation.Visibility.Equals("Visible");
                lblValidation.Text = "Invalid Username: username must be at least 4 characters";
            }
            else if (ValidateUsername("Test") == 2)
            {
                lblValidation.Text = "Invalid Username: username must be at least 4 characters";
            }
        }
    }
}
