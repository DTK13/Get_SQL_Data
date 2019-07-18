using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace exe_Sql_Data_Extractor
{
    class Program
    {
        private string connectionString = ConfigurationManager.AppSettings["connectionString"];
        private List<string> FirstNames = new List<string>();
        private List<string> LastNames = new List<string>();

        static void Main(string[] args)
        {
            new Program().GetData();
        }

        public void GetData()
        {
            string queryString ="SELECT FirstName, LastName FROM TEST";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    FirstNames.Add(reader.GetString(0));
                    LastNames.Add(reader.GetString(1));
                }

                Display(FirstNames, LastNames);

                // Call Close when done reading.
                reader.Close();
            }
        }

        public void Display(List<string> FirstNames, List<string> LastNames)
        {
           for (int i=0; i<FirstNames.Count && i < LastNames.Count; i++)
            {
                Console.WriteLine("{0} {1} \r\n", FirstNames[i], LastNames[i]);
            }

          

            Console.ReadKey();
        }
    }
}
