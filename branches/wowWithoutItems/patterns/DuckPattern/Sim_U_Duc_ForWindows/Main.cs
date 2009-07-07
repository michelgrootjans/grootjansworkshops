using System;
using System.Windows.Forms;
using Sim_U_Duck.Ducks;

namespace Sim_U_Duc_ForWindows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Test(new MallardDuck());
            Test(new RedHeadDuck());
            Test(new RubberDuck());
        }

        private void Test(Duck duck)
        {
            duck.Quack();
        }
    }
}