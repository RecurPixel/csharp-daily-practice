// **Concepts:** Struct, Arrays, File Writing  
// - Define a `Student` struct → `Id`, `Name`, `Marks`.  
// - Input multiple students and save their data to a file.  
// 🧩 **Bonus:** Load data and calculate average marks.

using System.Text.Json;

namespace StudentRecord;

struct Student
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double Marks { get; init; }

    public Student(int id, string name, double marks)
    {
        Id = id;
        Name = name;
        Marks = marks;
    }
    public override string ToString()
    {
        return $"[ID: {Id}] Name: {Name,-15} | Marks: {Marks:F2}";
    }

}


class StudentRecord
{
    private const string FileName = "records.json";
    private int nextStudentId = 10001;
    private List<Student> students = new List<Student>();
    public StudentRecord()
    {
        // Load data immediately upon creation
        LoadFromFile();
    }

    private void LoadFromFile()
    {

        if (!File.Exists(FileName))
        {
            Console.WriteLine($"No previous record file found ({FileName}). Starting new list.");
        }
        try
        {
            string jsonStringFromFile = File.ReadAllText(FileName);
            List<Student>? loadedStudents = JsonSerializer.Deserialize<List<Student>>(jsonStringFromFile);

            if (loadedStudents != null)
            {
                students = loadedStudents;
                nextStudentId = students.Any() ? students.Max(s => s.Id) + 1 : 10001;
                Console.WriteLine($"Loaded {students.Count} records from {FileName}. Next ID: {nextStudentId}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }

    }

    private void SaveToFile()
    {
        try
        {
            // Serialize ONLY the List<Student> for simplicity and cleaner data structure
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to the file
            File.WriteAllText(FileName, jsonString);
            Console.WriteLine($"\nSuccessfully saved {students.Count} records to {FileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR saving file: {ex.Message}");
        }
    }
    private void DisplayStudents()
    {
        Console.WriteLine("\n--- Student Records ---");

        if(students.Count == 0)
        {
            Console.WriteLine("No students currently loaded.");
            return;
        }

        foreach (Student s in students)
        {
            Console.WriteLine($"{s.ToString()}");
        }

        if (students.Any())
        {
            double averageMarks = students.Average(s => s.Marks);
            Console.WriteLine($"\nTotal Students: {students.Count} | Average Marks: {averageMarks:F2}");
        }
    }
    private bool AddStudent()
    {
        Console.Write("Student Name: ");
        string? sName = Console.ReadLine();

        Console.Write("Student Marks: ");
        if (!double.TryParse(Console.ReadLine(), out double sMarks))
        {
            Console.WriteLine("Invalid marks. Student not added.");
            return false;
        }

        students.Add(new Student(nextStudentId, sName ?? "N/A", sMarks));
        Console.WriteLine($"Added Student ID: {nextStudentId}");
        nextStudentId++;
        return true;
    }

    public static void Main()
    {
        StudentRecord sr = new StudentRecord();

        sr.AddStudent();
        sr.AddStudent();

        sr.DisplayStudents();
        
        sr.SaveToFile();
    }
}