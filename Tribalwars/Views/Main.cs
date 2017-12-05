using System;
using System.Windows.Forms;
using Tribalwars.Controllers;

namespace Tribalwars.Views
{
    public partial class Main : Form
    {
        private readonly MainController _controller;

        public Main()
        {
            InitializeComponent();
            _controller = new MainController();

            _controller.EnterGame();
            tmrAttackCheck.Enabled = chckAutomation.Checked;
        }

        private void tmrAttackCheck_Tick(object sender, System.EventArgs e)
        {
            // add randomness to the timer ticking
            var rnd = new Random().Next(20000, 25000);
            tmrAttackCheck.Interval = rnd;
            // attack to a farm village
            _controller.Attack();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var villages = _controller.AddNewFarmVillage(txtX.Text, txtY.Text);

            if (villages == null)
                MessageBox.Show("Village already exists");
            else
                gridAttacks.DataSource = villages;
        }

        private void chckAutomation_CheckedChanged(object sender, EventArgs e)
        {
            tmrAttackCheck.Enabled = chckAutomation.Checked;
        }
    }
}
