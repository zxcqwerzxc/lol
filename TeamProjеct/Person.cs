using System;

namespace TeamProject
{
    internal class Person : ICloneable
    {
        String firstName;
        String lastName;
        DateTime birthday;

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (DateTime.Today >= value)
                    birthday = value;
                else
                    throw new ArgumentException("День рождения не может быть больше сегодняшнего дня");
            }
        }
        public String FirstName
        {
            get => firstName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                firstName = value;
            }
        }
        public String LastName
        {
            get => lastName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                lastName = value;
            }
        }

        public int Years
        {
            get => birthday.Year;
            set
            {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException("Передаваемый год больше года в данный момент");

                int differenceYears = DateTime.Now.Year - value;

                birthday = birthday.AddYears(-differenceYears);
            }
        }

        public Person()
        {
            this.firstName = "Имя неизвестно";
            this.lastName = "Фамилия неизвестна";
            this.birthday = DateTime.Today;
        }

        public Person(String firstName, String lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public override string ToString() => $"Имя: {firstName}; Фамилия: {LastName}; год рождения: {birthday.ToShortDateString()}";

        public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person person = (Person)obj;
            return firstName == person.firstName && lastName == person.lastName && birthday == person.birthday;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, lastName, birthday);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;

            if (p1 is null || p2 is null)
                return false;

            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public object Clone()
        {
            return new Person(firstName, lastName, birthday);
        }

        public Person DeepCopy()
        {
            return new Person(firstName, lastName, birthday);
        }
    }
}
