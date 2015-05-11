using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    interface IEmployeeData
    {
        List<Employee> Load(Boolean fullDetail);
    }
}
