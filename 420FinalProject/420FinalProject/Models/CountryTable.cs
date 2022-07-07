using System;
using System.Collections.Generic;

namespace _420FinalProject.Models
{
    public partial class CountryTable
    {
        public CountryTable()
        {
            EducationEffectTables = new HashSet<EducationEffectTable>();
            NationalDefenseTables = new HashSet<NationalDefenseTable>();
        }

        public double CountryId { get; set; }
        public string Country { get; set; }

        public virtual ICollection<EducationEffectTable> EducationEffectTables { get; set; }
        public virtual ICollection<NationalDefenseTable> NationalDefenseTables { get; set; }
    }
}
