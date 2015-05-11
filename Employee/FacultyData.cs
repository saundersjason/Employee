using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SavannahState.Employee
{
    public class FacultyData:IEmployeeData
    {
        public List<Employee> Load(Boolean fullDetail)
        {
            List<Employee> facultyMembers = new List<Employee>();

            DBConnection dbConnFaculty = new DBConnection();
            SqlConnection dbConn = dbConnFaculty.GetConnection();
            dbConn.Open();
            String sSQL = "SELECT Id FROM Employees WHERE Enabled = 1";
            SqlCommand cmd = new SqlCommand(sSQL, dbConn);
            SqlDataReader item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    String newGuid = item["Id"].ToString();
                    Employee employee = new Employee();
                    employee = PopulateEmployee(newGuid);
                    facultyMembers.Add(employee);
                }
            }
            item.Close();
            item.Dispose();

            dbConn.Close();
            dbConn.Dispose();

            return facultyMembers;
        }

        private Employee PopulateEmployee(String Id)
        {
            Employee employee = new Employee();
            DBConnection dbConnFaculty = new DBConnection();
            SqlConnection dbConn = dbConnFaculty.GetConnection();
            dbConn.Open();
            String sSQL = "SELECT * FROM Employees WHERE ";
            sSQL += " Id = '" + Id + "' AND Enabled = 1";
            SqlCommand cmd = new SqlCommand(sSQL, dbConn);
            SqlDataReader item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    if (!string.IsNullOrEmpty(item["Id"].ToString()))
                    {
                        try
                        {
                            Guid newGuid = new Guid(item["Id"].ToString());
                            employee.Id = newGuid;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (!string.IsNullOrEmpty(item["DMId"].ToString()))
                    {
                        employee.DMId = (string)item["DMId"];
                    }
                    if (!string.IsNullOrEmpty(item["FirstName"].ToString()))
                    {
                        employee.FirstName = (string)item["FirstName"];
                    }
                    if (!string.IsNullOrEmpty(item["MiddleName"].ToString()))
                    {
                        employee.MiddleName = (string)item["MiddleName"];
                    }
                    if (!string.IsNullOrEmpty(item["LastName"].ToString()))
                    {
                        employee.LastName = (string)item["LastName"];
                    }
                    if (!string.IsNullOrEmpty(item["Prefix"].ToString()))
                    {
                        employee.Prefix = (string)item["Prefix"];
                    }
                    if (!string.IsNullOrEmpty(item["Suffix"].ToString()))
                    {
                        employee.Suffix = (string)item["Suffix"];
                    }
                    if (!string.IsNullOrEmpty(item["Building"].ToString()))
                    {
                        employee.Building = (string)item["Building"];
                    }
                    if (!string.IsNullOrEmpty(item["OfficeNumber"].ToString()))
                    {
                        employee.OfficeNumber = (string)item["OfficeNumber"];
                    }
                    if (!string.IsNullOrEmpty(item["Phone"].ToString()))
                    {
                        employee.Phone = (string)item["Phone"];
                    }
                    if (!string.IsNullOrEmpty(item["Email"].ToString()))
                    {
                        employee.Email = (string)item["Email"];
                    }
                    if (!string.IsNullOrEmpty(item["Biography"].ToString()))
                    {
                        employee.Biography = (string)item["Biography"];
                    }
                    if (!string.IsNullOrEmpty(item["Interests"].ToString()))
                    {
                        employee.Interests = (string)item["Interests"];
                    }
                }
            }
            item.Close();

            sSQL = "SELECT TOP 10 Name,Organization,Description,DateStart FROM EmployeeAwards WHERE FacultyId = '" + employee.Id + "' AND Enabled = 1 ORDER BY DateStart Desc";
            cmd = new SqlCommand(sSQL, dbConn);
            item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    Award newAward = new Award();
                    if (!string.IsNullOrEmpty(item["Name"].ToString()))
                    {
                        newAward.Name = (string)item["Name"];
                    }
                    if (!string.IsNullOrEmpty(item["Organization"].ToString()))
                    {
                        newAward.Organization = (string)item["Organization"];
                    }

                    if (!string.IsNullOrEmpty(item["Description"].ToString()))
                    {
                        newAward.Description = (string)item["Description"];
                    }
                    if (!string.IsNullOrEmpty(item["DateStart"].ToString()))
                    {
                        newAward.StartDate = (DateTime)item["DateStart"];
                    }

                    employee.Awards.Add(newAward);
                }
            }
            item.Close();

            sSQL = "SELECT Degree,DegreeOther,School,Major FROM EmployeeEducation WHERE FacultyId = '" + employee.Id + "' AND Enabled = 1";
            cmd = new SqlCommand(sSQL, dbConn);
            item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    Education newSchool = new Education();

                    if (!string.IsNullOrEmpty(item["Degree"].ToString()))
                    {
                        newSchool.Degree = (string)item["Degree"];
                    }
                    if (!string.IsNullOrEmpty(item["DegreeOther"].ToString()))
                    {
                        newSchool.DegreeOther = (string)item["DegreeOther"];
                    }
                    if (!string.IsNullOrEmpty(item["School"].ToString()))
                    {
                        newSchool.School = (string)item["School"];
                    }

                    if (!string.IsNullOrEmpty(item["Major"].ToString()))
                    {
                        newSchool.Major = (string)item["Major"];
                    }
                    employee.Schools.Add(newSchool);

                }
            }
            item.Close();

            sSQL = "SELECT TOP 10 Title,Type,Publisher,Volume,Issue,PageNumber,PublicationDate,DMIntellContId FROM EmployeePublications WHERE FacultyId = '" + employee.Id + "' AND Status = 'Published' AND Enabled = 1 ORDER BY PublicationDate Desc";
            cmd = new SqlCommand(sSQL, dbConn);
            item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    Publication newPublication = new Publication();

                    if (!string.IsNullOrEmpty(item["Title"].ToString()))
                    {
                        newPublication.Title = (string)item["Title"];
                    }
                    if (!string.IsNullOrEmpty(item["Type"].ToString()))
                    {
                        newPublication.Type = (string)item["Type"];
                    }
                    if (!string.IsNullOrEmpty(item["Publisher"].ToString()))
                    {
                        newPublication.Publisher = (string)item["Publisher"];
                    }
                    if (!string.IsNullOrEmpty(item["Volume"].ToString()))
                    {
                        newPublication.Volume = (string)item["Volume"];
                    }
                    if (!string.IsNullOrEmpty(item["Issue"].ToString()))
                    {
                        newPublication.Issue = (string)item["Issue"];
                    }
                    if (!string.IsNullOrEmpty(item["PageNumber"].ToString()))
                    {
                        newPublication.PageNumber = (string)item["PageNumber"];
                    }
                    if (!string.IsNullOrEmpty(item["PublicationDate"].ToString()))
                    {
                        newPublication.PublicationDate = (DateTime)item["PublicationDate"];
                    }
                    if (!string.IsNullOrEmpty(item["DMIntellContId"].ToString()))
                    {
                        newPublication.DMIntellContId = (string)item["DMIntellContId"];
                    }
                    employee.Publications.Add(newPublication);
                }
            }
            item.Close();

            if (employee.Publications.Count > 0)
            {
                foreach (Publication publication in employee.Publications)
                {
                    sSQL = "SELECT AuthorName FROM PublicationAuthors WHERE DMIntellContId = '" + publication.DMIntellContId + "' AND AuthorName <> '' AND Enabled = 1 ORDER BY Id ASC";
                    cmd = new SqlCommand(sSQL, dbConn);
                    item = cmd.ExecuteReader();

                    if (item.HasRows)
                    {
                        while (item.Read())
                        {
                            Author newAuthor = new Author();

                            if (!string.IsNullOrEmpty(item["AuthorName"].ToString()))
                            {
                                newAuthor.Name = (string)item["AuthorName"];
                            }
                            publication.Authors.Add(newAuthor);
                        }
                    }
                    item.Close();
                }
            }


            sSQL = "SELECT Role, Scope FROM EmployeeAssignments WHERE FacultyId = '" + employee.Id + "' AND Enabled = 1 AND (DateEnd >= '" + DateTime.Now + "' OR DateEnd Is Null)";
            cmd = new SqlCommand(sSQL, dbConn);
            item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    Assignment newAssignment = new Assignment();

                    if (!string.IsNullOrEmpty(item["Role"].ToString()))
                    {
                        newAssignment.Role = (string)item["Role"];
                    }
                    if (!string.IsNullOrEmpty(item["Scope"].ToString()))
                    {
                        newAssignment.Scope = (string)item["Scope"];
                    }

                    employee.Assignments.Add(newAssignment);

                }
            }
            item.Close();


            sSQL = "SELECT Id,College,Rank FROM YearlyData WHERE FacultyId = '" + employee.Id + "' AND Enabled = 1 AND (DateEnd >= '" + DateTime.Now + "' OR DateEnd Is Null)";
            cmd = new SqlCommand(sSQL, dbConn);
            item = cmd.ExecuteReader();

            if (item.HasRows)
            {
                while (item.Read())
                {
                    YearlyData yearlyDataItem = new YearlyData();

                    if (!string.IsNullOrEmpty(item["Id"].ToString()))
                    {
                        try
                        {
                            Guid newGuid = new Guid(item["Id"].ToString());
                            yearlyDataItem.Id = newGuid;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (!string.IsNullOrEmpty(item["College"].ToString()))
                    {
                        yearlyDataItem.College = (string)item["College"];
                    }
                    if (!string.IsNullOrEmpty(item["Rank"].ToString()))
                    {
                        yearlyDataItem.Rank = (string)item["Rank"];
                    }
                    employee.YearlyDatas.Add(yearlyDataItem);
                }
            }
            item.Close();




            if (employee.YearlyDatas.Count > 0)
            {
                foreach (YearlyData yearlydata in employee.YearlyDatas)
                {
                    sSQL = "SELECT Department,Discipline FROM YearlyDataDepartments WHERE YearlyDataId = '" + yearlydata.Id + "' AND Enabled = 1";
                    cmd = new SqlCommand(sSQL, dbConn);
                    item = cmd.ExecuteReader();

                    if (item.HasRows)
                    {
                        List<YearlyDataDepartment> tempYearlyDataDepartments = new List<YearlyDataDepartment>();
                        while (item.Read())
                        {
                            YearlyDataDepartment yearlyDataDepartmentItem = new YearlyDataDepartment();
                            if (!string.IsNullOrEmpty(item["Department"].ToString()))
                            {
                                yearlyDataDepartmentItem.Department = (string)item["Department"];
                            }

                            if (!string.IsNullOrEmpty(item["Discipline"].ToString()))
                            {
                                yearlyDataDepartmentItem.Discipline = (string)item["Discipline"];
                            }

                            tempYearlyDataDepartments.Add(yearlyDataDepartmentItem);
                        }
                        yearlydata.YearlyDataDepartments = tempYearlyDataDepartments;
                    }
                    item.Close();
                }
            }
            item.Dispose();


            dbConn.Close();
            dbConn.Dispose();
            return employee;

        }
    }
}
