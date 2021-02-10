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
using System.Text.RegularExpressions;

namespace NextGenerationCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Database connection (LocalDB)\NextGenerationCareDB
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
           // lnkForgotPassword.Click += LnkForgotPassword_Click;
        }

        public short ValidateUsername(string strUserName)
        {
            if(strUserName.Length < 4)
            {
                return 1; 
            }
            return 0;
        }

        public short ValidatePassword(string strPassword)
        {
            Regex regLetterCheck = new Regex((@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$"));
            if (strPassword.Length < 6)
            {
                return 1;
            }
            else if(!regLetterCheck.IsMatch(strPassword))
            {
                return 2;
            }
            
            return 0;
        }

        public void BtnLogin_Click(Object sender, RoutedEventArgs e)
        {
            short shrtUsernameValid = ValidateUsername(strUserName.Text);
            short shrtPasswordValid = ValidatePassword(strPassword.Password);

            if (shrtUsernameValid == 1)
            {
                lblValidation.Visibility = Visibility.Visible;
                lblValidation.Text = "**Invalid Username: username must be at least 4 characters";
            }
            else if(shrtUsernameValid == 2)
            {
                lblValidation.Visibility = Visibility.Visible;
                lblValidation.Text = "**Invalid Username: username must be at least 4 characters";
            }
            else if(shrtPasswordValid == 1)
            {
                    lblValidation.Visibility = Visibility.Visible;
                    lblValidation.Text = "**Invalid Password: Password must be at least 6 characters";
            }
            else if(shrtPasswordValid == 2)
            {
                lblValidation.Visibility = Visibility.Visible;
                lblValidation.Text = "**Invalid Password: Password must be contain at least\n  --one uppercase letter\n  --one lowercase letter\n  --one number";
            }
            else if(shrtUsernameValid == 0 && shrtPasswordValid == 0)
            {
                lblValidation.Visibility = Visibility.Hidden;
            }
        }

        private void LnkForgotPassword_Click(object sender, RoutedEventArgs e)
        {
           ForgotPass fp = new ForgotPass();
            fp.Show();
           
        }
    }
}
