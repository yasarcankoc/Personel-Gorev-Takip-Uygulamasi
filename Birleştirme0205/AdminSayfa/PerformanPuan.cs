using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Birleştirme0205.AdminSayfa
{
    internal class PerformanPuan
    {
        public class PerformansPuan
        {
            public int GorevID { get; set; } 
            public string AdıSoyadı { get; set; }
            public DateTime BaslamaTarihi { get; set; }
            public DateTime BitişTarih { get; set; }
            public DateTime BitirmeTarihi { get; set; }
            public string GorevAdı { get; set; }
            public string Durum { get; set; }
            public int Puan { get; set; }
        }

        public List<PerformansPuan> Listele()
        {
            SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-NROULA8;Initial Catalog=TaskManagmentSon;Integrated Security=True");

            List<PerformansPuan> list = SqlCon.Query<PerformansPuan>("GorevPerformansListeleme", commandType: CommandType.StoredProcedure).ToList<PerformansPuan>();
            return list;
        }
    }
}
