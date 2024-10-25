// using System;
// using System.Linq;
// using System.Collections.Generic;
// using Microsoft.VisualBasic;
// using System.Data;
// namespace PRACTICECODE;

// class Program
// {
//   public static void Main()

// IList<Person> persons = new List<Person>(){
//     new Person() {
//      name = "John Doe",
//       age= 28,
//       email= "john.doe@example.com",
//       hobbies = ["Swimming", "Running", "Coding"]
//    },

//    new Person()
//    {
//      name ="Jane Smith",
//      age=34,
//      email = "jane.smith@example.com",
//      hobbies= ["Painting", "Running", "Cycling"]
//    },

//    new Person()
//    {
//      name = "Sam Brown",
//      age =22,
//      email = "sam.brown@example.com",
//      hobbies = ["Gaming", "Music", "Cooking"]
//    },

//   new Person()
//    {
//      name= "Emily White ",
//      age =45,
//      email ="emily.white@example.com",
//      hobbies = ["Gardening", "Photography", "Traveling"]
//    },
//    new Person
//    {
//      name = "Michael Green",
//      age = 29,
//      email = "michael.green@example.com",
//      hobbies = ["Hiking", "Writing", "Swimming"]
//    }

//     };

// // 1
// var result = persons.Where(p => p.age > 30);
// Console.WriteLine("1");

// foreach (var r in result)
// {
//   Console.WriteLine(r.name);
// }
// //2

// var excertresult = persons.Select(p => new { p.name, p.email }).ToList();
// Console.WriteLine("2");
// int i1=0;
// foreach (var ex in excertresult)
// {

//   Console.WriteLine($"{++i1} - Name = {ex.name}, Email = {ex.email}");
// }
// // 3
// var orderByResult = persons.OrderBy(p => p.age).ToList();
// Console.WriteLine("3");
// int i =0;
// foreach (var orderby in orderByResult)
// {
//   i++;
//   Console.WriteLine($" {i} - {orderby.name } - {orderby.age}");
// }

// //4
// var groupresult = persons.GroupBy(p => p.name[0]);

// Console.WriteLine("4");
// foreach (var group in groupresult)
// {
//   Console.WriteLine($"group name start the first letter :{group.Key}");
//   foreach (var g in group)
//   {
//     Console.WriteLine($"Name : {g.name}");
//   }
// }

// //5

// var ave = persons.Average(p => p.age);
// Console.WriteLine("5");
// Console.WriteLine($"average : {ave}");

// //6

// var hobby = persons.FirstOrDefault(p => p.hobbies.Contains("Swimming"));
// Console.WriteLine("6");
// Console.WriteLine($"swimming hobby : {hobby.name} ");


// var startname = persons.Select(p => p.name.Contains("E")).ToList();
// Console.WriteLine("9");

// int index = 0;
// foreach (var sn in startname)
// {
//   index++;
//   Console.WriteLine($"starting name in E : {index} - {sn}");

//     }
//     //10



//     var unique = persons.SelectMany(p=>p.hobbies).Distinct().ToList();
//     Console.WriteLine($"List of hobbies :");
//     int index1 = 0;
//     // for (int i = 0; i < unique.Count; i++)
//     // {
//     //   Console.WriteLine($"{i+1} - {unique[i]}");
//     // }
//     foreach (var un  in unique)
//     {
//        index1++;
//       Console.WriteLine($"{index1} - {un}");

//     }
//   }
// }
// public class Person
// {
//   public string name { get; set; }
//   public int age { get; set; }
//   public string email { get; set; }
//   public string[] hobbies { get; set; }
// }
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Data;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
namespace PRACTICECODE;

class Program
{
    public static void Main()

