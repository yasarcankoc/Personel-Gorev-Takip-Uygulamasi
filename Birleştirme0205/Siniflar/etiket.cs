using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birleştirme0205.Class
{
    internal class etiket
    {
        SqlConnection SqlCon = new SqlConnection(@"Data Source =DESKTOP-NROULA8;Initial Catalog=TaskManagmentSon;Integrated Security=True");

        public void etiketekle(string etiketValue)
        {
            try
            {
                DynamicParameters guncelleme = new DynamicParameters();

                guncelleme.Add("@etiket", etiketValue);

                SqlCon.Execute("EtiketEkle", guncelleme, commandType: CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }


        }
        public List<string> EtiketListeleme()
        {
            string query = "select EtiketAd from tblEtiket";
            List<string> etiketList = SqlCon.Query<string>(query).ToList();
            return etiketList;
        }
        public void etiketcıkar(string cıkar)
        {

            DynamicParameters sil = new DynamicParameters();
            sil.Add("@Ad", cıkar);
            SqlCon.Execute("EtiketSilme", sil, commandType: CommandType.StoredProcedure);
        }
    }
}
