using System;
using System.Collections.Generic;

namespace _420FinalProject.Models
{
    public partial class UniversityTable
    {
        public UniversityTable()
        {
            EducationEffectTables = new HashSet<EducationEffectTable>();
        }

        public double UniversityId { get; set; }
        public string Institution { get; set; }
        public double Score { get; set; }
        public double Year { get; set; }

        public virtual ICollection<EducationEffectTable> EducationEffectTables { get; set; }
    }
}
