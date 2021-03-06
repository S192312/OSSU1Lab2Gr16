﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hogskolan_Sarob
{
    public partial class Lararlagform : Form
    {
        #region Ctor 
        public Lararlagform()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.LararlagIDText = new System.Windows.Forms.TextBox();
            this.PersonalIDText = new System.Windows.Forms.TextBox();
            this.listBoxLararlag = new System.Windows.Forms.ListBox();
            this.listBoxPersonalID = new System.Windows.Forms.ListBox();
            this.buttonLäggTillLag = new System.Windows.Forms.Button();
            this.buttonTaBortLag = new System.Windows.Forms.Button();

            this.LararlagIDText.Location = new System.Drawing.Point(169, 50);
            this.LararlagIDText.Size = new System.Drawing.Size(100, 20);
            this.LararlagIDText.Text = "Enter Lärarlags ID";

            this.PersonalIDText.Location = new System.Drawing.Point(169, 80);
            this.PersonalIDText.Size = new System.Drawing.Size(100, 20);
            this.PersonalIDText.Text = "Enter Personal ID";

            this.listBoxLararlag.FormattingEnabled = true;
            this.listBoxLararlag.Location = new System.Drawing.Point(12, 12);
            this.listBoxLararlag.Size = new System.Drawing.Size(50, 200);

            this.listBoxPersonalID.FormattingEnabled = true;
            this.listBoxPersonalID.Location = new System.Drawing.Point(62, 12);
            this.listBoxPersonalID.Size = new System.Drawing.Size(50, 200);

            this.buttonLäggTillLag.Location = new System.Drawing.Point(180, 170);
            this.buttonLäggTillLag.Size = new System.Drawing.Size(75, 23);
            this.buttonLäggTillLag.Text = "Lägg till";

            this.buttonTaBortLag.Location = new System.Drawing.Point(180, 200);
            this.buttonTaBortLag.Size = new System.Drawing.Size(75, 23);
            this.buttonTaBortLag.Text = "Ta bort";

            this.buttonLäggTillLag.Click += new System.EventHandler(this.buttonLäggTillLag_Click);
            this.buttonTaBortLag.Click += new System.EventHandler(this.DeleteLag_Click);
            this.buttonTaBortLag.Click += new System.EventHandler(DeleteLag_Click);

            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.buttonLäggTillLag);
            this.Controls.Add(this.buttonTaBortLag);
            this.Controls.Add(this.listBoxLararlag);
            this.Controls.Add(this.listBoxPersonalID);
            this.Controls.Add(this.LararlagIDText); //Instanserar ett nytt objekt av typen TextBox
            this.Controls.Add(this.PersonalIDText);
            this.Text = "Lägg till/ ta bort lärare i lärarlag";
            this.Load += new EventHandler(Form1_Load);
#endregion
        }
        private TextBox LararlagIDText; // definnerar lagen med ID
        private TextBox PersonalIDText; // definerar personelen/ läraren med ID
        private ListBox listBoxLararlag; // listbox för lista lärarlags ID
        private ListBox listBoxPersonalID; // separat listbox för lista personal ID kopplat till lärare.
        private Button buttonLäggTillLag;
        private Button buttonTaBortLag;


        #region childform
        /// <summary>
        /// Gör detta till en childform
        /// </summary>
        private static Lararlagform m_SChildform;
        public static Lararlagform GetChildInstance2()
        {
            if (m_SChildform == null) //if not created yet, Create an instance

                m_SChildform = new Lararlagform();
            return m_SChildform;  //just created or created earlier.Return it

        }

#endregion

        void Form1_Load(object sender, EventArgs e)
        {
            InitializeListOfLararlag();
            listBoxLararlag.DataSource = lararlagLista;
            listBoxLararlag.DisplayMember = "LararLagID";
            listBoxPersonalID.DataSource = lararlagLista;
            listBoxPersonalID.DisplayMember = "PersonalID";  // "PersonalID"
            lararlagLista.AddingNew += new AddingNewEventHandler(lararlagLista_AddingNew);
            lararlagLista.ListChanged += new ListChangedEventHandler(lararlagLista_ListChanged);
        }

        #region Lista + metod
        // Deklarera ny bindlig list
        BindingList<Lararlag2> lararlagLista;
        private void InitializeListOfLararlag()
        {

            lararlagLista = new BindingList<Lararlag2>();

            lararlagLista.AllowNew = true;
            lararlagLista.AllowRemove = true;


            lararlagLista.RaiseListChangedEvents = true;


            lararlagLista.AllowEdit = false;

            lararlagLista.Add(new Lararlag2(1, 10));
            lararlagLista.Add(new Lararlag2(1, 11));
        }

        // Metod där attribut läggs till
        void lararlagLista_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Lararlag2(int.Parse(LararlagIDText.Text), int.Parse(PersonalIDText.Text));

        }

        private void buttonLäggTillLag_Click(object sender, EventArgs e)
        {
            Lararlag2 newPart = lararlagLista.AddNew();

            if (newPart.LararLagID > 10)// ite skojsigt med antalen. behövs väl ej erestriktioner på antal.
            {
                MessageBox.Show("Det kan inte finnas mer än 10 lärarlag.");
                lararlagLista.CancelNew(lararlagLista.IndexOf(newPart));
            }
            else
            {
                LararlagIDText.Text = "Lärarlags ID";
                PersonalIDText.Text = "Personal ID"; // kanske skall ha att antalet skall matcha personal ID?
            }


        }

        void lararlagLista_ListChanged(object sender, ListChangedEventArgs e)
        {
            MessageBox.Show(e.ListChangedType.ToString());

        }

        private void DeleteLag_Click(object sender, EventArgs e)
        {
            lararlagLista.Clear();

        }
        #endregion

    }
}
