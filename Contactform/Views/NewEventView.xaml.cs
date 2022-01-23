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
    /// Interaction logic for NewEventView.xaml
    /// </summary>
    public partial class NewEventView : UserControl
    {
        private readonly IUserEventService userEventService = new UserEventService(); 
        private readonly IUserService userService = new UserService();
        private readonly IEventStatusService eventStatusService = new EventStatusService();
        public NewEventView()
        {
            InitializeComponent();
            cbUser.SelectedValuePath = "Key";
            cbUser.DisplayMemberPath = "Value";
            cbStatus.SelectedValuePath = "Key";
            cbStatus.DisplayMemberPath = "Value";
            ClearFields();
            PopulateUsers();
            PopulateStatuses();
        }
        private void btnAdd_Click2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHeader.Text) &&
                !string.IsNullOrEmpty(tbDescription.Text) &&
                !string.IsNullOrEmpty(cbUser.Text) &&
                !string.IsNullOrEmpty(cbStatus.Text))
            {
                DateTime Created = DateTime.Now;
                DateTime LastUpdate = DateTime.Now;
                if (userEventService.Create(
                    tbHeader.Text, 
                    tbDescription.Text,
                    (int)cbUser.SelectedValue,
                    (int)cbStatus.SelectedValue))

                    ClearFields();
                else
                    lbError2.Content = "Please fill in all fields";
            }
        }
        private void ClearFields()
        {
            tbHeader.Text = "";
            tbDescription.Text = "";
            lbError2.Content = "";

        }
        private void PopulateUsers()
        {
            cbUser.Items.Clear();
            foreach(var user in userService.GetAll())
                cbUser.Items.Add(new KeyValuePair<int, string>(user.Id, user.UserName));
        }

        private void PopulateStatuses()
        {
            cbStatus.Items.Clear();
            foreach (var eventstatus in eventStatusService.GetEventStatuses())
                cbStatus.Items.Add(new KeyValuePair<int, string>(eventstatus.Id, eventstatus.Name));
        }
    }
}
