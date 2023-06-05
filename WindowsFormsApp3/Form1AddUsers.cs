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
    public partial class Form1AddUsers : Form
    {
        public Form1AddUsers()
        {
            InitializeComponent();
        }

        ModelEF model = new ModelEF();

        void StartLoad()
        {
            dataGridView1.DataSource = model.UsersHash.ToList();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLoad();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "" ||
            passwordTextBox.Text == "" ||
            firstNameTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            UsersHash usersHash = new UsersHash();
            usersHash.Login = loginTextBox.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(passwordTextBox.Text);
            usersHash.FirstName = firstNameTextBox.Text;
            try
            {
                model.UsersHash.Add(usersHash);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLoad();
            }
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
            firstNameTextBox.Text = "";
            MessageBox.Show("Данные добавляем");
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }
    }
}
