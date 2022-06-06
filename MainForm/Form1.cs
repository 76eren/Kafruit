using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace KaFruit
{
    public partial class main : Form
    {
        int count = 0;
        List<CheckBox> checks = new List<CheckBox>();
        Networking networking = new Networking();

        public main()
        {
            InitializeComponent();
            checks.Add(A1Checkbox);
            checks.Add(A2Checkbox);
            checks.Add(A3Checkbox);
            checks.Add(A4Checkbox);


            TextBox.CheckForIllegalCrossThreadCalls=false; // I am lazy

            Thread t = new Thread(delegate ()
            {
                networking.connect();
                roomLbl.Text = "Room code: " + networking.code;

            });
            t.Start();






        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void questionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void counterText_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            save();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            // BACK PREVIOUS
            if (count > 0)
            {
                count--;
                Debug.WriteLine(count);
                empty();
                load();


            }


        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            // NEXT

            if (count+1 - Saving.objects.Count == 1)
            {
                return;
            }

            count++;
            Debug.WriteLine(count);
            empty();


            if (count+1 <= Saving.objects.Count)
            {
                load();
            }

        }


        void empty()
        {
            questionBox.Text = "";
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            a4.Text = "";


            // We reset the checkmarks
            foreach (CheckBox i in checks)
            {
                i.Checked=false;
            }
            
            // We change the label name
            counterText.Text = count + "/" + Saving.objects.ToArray().Length;

           


        }

        void save()
        {
            if (count == Saving.objects.Count)
            {
                // We add a new page
                Data dataObj = new Data();
                dataObj.Q = questionBox.Text;
                dataObj.A1 = a1.Text;
                dataObj.A2 = a2.Text;
                dataObj.A3 = a3.Text;
                dataObj.A4 = a4.Text;

                int ct = 1;
                foreach (CheckBox i in checks)
                {
                    if (i.Checked)
                    {
                        dataObj.correctAns.Add(ct);
                    }
                    ct++;
                }


                Saving.save(dataObj, count);
                Debug.WriteLine(Saving.objects[0].A1);
            }
            else
            {
                // We update an already existing page
                Saving.objects[count].Q = questionBox.Text;
                Saving.objects[count].A1 = a1.Text;
                Saving.objects[count].A2 = a2.Text;
                Saving.objects[count].A3 = a3.Text;
                Saving.objects[count].A4 = a4.Text;
                List<int> temp = new List<int>();
                int ct = 1;
                foreach (CheckBox i in checks)
                {
                    if (i.Checked)
                    {
                        temp.Add(ct);
                    }
                    ct++;
                }
                Saving.objects[count].correctAns = temp;

            }

        }

        void load()
        {
            Data data = Saving.objects[count];
            questionBox.Text = data.Q;
            a1.Text = data.A1;
            a2.Text = data.A2;
            a3.Text = data.A3;
            a4.Text = data.A4;


            foreach (int i in data.correctAns)
            {
                checks[i - 1].Checked = true;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            // Now we start the game
            networking.start();
            
        }
    }

}
