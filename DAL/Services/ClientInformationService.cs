using DAL.Helpers;
using DAL.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DAL.GlobalCode;
using System.Data;

namespace DAL.Services
{
   public class ClientInformationService
    {
        public Guid AddClientInformation(ClientInformation ClientInformation)
        {

            Guid ClientInformationID = new Guid("00000000-0000-0000-0000-000000000000");
            SqlConnection con = new SqlConnection(GlobalSettings.connection);
            con.Open();
            SqlCommand Cmd = new SqlCommand("sp_AddClientInformation", con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Title", ClientInformation.Title);
            Cmd.Parameters.AddWithValue("@Name", ClientInformation.Name);
            Cmd.Parameters.AddWithValue("@MiddleName", ClientInformation.MiddleName);
            Cmd.Parameters.AddWithValue("@Surname", ClientInformation.Surname);
            Cmd.Parameters.AddWithValue("@Gender", ClientInformation.Gender);
            Cmd.Parameters.AddWithValue("@DateOfBirth", DataTypesConvertor.ConvertToDateTime(ClientInformation.DateOfBirth));
            Cmd.Parameters.AddWithValue("@IDNumber", ClientInformation.IDNumber);
            Cmd.Parameters.AddWithValue("@Cell", ClientInformation.Cell);
            Cmd.Parameters.AddWithValue("@TelHome", ClientInformation.TelHome);
            Cmd.Parameters.AddWithValue("@TelWork", ClientInformation.TelWork);
            Cmd.Parameters.AddWithValue("@Email", ClientInformation.Email);
            Cmd.Parameters.AddWithValue("@StreetNameAndNumber", ClientInformation.StreetNameAndNumber);
            Cmd.Parameters.AddWithValue("@Suburb", ClientInformation.Suburb);
            Cmd.Parameters.AddWithValue("@City", ClientInformation.City);
            Cmd.Parameters.AddWithValue("@PostalCode", ClientInformation.PostalCode);
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                ClientInformationID = DataTypesConvertor.ConvertToGuid(dr["ClientInformationID"].ToString());

            }
            dr.Close();
            con.Close();
            return ClientInformationID;
        }


