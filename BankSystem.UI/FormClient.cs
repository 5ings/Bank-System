using BankSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.UI
{
    public partial class FormClient : Form
    {
        private User _clientUser;
        public FormClient()
        {
            InitializeComponent();
        }
        public FormClient(User loggedUser)
        {
            InitializeComponent();
            _clientUser = loggedUser;
        }
        private void FormClient_Load(object sender, EventArgs e)
        {

        }
    }
}
