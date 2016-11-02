using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.SqliteClient;
using UnityEngine;
using System.Data;

class DatabaseParser : MonoBehaviour
{
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "ChargedDB.db";              //Full path to the Database
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
    }
}
