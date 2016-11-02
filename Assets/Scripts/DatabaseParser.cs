using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

class DatabaseParser : MonoBehaviour
{
    void Start()
    {
        string connString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Peck2703\\Documents\\GitHub\\Charged\\Assets\\ChargedTest.mdf; Integrated Security = True; Connect Timeout = 30";
        SqlConnection myConn = null;
        SqlDataReader rder = null;
        

        try
        {
            myConn = new SqlConnection(connString);
            myConn.Open();

            //SqlCommand cmd = new SqlCommand();

            SqlCommand myCommand = new SqlCommand("select * from dbo.Users", myConn);

            
        }
        catch(Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        /*string conn = "URI=file:" + Application.dataPath + "ChargedDB.db";              //Full path to the Database
        IDbConnection dbConn;

        dbConn = (IDbConnection) new SqliteConnection(conn);

        dbConn.Open();
        IDbCommand dbComd = dbConn.CreateCommand();

        string sQuery = "SELECT ID, Username " + "FROM UserAccounts";

        dbComd.CommandText = sQuery;

        IDataReader reader = dbComd.ExecuteReader();

        while (reader.Read())
        {
            int readID = reader.GetInt32(0);
            string readUser = reader.GetString(1);

            Debug.Log("ID: " + readID + " and UserName: " + readUser);
        }
        reader.Close();
        reader = null;

        dbComd.Dispose();
        dbComd = null;

        dbConn.Close();
        dbConn = null;
        */
    }
}
