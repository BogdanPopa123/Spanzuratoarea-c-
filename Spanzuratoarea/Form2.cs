using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace Spanzuratoarea
{
    public partial class Form2 : Form
    {
        private Image[] imagini = { Spanzuratoarea.Properties.Resources.Level0, Spanzuratoarea.Properties.Resources.Level1,
                                    Spanzuratoarea.Properties.Resources.Level2, Spanzuratoarea.Properties.Resources.Level3,
                                    Spanzuratoarea.Properties.Resources.Level4, Spanzuratoarea.Properties.Resources.Level5,
                                    Spanzuratoarea.Properties.Resources.Level6};

        private string[] cuvinte = {"argotic", "infuzor", "serafic", "piastru", "fundal",      "unicorn", "cefalic", "traheal", "glorios", "suveran",
                                    "apeduct", "coaliza", "samurai", "deznoda", "neozoic",     "plumburiu", "meteorolog", "astronaut", "marinar", "astronaut",
                                    "reanaliza", "antrenament", "realizare", "interlocutor",   "armament", "rinocer", "meteorit", "asteroid", "expert",
                                    "dermatolog", "ornitorinc", "imperiu", "secretos", "cameleon",   "aerian", "pandemie", "periculos", "aerometru", "decongelat",
                                    "finalizat", "jurnalism", "claustrofobie", "iordanian",    "totemic", "subacvatic", "programare", "arheologie", "binevoitor",
                                    "tragedie", "perpendicular", "destabilizat", "petrolifer", "locuitor",    "dinozaur", "tricotat", "revizuit", "neschimbat", "longeviv"};

        private int greseli = 0;
        public string cuvCurent;
        char firstChar, lastChar;
        public string cuvAfisat="";

        public Form2()
        {
            InitializeComponent();
            WordChoice();
        }

        public void WordChoice()
        {
            int index = (new Random()).Next(cuvinte.Length);
            cuvCurent = cuvinte[index];
            for(int i=0; i<cuvCurent.Length; i++)
            {
                cuvAfisat += "_ ";
            }
            firstChar = cuvCurent[0];
            lastChar = cuvCurent[cuvCurent.Length - 1];
            UpdateCuvAfisat(firstChar);
            UpdateCuvAfisat(lastChar);
        }

        public void UpdateCuvAfisat(char litera)
        {
            for (int i = 0; i < cuvCurent.Length; i++)
            {
                if (cuvCurent[i] == litera)
                {
                    string temp = "";
                    temp += cuvAfisat.Substring(0, 2 * i);
                    temp += litera;
                    temp += cuvAfisat.Substring(2 * i + 1, cuvAfisat.Length - 2 * i - 1);
                    cuvAfisat = temp;
                }
            }
            cuvAfisatLabel.Text = cuvAfisat;
        }

        public void CheckWin()
        {
            int isfinished = 1;
            for (int i = 0; i < cuvAfisatLabel.Text.Length; i++)
            {
                if (cuvAfisatLabel.Text[i] == '_')
                {
                    isfinished = 0;
                }
            }
            if (isfinished == 1)
            {
                resultLabel.ForeColor = System.Drawing.Color.LimeGreen;
                resultLabel.Text = "Ai castigat!";
                ReleaseButtons();
            }
        }

        private void GuessClick(object sender, EventArgs e)
        {
            Button choice = sender as Button;
            if(cuvCurent.Contains(choice.Text))
            {
                UpdateCuvAfisat(choice.Text[0]);
                choice.Enabled = false;
                choice.BackColor = System.Drawing.Color.LightGreen;
                CheckWin();
            }
            else
            {
                    choice.Enabled = false;
                    greseli++;
                    if (greseli < 6)
                    {
                        pictureBox1.Image = imagini[greseli];
                    }
                    if (greseli == 6)
                    {
                        pictureBox1.Image = imagini[greseli];
                        resultLabel.ForeColor = System.Drawing.Color.Firebrick;
                        resultLabel.Text = "Ai pierdut!";
                    ReleaseButtons();
                        string temp = "";
                        for (int i = 0; i < cuvCurent.Length; i++)
                        {
                            temp += cuvCurent[i] + " ";
                        }
                        cuvAfisatLabel.Text = temp;
                    }
                    choice.BackColor = System.Drawing.Color.Salmon;
                    vietiRamaseLabel.Text = "Vieti ramase : " + (6 - greseli);
                    if (greseli >= 3)
                    {
                        cmdAjutor.Enabled = false;
                    }
                
            }
            
           
        }

        private void Instructiuni_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Incearca sa ghicesti literele ascunse ale cuvantului din cat mai putine incercari!\nJocul se termina atunci cand ai reusit" +
                "sa gasesti cuvantul, sau atunci cand ramai fara vieti.\nLa inceput ai 6 vieti.\nDe asemenea,poti sa apesi pe butonul \"Ajutor\", care " +
                "iti va dezvalui o litera a cuvantului, insa te va costa 3 vieti.");
        }

        private void CmdAjutor_Click(object sender, EventArgs e)
        {
            int rand = (new Random()).Next(0, cuvCurent.Length);
            while(cuvAfisatLabel.Text[2*rand]!='_')
            {
                rand = (new Random()).Next(0, cuvCurent.Length);
            }
            UpdateCuvAfisat(cuvCurent[rand]);
            greseli += 3;
            vietiRamaseLabel.Text = "Vieti ramase : " + (6 - greseli);
            if(greseli>=3)
            {
                cmdAjutor.Enabled = false;
            }
            CheckWin();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            vietiRamaseLabel.Text = "Vieti ramase : 6";
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void ReleaseButtons()
        {
            cmdA.Enabled = false;
            cmdB.Enabled = false;
            cmdC.Enabled = false;
            cmdD.Enabled = false;
            cmdE.Enabled = false;
            cmdF.Enabled = false;
            cmdG.Enabled = false;
            cmdH.Enabled = false;
            cmdI.Enabled = false;
            cmdJ.Enabled = false;
            cmdK.Enabled = false;
            cmdL.Enabled = false;
            cmdM.Enabled = false;
            cmdN.Enabled = false;
            cmdO.Enabled = false;
            cmdP.Enabled = false;
            cmdQ.Enabled = false;
            cmdR.Enabled = false;
            cmdS.Enabled = false;
            cmdT.Enabled = false;
            cmdU.Enabled = false;
            cmdV.Enabled = false;
            cmdW.Enabled = false;
            cmdX.Enabled = false;
            cmdY.Enabled = false;
            cmdZ.Enabled = false;
            cmdAjutor.Enabled = false;
            Instructiuni.Enabled = false;
            restartButton.Enabled = true;
        }
    }
}
