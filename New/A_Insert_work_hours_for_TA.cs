﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace New
{
    public partial class A_Insert_work_hours_for_TA : Form
    {
        public static A_Insert_work_hours_for_TA currentA_Insert_work_hours_for_TA;
        TeachingAssitant ta;
        SqlCommand cmd;
        SqlDataReader dr;
        string followNum;
        int index;
        int nextIndex = 0;
        String depID;

        public TeachingAssitant passValue
        {
            get { return ta; }
            set { ta = value; }
        }


        public A_Insert_work_hours_for_TA(TeachingAssitant ta)
        {
            InitializeComponent();
            this.ta = ta;
            name.Text = "Hello " + ta.getFirstName().ToString() + "!";
        }

        private void button_SUBMIT_Click(object sender, EventArgs e)
        {
            bool alreadySigned = false;

            if (String.IsNullOrEmpty(textBox_hoursAmount.Text))
            {
                MessageBox.Show("You dont enter your work hours amount");
                this.Hide();
                A_Insert_work_hours_for_TA.currentA_Insert_work_hours_for_TA.Show(); //form = new A_Insert_work_hours_for_TA(ta);
               // form.ShowDialog();
            }

            SqlConnection cn = new SqlConnection("Data Source=p17server.database.windows.net;Initial Catalog=P17DATABASE;Persist Security Info=True;User ID=P17;Password=Hadas@2017");
            cn.Open();
            SqlCommand cmd0 = new SqlCommand("SELECT MAX (Num) FROM staffHours", cn);
            dr = cmd0.ExecuteReader();
            while (dr.Read())
            {
                //getting the last Num in table - in order to know to set next primary key

                followNum = dr[0].ToString();

                index = Int32.Parse(followNum) + 1;
                nextIndex = index; //in order to get the number outside the loop

            }
            dr.Close();

            List<String> dept = new List<string>();

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM UsersDepartment", cn);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ID"].ToString() == ta.getID().ToString())
                {
                    dept.Add(dr["IDdepartment"].ToString());

                }

            }
            
            dr.Close();


            if (dept.Count() == 0)
            {
                MessageBox.Show("You'r not associated with a department \n You'r not allowed to insert work hours");
                textBox_hoursAmount.Clear();
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM staffHours", cn);
                dr = cmd2.ExecuteReader();
                while (dr.Read())
                {

                    if (dr["ID"].ToString() == ta.getID().ToString())
                    {


                        if (Int32.Parse(dr["month"].ToString()) == numericUpDown_month.Value)
                        {

                            if (Int32.Parse(dr["year"].ToString()) == numericUpDown_year.Value)
                            {

                                alreadySigned = true;
                                break;
                            }
                        }
                    }

                }
                dr.Close();

                if (!alreadySigned)
                {

                    cmd = new SqlCommand("INSERT INTO staffHours(Num,ID,name,Type,IDdepartment,month,year,hoursAmount) VALUES (@Num,@ID,@name,@Type,@IDdepartment,@month,@year,@hoursAmount)", cn);
                    cmd.Parameters.AddWithValue("@Num", nextIndex);
                    cmd.Parameters.AddWithValue("@ID", ta.getID().ToString());
                    cmd.Parameters.AddWithValue("@name", ta.getFirstName().ToString() + " " + ta.getLastName().ToString());
                    cmd.Parameters.AddWithValue("@Type", 3);
                    cmd.Parameters.AddWithValue("@IDdepartment", dept[0]);
                    cmd.Parameters.AddWithValue("@month", numericUpDown_month.Value);
                    cmd.Parameters.AddWithValue("@year", numericUpDown_year.Value);
                    cmd.Parameters.AddWithValue("@hoursAmount", textBox_hoursAmount.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    MessageBox.Show("Your work hours added succesfully!");
                    this.Close();
                    A_TeachingAssistant back = new A_TeachingAssistant(ta);
                    this.Hide();
                    back.ShowDialog();


                }



                else
                {

                    if (alreadySigned)
                    {
                        MessageBox.Show("You have already enterd your hours for: " + numericUpDown_month.Value + " - " + numericUpDown_year.Value);
                    }
                    textBox_hoursAmount.Clear();
                    MessageBox.Show(" *** PAY ATTENTION: insertion work hours FAILED! ***");


                }
            }

            

            cn.Close();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            A_TeachingAssistant back = new A_TeachingAssistant(ta);
            back.ShowDialog();
        }

        private void A_Insert_work_hours_for_TA_Load(object sender, EventArgs e)
        {
            currentA_Insert_work_hours_for_TA = this;
        }
    }
}
