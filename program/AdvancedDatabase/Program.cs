using System;
using System.Text;
using System.Data.SqlClient;
namespace AdvancedDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source=DESKTOP-ADGLMB7;" +
              "Initial Catalog=myDatabase;" +
              "Integrated Security=true;";
            conn.Open();

            // INSERT into Role
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Role (RoleName) ");
            sb.Append("VALUES (@name);");
            string sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "Teacher");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // INSERT into Role
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Role (RoleName) ");
            sb.Append("VALUES (@name);");
            sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "Student");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // INSERT into Role
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Role (RoleName) ");
            sb.Append("VALUES (@name);");
            sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "HR");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // INSERT into User
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Userr (Name, Family, Age, RoleID) ");
            sb.Append("VALUES (@name, @family, @age, @roleid);");
            sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "Ahmad");
                command.Parameters.AddWithValue("@family", "Rohani");
                command.Parameters.AddWithValue("@age", "45");
                command.Parameters.AddWithValue("@roleid", "1");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // INSERT into User
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Userr (Name, Family, RoleID) ");
            sb.Append("VALUES (@name, @family, @roleid);");
            sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "Saba");
                command.Parameters.AddWithValue("@family", "Emami");
                command.Parameters.AddWithValue("@roleid", "2");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // INSERT into User
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            sb = new StringBuilder();
            sb.Clear();
            sb.Append("INSERT Userr (Name, Family, Age, RoleID) ");
            sb.Append("VALUES (@name, @family, @age, @roleid);");
            sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@name", "Morteza");
                command.Parameters.AddWithValue("@family", "Abdi");
                command.Parameters.AddWithValue("@age", "35");
                command.Parameters.AddWithValue("@roleid", "3");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " row(s) inserted");
            }

            // JOIN
            Console.WriteLine("Reading data from table, press any key to continue...");
            Console.ReadKey(true);
            sql = "SELECT Userr.Name, Userr.Family, Role.RoleName FROM Userr INNER JOIN Role ON Userr.RoleID = Role.ID;";
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }
        }
    }
}
