﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.FolderName;

namespace WindowsFormsApp3
{
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            ModelEF model = new ModelEF();
            if (model.UsersHash.ToList().Any(x =>
            x.Login == loginTextBox.Text &&
            x.Password == SHA256Builder.ConvertToHash(passwordTextBox.Text)))
            {
                MessageBox.Show("Пользователь найден!");
                return;
            }
            MessageBox.Show("Пользователь не найден!");
        }
    }
}
