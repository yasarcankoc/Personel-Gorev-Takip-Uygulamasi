using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birleştirme0205.Siniflar
{
    internal class Durum
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-NROULA8;Initial Catalog=TaskManagmentSon;Integrated Security=True");
        public void durumekle(string durumValue)
        {
            try
            {
                DynamicParameters guncelleme = new DynamicParameters();

                guncelleme.Add("@Durum", durumValue);

                SqlCon.Execute("DurumEkle", guncelleme, commandType: CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }
        }
        public void durumsil(string durumcıkar)
        {

            DynamicParameters sil = new DynamicParameters();
            sil.Add("@Ad", durumcıkar);
            SqlCon.Execute("DurumSil", sil, commandType: CommandType.StoredProcedure);
        }
        public List<string> DurumListele()
        {
            string query = "select Ad from tblDurumTablosu where DurumID not in (1,2,3)";
            List<string> list = SqlCon.Query<string>(query).ToList();
            return list;
        }
    }
}
