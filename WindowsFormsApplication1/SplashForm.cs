using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class SplashForm : Form
    {
        private Panel panel1;
        private System.ComponentModel.IContainer components;
        private Label label1;

        //Delegate for cross thread call to close
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static SplashForm splashForm;

        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.


            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            
            splashForm = new SplashForm();
            splashForm.FormBorderStyle = FormBorderStyle.None;
            splashForm.StartPosition = FormStartPosition.CenterScreen;
            //splashForm.Size = new Size(679, 569);
            splashForm.InitializeComponent();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 365);
            this.panel1.TabIndex = 0;
            this.panel1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(3, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 368);
            this.label1.TabIndex = 0;
            this.label1.UseWaitCursor = true;
            // 
            // SplashForm
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(449, 389);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashForm";
            this.UseWaitCursor = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
