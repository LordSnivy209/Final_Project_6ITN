﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jaartaak.Business
{
    public class Note
    {
        //fields
        protected int _idNote;
        protected string _userID;
        protected string _titleNote;
        protected string _noteContents;
        protected DateTime _createdDate;

        //properties
        public int IdNote
        {
            get { return _idNote; }
            set { _idNote = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string TitleNote
        {
            get { return _titleNote; }
            set { _titleNote = value; }
        }

        public string NoteContents
        {
            get { return _noteContents; }
            set { _noteContents = value; }
        }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        //constructor
        public Note(int noteID, string userID, string name, string description, DateTime createdDate)
        {
            _idNote = noteID;
            _userID = userID;
            _titleNote = name;
            _noteContents = description;
            _createdDate = createdDate;
        }

        public Note(string userID, string name, string description, DateTime createdDate)
        {
            _idNote = 0;
            _userID = userID;
            _titleNote = name;
            _noteContents = description;
            _createdDate = createdDate;
        }
        //methods
       public override string ToString()
        {
            return _titleNote + ": " + _noteContents;
        }
    }
}
