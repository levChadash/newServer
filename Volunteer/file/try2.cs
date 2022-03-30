//using Entity;
//using KellermanSoftware.ExcelReports;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BL;
//using DL;
//namespace Volunteer
//{
//    public class try2 : Itry2
//    {
//        IStudentDL istudentdl;
//        IGradeDL Gradedl;

//        public try2(IStudentDL istudentdl, IGradeDL Gradedl, INieghborhoodDL nieghborhooddl)
//        {
//            this.istudentdl = istudentdl;
//            this.Gradedl = Gradedl;
//            this.nieghborhooddl = nieghborhooddl;
//        }
//        //IFormFile iff
//        public async Task aa()
//    //    {
//    //        int i = 0;
//    //        int j = 0;
//    //        string[] array = new string[8];
//    //        foreach (var worksheet in Workbook.Worksheets(@"M:\Project\students.xlsx"))
//    //        {
//    //            foreach (var row in worksheet.Rows)
//    //            {
//    //                if (i > 0)
//    //                {
//    //                    foreach (var cell in row.Cells)
//    //                    {
//    //                        array[j++] = cell.Value;
//    //                    }


//    //                    Person p = new Person
//    //                    {
//    //                        IdNumber = array[0],
//    //                        Name = array[1] + " " + array[2]
//    //                    };
//    //                    Person ptry = await istudentdl.GetPersonByIdNumber(p.IdNumber);
//    //                    string pid = p.IdNumber;
//    //                    int studentId;
//    //                    Student s;
//    //                    if (ptry == null)
//    //                    {
//    //                        int num = int.Parse(array[6]);
//    //                        string nieghborhoodName = array[3];
//    //                        int id = await istudentdl.PostPerson(p);
//    //                        int Gid = await Gradedl.GetGradeId(num);
//    //                        int Nid = await nieghborhooddl.GetNieghborhoodId(nieghborhoodName);
//    //                        s = new Student
//    //                        {
//    //                            PersonId = id,
//    //                            GradeId = Gid,
//    //                            NeighborhoodId = Nid

//    //                        };
//    //                        studentId = await istudentdl.PostStudent(s);
//    //                    }
//    //                    else
//    //                    {
//    //                        s = await istudentdl.GetStudentByNumberId(pid);
//    //                        studentId = s.Id;
//    //                    }
                        
//    //                    StudentYear sy = new StudentYear
//    //                    {
//    //                        StudentId = studentId,
//    //                        Year = (int)(DateTime.Now.Year+1),
//    //                        ClassNumber = int.Parse(array[7])
//    //                    };
//    //                    istudentdl.PostStudentYears(sy);
//    //                }
//    //                i++;
//    //                j = 0;
                    
//    //            }
//    //        }
//    //    }
//    //}
//}
