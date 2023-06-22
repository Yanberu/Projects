using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7
{
    
    
        struct Worker
        {
            #region Constructors
            
            public Worker(uint Id, string FullName, uint Age, DateTime BirthDate, uint Height, string BirthPlace, DateTime RecordDate)
            {
                this.id = Id;
                this.fullName = FullName;
                this.age = Age;
                this.birthDate = BirthDate;
                this.birthPlace = BirthPlace;
                this.height = Height;
                this.recordDate = RecordDate;
            }
            #endregion

            #region Properties
            public uint Id { get { return this.id; } set { this.id = value; } }
            public uint Age { get { return this.age; } set { this.age = value; } }
            public uint Height { get { return this.height; } set { this.height = value; } }
            public string FullName { get { return this.fullName; } set { this.fullName = value; } }
            public string BirthPlace { get { return this.birthPlace; } set { this.birthPlace = value; } }
            public DateTime BirthDate { get { return this.birthDate; } set { this.birthDate = value; } }
            public DateTime RecordDate { get { return this.recordDate; } set { this.recordDate = value; } }
            #endregion

            #region Fields
            private uint id;
            private uint age;
            private uint height;
            private string fullName;
            private string birthPlace;
            private DateTime birthDate;
            private DateTime recordDate;
        #endregion
        public string Print()
        {
            return $"{Id,10} {RecordDate,10} {FullName,10} {Age,15} {Height,15} {BirthDate,15} {BirthPlace,15}";
        }
    }
    }