        public void UpdateClientInformation(ClientInformation ClientInformation)
        {
            SqlConnection con = new SqlConnection(GlobalSettings.connection);
            con.Open();
            SqlCommand Cmd = new SqlCommand("sp_UpdateClientInformation", con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ClientInformationID", ClientInformation.ClientInformationID);
            Cmd.Parameters.AddWithValue("@Title", ClientInformation.Title);
            Cmd.Parameters.AddWithValue("@Name", ClientInformation.Name);
            Cmd.Parameters.AddWithValue("@MiddleName", ClientInformation.MiddleName);
            Cmd.Parameters.AddWithValue("@Surname", ClientInformation.Surname);
            Cmd.Parameters.AddWithValue("@Gender", ClientInformation.Gender);
            Cmd.Parameters.AddWithValue("@DateOfBirth", ClientInformation.DateOfBirth);
            Cmd.Parameters.AddWithValue("@IDNumber", ClientInformation.IDNumber);
            Cmd.Parameters.AddWithValue("@Cell", ClientInformation.Cell);
            Cmd.Parameters.AddWithValue("@TelHome", ClientInformation.TelHome);
            Cmd.Parameters.AddWithValue("@TelWork", ClientInformation.TelWork);
            Cmd.Parameters.AddWithValue("@Email", ClientInformation.Email);
            Cmd.Parameters.AddWithValue("@StreetNameAndNumber", ClientInformation.StreetNameAndNumber);
            Cmd.Parameters.AddWithValue("@Suburb", ClientInformation.Suburb);
            Cmd.Parameters.AddWithValue("@City", ClientInformation.City);
            Cmd.Parameters.AddWithValue("@PostalCode", ClientInformation.PostalCode);
            Cmd.ExecuteNonQuery();
        }

        public List<ClientInformation> GetAllClientInformation()
        {
            List<ClientInformation> ClientInformationDataList = new List<ClientInformation>();

            SqlConnection con = new SqlConnection(GlobalSettings.connection);
            con.Open();
            SqlCommand Cmd = new SqlCommand("sp_GetAllClientInformation", con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                ClientInformation ClientInformation = new ClientInformation();
                ClientInformation.ClientInformationID = DataTypesConvertor.ConvertToGuid(dr["ClientInformationID"].ToString());
                ClientInformation.Title = dr["Title"].ToString();
                ClientInformation.Name = dr["Name"].ToString();
                ClientInformation.MiddleName = dr["MiddleName"].ToString();
                ClientInformation.Surname = dr["Surname"].ToString();
                ClientInformation.Gender = dr["Gender"].ToString();
                ClientInformation.DateOfBirth = DataTypesConvertor.ConvertToDateTime(dr["DateOfBirth"].ToString());
                ClientInformation.IDNumber = dr["IDNumber"].ToString();
                ClientInformation.Cell = dr["Cell"].ToString();
                ClientInformation.TelHome = dr["TelHome"].ToString();
                ClientInformation.TelWork = dr["TelWork"].ToString();
                ClientInformation.Email = dr["Email"].ToString();
                ClientInformation.StreetNameAndNumber = dr["StreetNameAndNumber"].ToString();
                ClientInformation.Suburb = dr["Suburb"].ToString();
                ClientInformation.City = dr["City"].ToString();
                ClientInformation.PostalCode = dr["PostalCode"].ToString();

                ClientInformationDataList.Add(ClientInformation);
            }
            dr.Close();
            con.Close();


            return ClientInformationDataList;
        }

        public ClientInformation GetClientInformation(Guid ClientInformationID)
        {
            ClientInformation ClientInformation = new ClientInformation();

            SqlConnection con = new SqlConnection(GlobalSettings.connection);
            con.Open();
            SqlCommand Cmd = new SqlCommand("sp_GetClientInformation", con);
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ClientInformationID", ClientInformationID);
            SqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
             
                ClientInformation.ClientInformationID = DataTypesConvertor.ConvertToGuid(dr["ClientInformationID"].ToString());
                ClientInformation.Title = dr["Title"].ToString();
                ClientInformation.Name = dr["Name"].ToString();
                ClientInformation.MiddleName = dr["MiddleName"].ToString();
                ClientInformation.Surname = dr["Surname"].ToString();
                ClientInformation.Gender = dr["Gender"].ToString();
                ClientInformation.DateOfBirth = DataTypesConvertor.ConvertToDateTime(dr["DateOfBirth"].ToString());
                ClientInformation.IDNumber = dr["IDNumber"].ToString();
                ClientInformation.Cell = dr["Cell"].ToString();
                ClientInformation.TelHome = dr["TelHome"].ToString();
                ClientInformation.TelWork = dr["TelWork"].ToString();
                ClientInformation.Email = dr["Email"].ToString();
                ClientInformation.StreetNameAndNumber = dr["StreetNameAndNumber"].ToString();
                ClientInformation.Suburb = dr["Suburb"].ToString();
                ClientInformation.City = dr["City"].ToString();
                ClientInformation.PostalCode = dr["PostalCode"].ToString();
            }
            dr.Close();
            con.Close();


            return ClientInformation;
        }

        public string ExportCSV()
        {
            string csv = string.Empty;
            using (SqlConnection con = new SqlConnection(GlobalSettings.connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [Title],[Name],[MiddleName],[Surname],[Gender],convert(varchar, [DateOfBirth], 106),[IDNumber],[StreetNameAndNumber],[Suburb],[City],[PostalCode] FROM [ClientInformation]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataColumn column in dt.Columns)
                            {
                                csv += column.ColumnName + ',';
                            }
                            csv += "\r\n";
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                                }
                                csv += "\r\n";
                            }

                        }

                        }
                    }
            }

           return csv;
        }
    }
}
