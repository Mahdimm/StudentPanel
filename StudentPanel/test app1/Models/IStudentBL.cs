using System.Collections.Generic;

namespace test_app1.Models
{
    public interface IStudentBL
    {
        List<Student> show();
        void insert(Student stu);
        Student find(int id);

        bool update(Student stu);

        void delete(int id);
    }
}