﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogskolan_Sarob
{
   public class Personal : IPersonal
    {
        private string namn;
        private int personalID;

        private long personNnummer;
        private string email;
        private int telNr;


        private string taBort;

        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }
        public int PersonalID
        {
            get { return personalID; }
            set { personalID = value; }
        }
        public long PersonNummer
        {
            get { return personNnummer; }
            set { personNnummer = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int TelNr
        {
            get { return telNr; }
            set { telNr = value; }
        }


        public string TaBort
        {
            get { return taBort; }
            set { taBort = value; }
        }


        public void laggTillLarare(string Namn, int PersonalID, long Personnummer, string Email, int TelNr, int LararLagsID)
        {
            throw new NotImplementedException();
        }

        public void laggTillLarare(string Namn, int PersonalID, long Personnummer, string Email, int TelNr)
        {
            throw new NotImplementedException();
        }

        public void listaLararare()
        {
            throw new NotImplementedException();

        }
    }
}