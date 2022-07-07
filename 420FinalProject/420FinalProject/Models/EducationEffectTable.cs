using System;
using System.Collections.Generic;

namespace _420FinalProject.Models
{
    public partial class EducationEffectTable
    {
        public double EffectId { get; set; }
        public double UniversityId { get; set; }
        public double DefenseId { get; set; }
        public double CountryId { get; set; }
        public double WorldUniversityRanking { get; set; }

        public virtual CountryTable Country { get; set; }
        public virtual NationalDefenseTable Defense { get; set; }
        public virtual UniversityTable University { get; set; }
    }
}
