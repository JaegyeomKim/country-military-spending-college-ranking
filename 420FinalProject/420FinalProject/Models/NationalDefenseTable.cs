using System;
using System.Collections.Generic;

namespace _420FinalProject.Models
{
    public partial class NationalDefenseTable
    {
        public NationalDefenseTable()
        {
            EducationEffectTables = new HashSet<EducationEffectTable>();
        }

        public double DefenseId { get; set; }
        public double CountryId { get; set; }
        public double SpendMoney { get; set; }

        public virtual CountryTable? Country { get; set; }
        public virtual ICollection<EducationEffectTable> EducationEffectTables { get; set; }
    }
}
