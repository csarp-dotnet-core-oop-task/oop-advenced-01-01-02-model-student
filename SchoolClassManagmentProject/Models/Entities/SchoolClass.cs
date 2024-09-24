using SchoolClassManagmentProject.Models.AppException;

namespace SchoolClassManagmentProject.Models.Entities
{
    public class SchoolClass
    {
        private byte _grade;
        private char _gradeLetter;
        private byte _lastGrade;
        
        // grade > lastGrade akkor már végzett
        public SchoolClass()
        {
            _grade = byte.MinValue;
            _gradeLetter = char.MinValue;
        }

        public SchoolClass(byte grade, char gradeLetter, byte lastGrade)
        {
            _grade = grade;
            _gradeLetter = gradeLetter;
            _lastGrade = lastGrade;
        }

        public byte Grade { get => _grade; set => _grade = value; }
        public char GradeLetter { get => _gradeLetter; set => _gradeLetter = value; }
        public byte LastGrade { get => _lastGrade; private set => _lastGrade = value; }

        // public string Name { get => $"{grade}. {gradeLetter}"; }
        public string Name => $"{_grade}. {_gradeLetter}";

        // getelhető property
        public bool HasGraduated => _grade > _lastGrade;
        public bool IsGraduate => _grade == _lastGrade;
        public bool IsActive => !HasGraduated;

        public void SetLastGrade(byte newGrade)
        {
            if (newGrade > _grade)
                LastGrade = newGrade;
            else
                throw new LastGradeModificationErrorException($"{nameof(SchoolClass)} osztályba, {nameof(SetLastGrade)} metódusban paraméter hiba történt.", nameof(newGrade),null);
        }

        public void AdvanceGrade()
        {
            if (IsActive)
                Grade = (byte) (Grade + 1);
        }

        ~SchoolClass()
        {
            Console.WriteLine($"{_grade}. {_gradeLetter} osztály megszünt.");
        }
    }
}
