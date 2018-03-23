using MesbahComponent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClinicMesbah
{
    public class DataAccess
    {
        private XmlDocument doc;
        ConnectionState con = new ConnectionState();
     
        private string PATH = Application.StartupPath + @"\setting.xml";
        public string valu="";
        public int current = 0;
        Color  color = Properties.Settings.Default.Color;
        public string GetConnectionString()
        {
            current = 0;
            string connectionString="";
            if (System.IO.File.Exists(PATH))
            {
                doc = new XmlDocument();
                doc.Load(PATH);

                XmlElement root = doc.DocumentElement;

                XmlElement server = doc.CreateElement("server");

                XmlElement currentPosition;
                //Get root element
                server = doc.DocumentElement;

                //Determine maximum possible index
                int max = server.GetElementsByTagName("server").Count - 1;


                //Get the record at the current index
                currentPosition = (XmlElement)root.ChildNodes[max];
                if (currentPosition != null)
                {

                    connectionString = "Data Source=" + currentPosition.ChildNodes[0].InnerText + ";Initial Catalog=" + currentPosition.GetElementsByTagName("db_name")[0].InnerText + ";Persist Security Info=True;User ID=" + currentPosition.ChildNodes[2].InnerText +";Password=" + currentPosition.ChildNodes[3].InnerText ;

                }
                else
                {
                    
                    return "-1";
                }

              

            }
            else
            {
                
                return "-10";
            }
            return connectionString;
        }
       
         //  string connectionString = "Data Source=SHAREPOINT;Initial Catalog=Clinic;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public DataSet ExecuteCommand(string storedProcedure)
        {  DataSet ds = new DataSet();
         if (GetConnectionString() != "-10")
                {
                  
          using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                
                SqlDataAdapter adapter;
                 SqlCommand command = new SqlCommand();
              
                  con.Open();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedure;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
               
                return ds;

                con.Close();

            }
                } return ds;
        }
        public DataSet ExecuteCommand(string storedProcedure, short sectionID)
        {  DataSet ds = new DataSet();

        if (GetConnectionString() != "-10")
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlConnection connection;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();


                con.Open();
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.AddWithValue("@SectionID", sectionID);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                return ds;

                con.Close();

            }
        } return ds;
        }
       
        public DataSet ExecuteCommand(string storedProcedure, short sectionID,byte witchDay)
        { 
            DataSet ds = new DataSet();

        if (GetConnectionString() != "-10")
        {
            
          //  DataSet ds = new DataSet();
            if (GetConnectionString() != "-10")
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlConnection connection;
                    SqlDataAdapter adapter;
                    SqlCommand command = new SqlCommand();


                    con.Open();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedure;
                    command.Parameters.AddWithValue("@SectionID", sectionID);
                    command.Parameters.AddWithValue("@Day", witchDay);

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);

                    return ds;

                    con.Close();

                }
            }} return ds;
        }
        public int GetColumnCount(string storedProcedure)
        {
            int result = -10;
            if (GetConnectionString() != "-10")
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlConnection connection;
                    SqlDataAdapter adapter;
                    SqlCommand command = new SqlCommand();
                    DataSet ds = new DataSet();
                    con.Open();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedure;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);

                    result = Convert.ToInt32(ds.Tables[0].Rows[0]["ColumnCount"]);
                    return result;
                    con.Close();

                }
            } return result;
        }
        public bool GetIsTodayORTodatTomarow(string storedProcedure)
        {
            bool result=false ;
            if (GetConnectionString() != "-10")
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlConnection connection;
                    SqlDataAdapter adapter;
                    SqlCommand command = new SqlCommand();
                    DataSet ds = new DataSet();
                    con.Open();
                    command.Connection = con;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedure;
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);

                    return result= Convert.ToBoolean(ds.Tables[0].Rows[0]["OnlyToday"]);

                    con.Close();

                }
            } return result;
        }
        public int GetColumnCount(string storedProcedure,int departementID)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlConnection connection;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                DataSet ds = new DataSet();

                con.Open();
                command.Parameters.AddWithValue("@IDs", departementID); ;
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);


                return Convert.ToInt32(ds.Tables[0].Rows[0]["departementID"]);

                con.Close();

            }
        }
        internal int SetSettings(DateTime AutoSmsTime, string Email, string Mobile, DateTime EndDelivercheck,bool TodayOnly)
        {
            int result;


            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetSettings";
                cmd.Parameters.AddWithValue("@AutoSmsTime", AutoSmsTime);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@EndDelivercheck", EndDelivercheck);
                cmd.Parameters.AddWithValue("@OnlyToday", TodayOnly);

                try
                {
                    con.Open();
                    result = Convert.ToInt16(cmd.ExecuteNonQuery());
                    con.Close();
                }
                catch (Exception Exception)
                {
                    result = -2;
                }
            }
            return result;
        }
   

        public int Insert(string procedure, string pm)
        {
            int result;


            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

               cmd.Parameters.AddWithValue("@IDs", pm);
              //  cmd.Parameters.AddWithValue("@SmsBody", "salaam");
                try
                {
                    con.Open();
                    result = Convert.ToInt16(cmd.ExecuteNonQuery());
                    con.Close();
                }
                catch (Exception Exception)
                {
                    result = -2;
                }
            }
            return result;
        }


        public int UpdateIntermittence(string procedure, int ID, bool status)
        {
            int result;
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Status", status);
                try
                {
                    con.Open();
                    result = Convert.ToInt16(cmd.ExecuteNonQuery());
                    con.Close();
                }
                catch (Exception Exception)
                {
                    result = -2;
                }
            }
            return result;
        }

        public int InsertPatient(string procedure,string nationalityCode, string fnam,string lname,string fatherName,string adress, string isuranceID,string tel, string mobile)
        {
            int result;


            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.AddWithValue("@CustomerID",nationalityCode );
                cmd.Parameters.AddWithValue("@Fname",fnam );
                cmd.Parameters.AddWithValue("@Lname", lname);
                cmd.Parameters.AddWithValue("@FatherName",fatherName );
                cmd.Parameters.AddWithValue("@Adress",adress );
                cmd.Parameters.AddWithValue("@IsuranceID", isuranceID);
                cmd.Parameters.AddWithValue("@Telphone",tel );
                cmd.Parameters.AddWithValue("@Mobile",mobile );
                
                    try
                {
                    con.Open();
                    result = Convert.ToInt16(cmd.ExecuteNonQuery());
                    con.Close();
                }
                catch (Exception Exception)
                {
                    result = -2;
                }
            }
            return result;
        }

        public int UpdateIntermittenceExchange(string indexSortNew, string indexSortOld, string procedure)
        {
            int result;


            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandTimeout = 120;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedure;

                cmd.Parameters.AddWithValue("@IndexSortNew", indexSortNew);
                cmd.Parameters.AddWithValue("@IndexSortOld", indexSortOld);
                try
                {
                    con.Open();
                    result = Convert.ToInt16(cmd.ExecuteNonQuery());
                    con.Close();
                }
                catch (Exception Exception)
                {
                    result = -2;
                }
            }
            return result;
        }


        public DataSet GetpationtInfo(string storedProcedure, string nationalCode)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlConnection connection;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                DataSet ds = new DataSet();

                con.Open();
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                command.Parameters.AddWithValue("@nationalCode", nationalCode);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                return ds;

                con.Close();

            }
        }

        internal int SetDep(Department dpt)
        {
            return 1;
        }
        private SqlCommand GenerateCommand(string CommandText, CommandType Type)
        {


            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //   sqlCmd.Connection = new SqlConnection("Data Source=SHAREPOINT;Initial Catalog=PASMAND;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                // sqlCmd.Connection = new SqlConnection("Data Source=SD8R2-0021;Initial Catalog=PASMAND;User ID=sa;Password=pasmand110");
                //  sqlCmd.Connection = new SqlConnection("Data Source=PC18\\MSSQLSERVER8;Initial Catalog=PASMAND;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
              //  sqlCmd.Connection = new SqlConnection("Data Source=SHAREPOINT;Initial Catalog=PASMAND;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                sqlCmd.Connection = new SqlConnection(GetConnectionString());
                //sqlCmd.Connection = new SqlConnection("Data Source=192.168.200.48;Initial Catalog=PASMAND;User ID=sa;Password=1000");
                sqlCmd.CommandType = Type;
                sqlCmd.CommandText = CommandText;
            }
            catch (Exception ex)
            {

            }
            return sqlCmd;
        }
        public object ExecuteScalarSP(string commandText, SqlParameter[] parameters)
        {
            object result = null;
            try
            {
                SqlCommand Command = GenerateCommand(commandText, CommandType.StoredProcedure);
                this.AddParameter(parameters, Command);

                if (Command.Connection.State != ConnectionState.Open)
                    Command.Connection.Open();

                result = Command.ExecuteScalar();
                //if (result == DBNull.Value)
                //    result = -1;
            }

            catch (Exception ex)
            {
                result = -2;
            }
            return result;
        }

        private void AddParameter(SqlParameter[] parameters, SqlCommand sqlCmd)
        {
            try
            {
                sqlCmd.Parameters.Clear();
                if (parameters != null)
                    for (int index = 0; index < parameters.Length; index++)
                    {
                        if (parameters[index] != null)
                            sqlCmd.Parameters.Add(parameters[index]);
                    }
            }
            catch (Exception ex)
            {
                // this.SetError(ex);
            }
        }
        public DataSet ExecuteSP(string commandText, SqlParameter[] parameters)
        {
       
            DataSet ds = null;
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlCommand Command = GenerateCommand(commandText, CommandType.StoredProcedure);
            sqlAdapter.SelectCommand = Command;
            DataSet dataSet = new DataSet();
            try
            {
                this.AddParameter(parameters, Command);
                dataSet = new DataSet();
                //foreach (DataTable dt in this.dataSet.Tables)
                //    CloseTable(dt.TableName);
                //this.dataSet.Clear();

                sqlAdapter.Fill(dataSet);
                ds = dataSet;
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}