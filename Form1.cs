using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace TExttoSpeech
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer computer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (computer != null)
             {
                computer.Dispose();
                label3.Text = "IDLE";
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            computer = new SpeechSynthesizer();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.ScrollBars = ScrollBars.Both;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            computer.Dispose();
            if (textBox1.Text != "")
            {

                computer = new SpeechSynthesizer();
                computer.SpeakAsync(textBox1.Text);
                label3.Text = "Speaking";
                button2.Enabled = true;
                button4.Enabled = true;
                computer.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(computer_SpeakCompleted);
            }
            else
            {
                MessageBox.Show("Please enter some text in the textbox ", "message", MessageBoxButtons.OK);
            }
        }
        void computer_SpeakCompleted(object sender, EventArgs e)
        {
            label3.Text = "IDLE";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (computer != null)
            {
                if (computer.State == SynthesizerState.Speaking)
                {
                    computer.Pause();
                    label3.Text = "Paused";
                    button3.Enabled = true;
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (computer != null)
            {
                if (computer.State == SynthesizerState.Paused)
                {
                    computer.Resume();
                    label3.Text = "RUNNING";

                }
                button3.Enabled = false;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
