using static System.Attribute;

namespace StudentRecords;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]


public class TestInfo: Attribute
{
    private int testInfoId;
    private string testInfoName;

    public TestInfo(int id, string name)
    {
        testInfoId = id;
        testInfoName = name;
    }


    public bool IsTestValid { get; set; }
    public int TestInfoId
    {
        get
        {
            return testInfoId;
        }
    }

    public string TestInfoName
    {
        get
        {
            return testInfoName;
        }
    }
}


[TestInfo(1, "Test ID 1", IsTestValid = false)]
[TestInfo(2, "Test ID 2", IsTestValid = true)]

class Student
{
    public bool TestField = false;
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