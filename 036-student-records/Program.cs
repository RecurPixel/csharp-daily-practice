// **Concepts:** Struct, Arrays, File Writing  
// - Define a `Student` struct → `Id`, `Name`, `Marks`.  
// - Input multiple students and save their data to a file.  
// 🧩 **Bonus:** Load data and calculate average marks.


struct Student
{
    public int Id;
    public string Name;
    public double Marks;

}

class StudentRecort
{
    List<Student> StudentList;
    public StudentRecort()
    {
        StudentList = new List<Student>();
    }

    private bool GetStudent()
    {

    }
    private bool AddStudent()
    {
        StudentList.Add(new Student());
        return true;
    }
    public static void Main()
    {
        StudentRecort sr = new StudentRecort();

        sr.AddStudent();
    }
}