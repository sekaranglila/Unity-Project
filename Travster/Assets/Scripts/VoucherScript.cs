using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoucherScript : MonoBehaviour {

    public GameObject VoucherTitle;
    public GameObject VoucherDetails;
    public GameObject VoucherPoints;

    public void SetVoucher(string title, string details, string points) {
        this.VoucherTitle.GetComponent<Text>().text = title;
        this.VoucherDetails.GetComponent<Text>().text = details;
        this.VoucherPoints.GetComponent<Text>().text = points;
    }
}
