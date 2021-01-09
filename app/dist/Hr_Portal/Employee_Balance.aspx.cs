using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class _Employee_Balance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    // get adminusers
    [WebMethod]
    public static string getadminusersData()
    {
        string config =
            Convert.ToString(ConfigurationManager.ConnectionStrings["dbcon"]);

        List<adminusers> adminusers = new List<adminusers>();

        SqlConnection con = new SqlConnection(config);

        con.Open();

        using (SqlCommand cmd = new SqlCommand("select * from adminusers", con))
        {
            SqlDataReader idr = cmd.ExecuteReader();

            if (idr.HasRows)
            {
                adminusers = populateadminusersLisst(idr, con);
            }
        }

        con.Close();

        return JsonConvert.SerializeObject(adminusers);
    }

    public static List<adminusers>
    populateadminusersLisst(SqlDataReader idr, SqlConnection con)
    {
        List<adminusers> adminusersI = new List<adminusers>();

        while (idr.Read())
        {
            adminusersI
                .Add(new adminusers {
                    Emp_ID =
                        idr["Emp_ID"] != DBNull.Value
                            ? Convert.ToInt32(idr["Emp_ID"])
                            : 0,
                    FullName =
                        idr["FullName"] != DBNull.Value
                            ? Convert.ToString(idr["FullName"])
                            : String.Empty,
                    Job_Description =
                        idr["Job_Description"] != DBNull.Value
                            ? Convert.ToString(idr["Job_Description"])
                            : String.Empty,
                    Area_name =
                        idr["Area_name"] != DBNull.Value
                            ? Convert.ToString(idr["Area_name"])
                            : String.Empty,
                    Branch_name =
                        idr["Branch_name"] != DBNull.Value
                            ? Convert.ToString(idr["Branch_name"])
                            : String.Empty,
                    Dept_name =
                        idr["Dept_name"] != DBNull.Value
                            ? Convert.ToString(idr["Dept_name"])
                            : String.Empty
                });
        }

        return adminusersI;
    }

    public class adminusers
    {
        public int? Emp_ID { get; set; }

        public string FullName { get; set; }

        public string Job_Description { get; set; }

        public string Area_name { get; set; }

        public string Branch_name { get; set; }

        public string Dept_name { get; set; }
    }

    // insert to HR_Employees_Vacation_Balance
    [WebMethod]
    public static string EmpVacBalance(HR_Employees_Vacation_Balance Balance)
    {
        string config =
            Convert.ToString(ConfigurationManager.ConnectionStrings["dbcon"]);

        List<HR_Employees_Vacation_Balance> HR_Employees_Vacation_Balance =
            new List<HR_Employees_Vacation_Balance>();

        SqlConnection con = new SqlConnection(config);

        con.Open();

        using (
            SqlCommand cmd =
                new SqlCommand("insert into HR_Employees_Vacation_Balance (Emp_id,Annual_Balance,Casual_Balance,Q1,Q1_DateTo,Q2,Q2_DateTo,Q3,Q3_DateTo,Q4,Q4_DateTo,Old_Balance,Old_Balance_ExpirationDate) values (@Emp_id,@Annual_Balance,@Casual_Balance,@Q1,@Q1_DateTo,@Q2,@Q2_DateTo,@Q3,@Q3_DateTo,@Q4,@Q4_DateTo,@Old_Balance,@Old_Balance_ExpirationDate)",
                    con)
        )
        {
            cmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = Balance.Emp_id;
            cmd.Parameters.Add("@Annual_Balance", SqlDbType.Int).Value =
                Balance.Annual_Balance;
            cmd.Parameters.Add("@Casual_Balance", SqlDbType.Int).Value =
                Balance.Casual_Balance;
            cmd.Parameters.Add("@Q1", SqlDbType.Int).Value = Balance.Q1;
            cmd.Parameters.Add("@Q1_DateTo", SqlDbType.VarChar).Value =
                Balance.Q1_DateTo;
            cmd.Parameters.Add("@Q2", SqlDbType.Int).Value = Balance.Q2;
            cmd.Parameters.Add("@Q2_DateTo", SqlDbType.VarChar).Value =
                Balance.Q2_DateTo;
            cmd.Parameters.Add("@Q3", SqlDbType.Int).Value = Balance.Q3;
            cmd.Parameters.Add("@Q3_DateTo", SqlDbType.VarChar).Value =
                Balance.Q3_DateTo;
            cmd.Parameters.Add("@Q4", SqlDbType.Int).Value = Balance.Q4;
            cmd.Parameters.Add("@Q4_DateTo", SqlDbType.VarChar).Value =
                Balance.Q4_DateTo;
            cmd.Parameters.Add("@Old_Balance", SqlDbType.Int).Value =
                Balance.Old_Balance;
            cmd
                .Parameters
                .Add("@Old_Balance_ExpirationDate", SqlDbType.VarChar)
                .Value = Balance.Old_Balance_ExpirationDate;

            cmd.ExecuteNonQuery();
        }

        con.Close();
        return JsonConvert.SerializeObject(HR_Employees_Vacation_Balance);
    }

    public class HR_Employees_Vacation_Balance
    {
        public int Emp_id { get; set; }

        public int Annual_Balance { get; set; }

        public int Casual_Balance { get; set; }

        public int Q1 { get; set; }

        public string Q1_DateTo { get; set; }

        public int Q2 { get; set; }

        public string Q2_DateTo { get; set; }

        public int Q3 { get; set; }

        public string Q3_DateTo { get; set; }

        public int Q4 { get; set; }

        public string Q4_DateTo { get; set; }

        public int Old_Balance { get; set; }

        public string Old_Balance_ExpirationDate { get; set; }
    }

    // get HR_Employees_Vacation_Balance
    [WebMethod]
    public static string getEmployees_BalanceData()
    {
        string config =
            Convert.ToString(ConfigurationManager.ConnectionStrings["dbcon"]);

        List<Employees_Balance> Employees_Balance =
            new List<Employees_Balance>();

        SqlConnection con = new SqlConnection(config);

        con.Open();

        using (
            SqlCommand cmd =
                new SqlCommand("Select * from HR_Employees_Vacation_Balance",
                    con)
        )
        {
            SqlDataReader idr = cmd.ExecuteReader();

            if (idr.HasRows)
            {
                Employees_Balance = populateEmployees_BalanceLisst(idr, con);
            }
        }

        con.Close();

        return JsonConvert.SerializeObject(Employees_Balance);
    }

    public static List<Employees_Balance>
    populateEmployees_BalanceLisst(SqlDataReader idr, SqlConnection con)
    {
        List<Employees_Balance> Employees_BalanceI =
            new List<Employees_Balance>();

        while (idr.Read())
        {
            Employees_BalanceI
                .Add(new Employees_Balance {
                    id =
                        idr["id"] != DBNull.Value
                            ? Convert.ToInt32(idr["id"])
                            : 0,
                    Emp_id =
                        idr["Emp_id"] != DBNull.Value
                            ? Convert.ToInt32(idr["Emp_id"])
                            : 0,
                    Vacation_id =
                        idr["Vacation_id"] != DBNull.Value
                            ? Convert.ToInt32(idr["Vacation_id"])
                            : 0,
                    Vacation_name =
                        idr["Vacation_name"] != DBNull.Value
                            ? Convert.ToString(idr["Vacation_name"])
                            : String.Empty,
                    Annual_Balance =
                        idr["Annual_Balance"] != DBNull.Value
                            ? Convert.ToInt32(idr["Annual_Balance"])
                            : 0,
                    Casual_Balance =
                        idr["Casual_Balance"] != DBNull.Value
                            ? Convert.ToInt32(idr["Casual_Balance"])
                            : 0,
                    Q1 =
                        idr["Q1"] != DBNull.Value
                            ? Convert.ToInt32(idr["Q1"])
                            : 0,
                    Q1_DateTo =
                        idr["Q1_DateTo"] != DBNull.Value
                            ? Convert.ToString(idr["Q1_DateTo"])
                            : String.Empty,
                    Q2 =
                        idr["Q2"] != DBNull.Value
                            ? Convert.ToInt32(idr["Q2"])
                            : 0,
                    Q2_DateTo =
                        idr["Q2_DateTo"] != DBNull.Value
                            ? Convert.ToString(idr["Q2_DateTo"])
                            : String.Empty,
                    Q3 =
                        idr["Q3"] != DBNull.Value
                            ? Convert.ToInt32(idr["Q3"])
                            : 0,
                    Q3_DateTo =
                        idr["Q3_DateTo"] != DBNull.Value
                            ? Convert.ToString(idr["Q3_DateTo"])
                            : String.Empty,
                    Q4 =
                        idr["Q4"] != DBNull.Value
                            ? Convert.ToInt32(idr["Q4"])
                            : 0,
                    Q4_DateTo =
                        idr["Q4_DateTo"] != DBNull.Value
                            ? Convert.ToString(idr["Q4_DateTo"])
                            : String.Empty,
                    Old_Balance =
                        idr["Old_Balance"] != DBNull.Value
                            ? Convert.ToInt32(idr["Old_Balance"])
                            : 0,
                    Old_Balance_ExpirationDate =
                        idr["Old_Balance_ExpirationDate"] != DBNull.Value
                            ? Convert
                                .ToString(idr["Old_Balance_ExpirationDate"])
                            : String.Empty,
                    Request_date = Convert.ToDateTime(idr["Request_date"])
                });
        }

        return Employees_BalanceI;
    }

    public class Employees_Balance
    {
        public int? id { get; set; }

        public int? Emp_id { get; set; }

        public int? Vacation_id { get; set; }

        public string Vacation_name { get; set; }

        public int? Annual_Balance { get; set; }

        public int? Casual_Balance { get; set; }

        public int? Q1 { get; set; }

        public string Q1_DateTo { get; set; }

        public int? Q2 { get; set; }

        public string Q2_DateTo { get; set; }

        public int? Q3 { get; set; }

        public string Q3_DateTo { get; set; }

        public int? Q4 { get; set; }

        public string Q4_DateTo { get; set; }

        public int? Old_Balance { get; set; }

        public string Old_Balance_ExpirationDate { get; set; }

        public DateTime Request_date { get; set; }
    }

    // update balance
    [WebMethod]
    public static string updateDetails(BalanceDetails detail)
    {
        string config =
            Convert.ToString(ConfigurationManager.ConnectionStrings["dbcon"]);

        List<BalanceDetails> BalanceDetails = new List<BalanceDetails>();

        SqlConnection con = new SqlConnection(config);

        con.Open();

        SqlCommand cmd =
            new SqlCommand("update HR_Employees_Vacation_Balance set Annual_Balance = @Annual_Balance, Casual_Balance= @Casual_Balance, Q1= @Q1, Q2= @Q2, Q3= @Q3, Q4= @Q4, Old_Balance= @Old_Balance, Old_Balance_ExpirationDate= @Old_Balance_ExpirationDate where id = @id;",
                con);

        cmd.Parameters.AddWithValue("@Annual_Balance", detail.Annual_Balance);
        cmd.Parameters.AddWithValue("@Casual_Balance", detail.Casual_Balance);
        cmd.Parameters.AddWithValue("@Q1", detail.Q1);
        cmd.Parameters.AddWithValue("@Q2", detail.Q2);
        cmd.Parameters.AddWithValue("@Q3", detail.Q3);
        cmd.Parameters.AddWithValue("@Q4", detail.Q4);
        cmd.Parameters.AddWithValue("@Old_Balance", detail.Old_Balance);
        cmd
            .Parameters
            .AddWithValue("@Old_Balance_ExpirationDate",
            detail.Old_Balance_ExpirationDate);
        cmd.Parameters.AddWithValue("@id", detail.id);

        cmd.ExecuteNonQuery();

        con.Close();

        return JsonConvert.SerializeObject(BalanceDetails);
    }

    public static List<BalanceDetails>
    populateLisst(SqlDataReader idr, SqlConnection con)
    {
        List<BalanceDetails> BalanceDetailsI = new List<BalanceDetails>();

        while (idr.Read())
        {
            BalanceDetailsI
                .Add(new BalanceDetails {
                    id = Convert.ToInt32(idr["id"]),
                    Annual_Balance = Convert.ToInt32(idr["Annual_Balance"]),
                    Casual_Balance = Convert.ToInt32(idr["Casual_Balance"]),
                    Q1 = Convert.ToInt32(idr["Q1"]),
                    Q2 = Convert.ToInt32(idr["Q2"]),
                    Q3 = Convert.ToInt32(idr["Q3"]),
                    Q4 = Convert.ToInt32(idr["Q4"]),
                    Old_Balance = Convert.ToInt32(idr["Old_Balance"]),
                    Old_Balance_ExpirationDate =
                        Convert.ToString(idr["Old_Balance_ExpirationDate"])
                });
        }
        return BalanceDetailsI;
    }

    public class BalanceDetails
    {
        public int? id { get; set; }

        public int? Annual_Balance { get; set; }

        public int? Casual_Balance { get; set; }

        public int? Q1 { get; set; }

        public int? Q2 { get; set; }

        public int? Q3 { get; set; }

        public int? Q4 { get; set; }

        public int? Old_Balance { get; set; }

        public string Old_Balance_ExpirationDate { get; set; }
    }
}
