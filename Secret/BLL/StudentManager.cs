using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using BAL;
namespace BLL
{
    public static class StudentManager
    {
        public static bool Insert(string name, int phone, string email, string pass)
        {
            return StudentBAL.Insert(name, phone, email, pass);
        }

        public static List<Student> GetAllStudent()
        {
            return StudentBAL.GetAllStudent();
        }

    }   
}
