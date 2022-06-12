using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BitirmeProjesi
{
    internal class AramaIslemleri
    {
        SqlConnection baglanti = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Gutuphane;Trusted_Connection=true;Timeout=2;");

        public void KitapAra(string KitapAdi, ListBox LbKitapAdi, ListBox LbYazarAdi)
        {
            SqlCommand cmd = new SqlCommand("select * from Kitaplar where KitapAdi = @ka", baglanti);
            cmd.Parameters.AddWithValue("@ka", KitapAdi);
            ListBox lbKitapAdi = new ListBox();
            ListBox lbYazarAdi = new ListBox();


            try
            {
                baglanti.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lbKitapAdi.Items.Add(reader.GetString(2));
                    lbYazarAdi.Items.Add(reader.GetString(1));

                }

                cmd.Dispose();
                reader.Close();
                baglanti.Close();
                
            }
            catch (Exception ex)

            {
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show(ex.Message);
               
            }
            for (int i = 0; i < lbKitapAdi.Items.Count;i++)
            {
                LbKitapAdi.Items.Add(lbKitapAdi.Items[i].ToString());
            }
            for (int i = 0; i < lbYazarAdi.Items.Count; i++)
            {
                LbYazarAdi.Items.Add(lbYazarAdi.Items[i].ToString());
            }
        }
    }
}
