using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class VoucherManager : MonoBehaviour {

    private string connectionString;
    private List<Voucher> voucherList = new List<Voucher>();
    public GameObject voucherPrefab;
    public Transform VoucherParent;
    public int totalPoints;
    public Sprite newSprite;

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/myDatabase.sqlite";
		CreateTable();
        ShowVoucher();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateTable() {
		using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
			dbConnection.Open();
			using (IDbCommand dbCommand = dbConnection.CreateCommand()) {
				string query = "CREATE TABLE IF NOT EXISTS \"voucher\" (\"id\" INTEGER PRIMARY KEY  NOT NULL ,\"id_place\" INTEGER NOT NULL ,\"content\" VARCHAR,\"valid_date\" VARCHAR DEFAULT (null) ,\"points\" INTEGER,\"owned\" INTEGER NOT NULL  DEFAULT (0) )";
				dbCommand.CommandText = query;
				dbCommand.ExecuteScalar ();
				dbConnection.Close();
			}
		}
	}

    private void GetVoucher() {
        voucherList.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand()) {
                string query = "SELECT VOUCHER.ID, NAME, ADDRESS, CONTENT, VALID_DATE, POINTS, OWNED FROM VOUCHER, PLACE WHERE PLACE.ID = VOUCHER.ID_PLACE";
                dbCommand.CommandText = query;
                using (IDataReader reader = dbCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        voucherList.Add(new Voucher(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
							reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void ShowVoucher() {
        GetVoucher();
        for (int i = 0; i < voucherList.Count; i++) {
            GameObject tempObject = Instantiate(voucherPrefab);
            Voucher tempVoucher = voucherList[i];
            tempObject.GetComponent<VoucherScript>().SetVoucher(tempVoucher.PlaceName, tempVoucher.Content + "\nValid until: " + tempVoucher.ValidDate, tempVoucher.Points.ToString() + " pts");
            tempObject.transform.SetParent(VoucherParent);
            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            if (tempVoucher.Owned == 1) {
                tempObject.GetComponentInChildren<Button>().GetComponent<Image>().sprite = newSprite;
                tempObject.GetComponentInChildren<Button>().interactable = false;
            }
            tempObject.GetComponentInChildren<Button>().onClick.AddListener(() => OnClickButton(tempVoucher, tempObject.GetComponentInChildren<Button>()));
        }
    }

    public void OnClickButton(Voucher voucher, Button button) {
        if (PlayerPrefs.HasKey("totalPoints")) {
            totalPoints = PlayerPrefs.GetInt("totalPoints");
        } else {
            totalPoints = 0;
        }
        Debug.Log("Previous Points: " + totalPoints);
        if (totalPoints >= voucher.Points) {
            totalPoints -= voucher.Points;
            button.GetComponent<Image>().sprite = newSprite;
            button.interactable = false;
            using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {
                dbConnection.Open();
                using (IDbCommand dbCommand = dbConnection.CreateCommand()) {
                    string query = "UPDATE VOUCHER SET OWNED = 1 WHERE ID = " + voucher.Id;
                    dbCommand.CommandText = query;
                    dbCommand.ExecuteScalar();
                    dbConnection.Close();
                }
            }
        }
        Debug.Log("After Points: " + totalPoints);
        PlayerPrefs.SetInt("totalPoints", totalPoints);
    }
}
