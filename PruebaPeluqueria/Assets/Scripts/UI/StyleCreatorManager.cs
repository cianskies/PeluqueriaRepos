using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StyleCreatorManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _idText;
    [SerializeField] private TMP_InputField _nameText;
    [SerializeField] private TMP_Dropdown _styleTypeDrp;
    [SerializeField] private TMP_InputField _iconText;
    [SerializeField] private TMP_InputField _colorText;
    [SerializeField] private TMP_InputField _infoText;

    [SerializeField]private Connection _conn;
    private MySqlConnection _mySqlConnection;

    private void Start()
    {
        _mySqlConnection=_conn.getConnection();   
    }

    public void OnClickCreateNewStyle()
    {
        if(_idText == null
            || _nameText==null
            //&&_styleTypeDrp!=null
            || _iconText==null
            || _colorText==null
            || _infoText == null)
        {
            Debug.Log("Show error msj");
        }
        else
        {
            CreateStyle();
        }
    }
    private void CreateStyle()
    {
        string query = $"INSERT INTO STYLE VALUES({_idText.ToString()},{_nameText.ToString()}," +
            $"{_styleTypeDrp.ToString()}, {_iconText.ToString()}, {_styleTypeDrp.value.ToString()}, " +
            $"{_iconText.ToString()}, {_colorText.ToString()}, {_infoText.ToString()} )";


        MySqlCommand cmd = new MySqlCommand(query, _mySqlConnection);
        int inserted=cmd.ExecuteNonQuery();
        if ((inserted>-1))
        {
            Debug.Log("New style has been inserted");
        }
        else
        {
            Debug.Log("Looks like something has been messed up lol");
        }
    }
    private void OnDisable()
    {
        _conn.getConnection().Close();
    }
}
