using System.ComponentModel.Design;
using data;
using reader;

Reader<Employee> er = new Reader<Employee>();

List<Employee> employees =
    er.ReadList("data/employees.csv",
        x => new Employee(x[0],x[1],x[2],x[3],x[4],x[5],x[6],x[7],x[8],x[9],x[10],x[11],x[12],x[13],x[14],x[15],x[16],x[17]));

var secondNames = from secondName in employees
    select employees;

