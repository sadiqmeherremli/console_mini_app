using System;
using System.Linq;
using task_code;

namespace TaskCode
{
    public class Program
    {
        public static void Main()
        {
            var classrooms = new Classroom[100];
            var students = new Student[100];
            var classroomCount = 0;
            var studentCount = 0;

            while (true)
            {
                Console.WriteLine("Menyu:");
                Console.WriteLine("1. Sinif yarat");
                Console.WriteLine("2. Telebe yarat");
                Console.WriteLine("3. Butun telebeleri ekrana cixart");
                Console.WriteLine("4. Secilmis sinifdeki telebeleri ekrana cixart");
                Console.WriteLine("5. Telebe sil");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Sef secim yeniden yoxla");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Sinif adini daxil edin (2 boyuk herf ve 3 reqem):");
                        var className = Console.ReadLine();
                        if (!IsValidClassName(className))
                        {
                            Console.WriteLine(" sinif adi duzgun deyil.");
                            continue;
                        }

                        var classType = GetTypeInput();
                        if (classType == ClassroomType.Unknown)
                        {
                            Console.WriteLine("Duzgun deyil Backend veya FrontEnd olmalidir");
                            continue;
                        }

                        classrooms[classroomCount++] = new Classroom(className, classType);
                        Console.WriteLine("Sinif yaradildi");
                        break;

                    case 2:
                        Console.WriteLine("Telebenin adini daxil edin:");
                        var name = Console.ReadLine();
                        var surname = Console.ReadLine();
                        if (!IsValidName(name) || !IsValidSurname(surname))
                        {
                            Console.WriteLine(" ad veya soyad duzgun deyil");
                            continue;
                        }

                        Console.WriteLine("Hansi sinifa elave etmek isteyirsiniz? (Sinif adini daxil edin):");
                        var classToAdd = Console.ReadLine();
                        var classroomToAdd = classrooms.FirstOrDefault(c => c != null && c.Name == classToAdd);
                        if (classroomToAdd == null)
                        {
                            Console.WriteLine("sinif tapilmadi");
                            continue;
                        }

                        classroomToAdd.AddStudent(new Student(name, surname));
                        Console.WriteLine("Telebe elave edildi");
                        break;

                    case 3:
                        foreach (var classroom in classrooms)
                        {
                            if (classroom != null)
                            {
                                foreach (var student in classroom.Students)
                                {
                                    if (student != null)
                                    {
                                        Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}");
                                    }
                                }
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Hansi sinifdeki telebeleri gormek istersiniz? (Sinif adini daxil edin):");
                        var classToDisplay = Console.ReadLine();
                        var classroomToDisplay = classrooms.FirstOrDefault(c => c != null && c.Name == classToDisplay);
                        if (classroomToDisplay == null)
                        {
                            Console.WriteLine("sinif tapilmadi.");
                            continue;
                        }

                        foreach (var student in classroomToDisplay.Students)
                        {
                            if (student != null)
                            {
                                Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Silinecek telebenin adini ve soyadini daxil edin:");
                        var studentToDeleteName = Console.ReadLine();
                        var studentToDeleteSurname = Console.ReadLine();
                        var studentToDelete = students.FirstOrDefault(s => s != null && s.Name == studentToDeleteName && s.Surname == studentToDeleteSurname);
                        if (studentToDelete == null)
                        {
                            Console.WriteLine("Telebe tapilmadi.");
                            continue;
                        }

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i] == studentToDelete)
                            {
                                students[i] = null;
                                break;
                            }
                        }

                        Console.WriteLine("Telebe silindi");
                        break;

                    default:
                        Console.WriteLine("sef secim");
                        break;
                }
            }
        }

        public static ClassroomType GetTypeInput()
        {
            Console.WriteLine("Sinif tipini daxil edin (Backend/FrontEnd):");
            var typeInput = Console.ReadLine();
            return typeInput.ToLower() switch
            {
                "backend" => ClassroomType.Backend,
                "frontend" => ClassroomType.FrontEnd,
                _ => ClassroomType.Unknown
            };
        }

        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && char.IsUpper(name[0]) && name.Length >= 3;
        }

        public static bool IsValidSurname(string surname)
        {
            return IsValidName(surname);
        }

        public static bool IsValidClassName(string className)
        {
            return className.Length == 5 && char.IsUpper(className[0]) && char.IsUpper(className[1]) && className.Substring(2).All(char.IsDigit);
        }
    }

    public enum ClassroomType
    {
        Backend,
        FrontEnd,
        Unknown
    }

   
   
}

