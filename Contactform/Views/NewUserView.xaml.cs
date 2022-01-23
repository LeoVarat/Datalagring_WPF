using Contactform.Services;
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

namespace Contactform.Views
{
    /// <summary>
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class NewUserView : UserControl
    {
        private readonly IUserService userService = new UserService(); 
        public NewUserView()
        {
            InitializeComponent();
            ClearFields();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbUserName.Text) &&
                !string.IsNullOrEmpty(tbEmail.Text) &&
                !string.IsNullOrEmpty(tbFirstName.Text) &&
                !string.IsNullOrEmpty(tbLastName.Text) &&
                !string.IsNullOrEmpty(tbStreetName.Text) &&
                !string.IsNullOrEmpty(tbPostalCode.Text) &&
                !string.IsNullOrEmpty(tbCounty.Text) &&
                !string.IsNullOrEmpty(tbCountry.Text))
            {
                if (userService.Create(tbUserName.Text, tbEmail.Text, tbFirstName.Text, tbLastName.Text, tbPostalCode.Text, tbCounty.Text, tbCountry))
                    ClearFields();
                else
                    lbError1.Content = "User with the same email adress aldreadt exist";
            }
        }
        private void ClearFields()
        {
            tbUserName.Text = "";
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbStreetName.Text = "";
            tbPostalCode.Text = "";
            tbCounty.Text = "";
            tbCountry.Text = "";
            lbError1.Content = "";

        }
    }
}
