using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Connection:MonoBehaviour 
{
    private MySqlConnection _conn;
    private string _server = "127.0.0.1";
    private string _database = "peluqueria";
    private string _user = "admin";
    private string _password = "123qwe";
    private string _connectionString;

    private void Start()
    {
        _connectionString = "Database=" + _database +
            "; Server=" + _server +
            ";  Uid=" + _user +
            "; Pwd=" + _password;
    }
    1
    public MySqlConnection getConnection()
    {
       if (_conn == null)
       {
            try
            {
                _conn = new MySqlConnection(_connectionString);
                _conn.Open();
            }catch(MySqlException e) {
                Debug.Log("Error al conectar con la base de datos");
                Debug.LogException(e);
            }


       }
       return _conn;
    }
}
