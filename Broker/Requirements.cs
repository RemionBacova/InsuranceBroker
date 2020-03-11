using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Broker
{
    public static class Req
    {
        public static Requirenments a = new Requirenments();
        static Req()
        {

        }
    }
    public class Requirenments
    {
        static Connection z = new Connection();
        DataTable b = new DataTable();
        // get

        public DataTable SelectAllActiveRec(string tabela)
        {
            if (b != null) b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "tabela";
            z.vektor[0, 1] = tabela;
            z.sp("SelectAllActiveRec", "tabela", ref b);
            return b;
        }

        public void spI_tbl_logs(string machine, string ip, string ekzekutimi , string ku)
        {
            if (b != null) b.Clear();
            z.vektor = new string[5, 2];
            z.vektor[0, 0] = "nrrendor";
            z.vektor[0, 1] = Guid.NewGuid().ToString();
            z.vektor[1, 0] = "machine";
            z.vektor[1, 1] = machine;
            z.vektor[2, 0] = "ip";
            z.vektor[2, 1] = ip;
            z.vektor[3, 0] = "ekzekutimi";
            z.vektor[3, 1] = ekzekutimi;
            z.vektor[4, 0] = "ku";
            z.vektor[4, 1] = ku;
            z.ip("spI_tbl_logs");

        }
    }
}