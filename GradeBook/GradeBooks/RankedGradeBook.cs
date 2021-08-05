using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count() < 5)
                throw new InvalidOperationException();

            int NumberOfStudentsWithHigherGrade = Students.Where(s => s.AverageGrade > averageGrade).Count();

            double ratioOfStudentsWithHigherGrade = (double)NumberOfStudentsWithHigherGrade / (double)Students.Count();

            if (ratioOfStudentsWithHigherGrade < 0.2)
                return 'A';
            else if (ratioOfStudentsWithHigherGrade < 0.4)
                return 'B';
            else if (ratioOfStudentsWithHigherGrade < 0.6)
                return 'C';
            else if (ratioOfStudentsWithHigherGrade < 0.8)
                return 'D';

            return 'F';
        }
    }
}
