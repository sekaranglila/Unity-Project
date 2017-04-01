using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Voucher {
    public int Id { get; set; }
    public String PlaceName { get; set; }
    public String Address { get; set; }
    public String Content { get; set; }
    public String ValidDate { get; set; }
    public int Points { get; set; }
    public int Owned { get; set; }

    public Voucher(int Id, String PlaceName, String Address, String Content, String ValidDate, int Points, int Owned) {
        this.Id = Id;
        this.PlaceName = PlaceName;
        this.Address = Address;
        this.Content = Content;
        this.ValidDate = ValidDate;
        this.Points = Points;
        this.Owned = Owned;
    }
}