    {
        IList<Employee> employee = new List<Employee>()
         {
           new Employee()
           {
               id =1,
               name= "Alice Johnson",
               age = 30,
               email = "alice.johnson@example.com",
               departmentId = 1,
               projects = new List<Project>(){
                new Project()
                {
                    projectName = "Project A",
                    hoursWorked = 120
                },
                new Project()
                {
                    projectName = "Project B",
                    hoursWorked = 100
                }
            }
           },
           new Employee()
           {
            id = 2,
            name ="Bob Smith",
            age =42,
            email = "bob.smith@example.com",
            departmentId = 2,
            projects = new List<Project>(){
                new Project()
                {
                    projectName = "Project A",
                    hoursWorked = 200
                },
                new Project()
                {
                    projectName = "Project C",
                    hoursWorked = 150
                }
            }
           },
           new Employee()
           {
            id = 3,
            name ="Corel White",
            age = 25,
            email = "corel.white@example.com",
            departmentId = 1,
            projects = new List<Project>()
            {
                new Project()
                {
                    projectName = "Project B",
                    hoursWorked = 90
                },
                new Project()
                {
                    projectName = "Project C",
                    hoursWorked = 110
                }
            }
           }
        };

        IList<Department> departments = new List<Department>()
        {
          new Department()
          {
            departmentName = "Development",
            Id = 1,
          },
          new Department()
          {
            departmentName = "Marketing",
            Id = 2,
          },
        };

       //? 1
        var employeedevelopment = employee.Where(e => e.age >= 30 && departments.Any(d => d.Id == e.departmentId && d.departmentName == "Development"))
                                 .Select(e => e.name);
        Console.WriteLine("1");
        Console.WriteLine("employee name :");
        foreach (var emde in employeedevelopment)
        {
            Console.WriteLine(emde);
        }
        

        //2

        var retrievename = employee.Select(e => new { e.name, Department = departments.FirstOrDefault(d => d.Id == e.departmentId)?.departmentName });
        Console.WriteLine("2");
        Console.WriteLine("name of the employee along with their departmentname :") ;
        foreach (var rena in retrievename)
        {
            Console.WriteLine($"employee name - {rena.name} , departmentname - {rena.Department}");
        }

      //  3

        var totalworkhour = employee.Select(e=> new {e.name , Totalhours = e.projects.Sum(p=>p.hoursWorked)});
        Console.WriteLine("3");
        Console.WriteLine("Name of the employee workedhours in all project : ");
        foreach(var totalhrs in totalworkhour)
        {
            Console.WriteLine($"employee name - {totalhrs.name} - {totalhrs.Totalhours} hours");
        }

        //4
         var averagedepartment = employee.GroupBy(e=>e.departmentId).ToList().Select(a=>new {Department = departments.
                                 First(d=>d.Id == a.Key).departmentName , Average = a.Average(e=>e.age)});
         Console.WriteLine("4");
         Console.WriteLine("Average age of employees in  department : ");
         foreach(var avde in averagedepartment)
         {
            Console.WriteLine($"department - {avde.Department} , average age - {avde.Average}");
         }

        //5
        var mosthours = employee.Where(e=>e.projects.Any(p=>p.projectName == "Project A"))
                                 .Select(e=>new {e.name , Project = e.projects.First(p=>p.projectName == "Project A").hoursWorked}).
                                 OrderByDescending(e=>e.Project);
        Console.WriteLine("5");
        Console.WriteLine("Most hours worked on project A : ");
        foreach(var mh in mosthours)
        {
            Console.WriteLine($"{mh.name} - {mh.Project}");
        }

      //  6

        var projectworked = employee.Select(e=> new {e.name, Pro = e.projects.Select(p=>p.projectName)});
        Console.WriteLine("6");
        Console.WriteLine("Name the project worked on employee : ");
        foreach(var prwo in projectworked)
        {
            Console.WriteLine($"{prwo.name} -");
            foreach(var proj in prwo.Pro)
            {
                Console.WriteLine($"{proj}");
            }
        }

        //7

        var singleproject = employee.Where(e=>e.projects.Any(p=>p.hoursWorked >100)).Select(e=>e.name);
        Console.WriteLine("7");
        Console.WriteLine("More than 100 worked in employees : ");
         foreach(var sipr in singleproject)
         {
            Console.WriteLine($"{sipr}");
         }

         //8

         var checking = employee.Where(e=>e.projects.Any(p=>p.projectName == "Project D")).Select(e=>e.name);
         Console.WriteLine("8");
         Console.WriteLine("Any employee work on project D :");
         foreach(var ch in checking)
         {
            Console.WriteLine($"{ch}");
         }

         //9

         var uniqueproject = employee.SelectMany(e=>e.projects).Select(p=>p.projectName).Distinct().ToList();
         Console.WriteLine("9");
         Console.WriteLine("unique project names in employee : ");
          int index = 0;
          foreach(var up in uniqueproject)
          {
            index++;
            Console.WriteLine($"{index} - {up}");
          }

          //10

        var totalhours = employee.Select(e=>e.projects);
        // .Any(p..Sum(p=>p.hoursWorked))
          
    }
}

public class Employee
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string email { get; set; }
    public int departmentId { get; set; }
    public List<Project> projects { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string departmentName { get; set; }
}

public class Project
{
    public string projectName { get; set; }
    public decimal hoursWorked { get; set; }
}