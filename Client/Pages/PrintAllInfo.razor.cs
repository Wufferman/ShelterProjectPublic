using System;
using System.Collections.Generic;
using SharedProject.cs;

namespace Client.Pages
{
    public partial class PrintAllInfo
    {
        List<Kommune> kommuneList = new List<Kommune>();
        List<Accounttypes> accounttypeList = new List<Accounttypes>();
        List<Users> userList = new List<Users>();
        List<Shelter> shelterList = new List<Shelter>();
        List<Shelterbooking> bookingList = new List<Shelterbooking>();

        public PrintAllInfo()
        {
            
            kommuneList.Add(new Kommune(1, "Sej Kommune"));


            
            accounttypeList.Add(new Accounttypes(1, "sej"));
            accounttypeList.Add(new Accounttypes(2, "Admin"));



            userList.Add(new Users(1, "Ralle", "Rasmus@gmail", "Rasmus", 50, 10));
            userList[0].accounttype = new Accounttypes(1, "sej");
            userList.Add(new Users(2, "Jelle", "Jeffmail@gmail", "Jeff", 20485085, 45));
            userList[1].accounttype = new Accounttypes(2, "Admin");
        }

    }
}
