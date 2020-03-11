using System;
using System.Data.SqlClient;
using System.Data;

namespace Broker
{
    public class Connection
    {
        public static int id_perdorues = 1;
        public string[,] vektor;
        private string[] v1;
        private string[] v2;
        public byte[] b = null;

        public Connection()
        {

        }

        #region webservice connection
        internal void vector_transform()
        {
            v1 = new string[vektor.Length / 2]; // emertimi
            v2 = new string[vektor.Length / 2]; // vlera
            for (int i = 0; i < v1.Length; i++)
            {
                v1[i] = vektor[i, 0];
                v2[i] = vektor[i, 1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureString">emri i procdures selekt</param>
        /// <param name="tabela">string tabela</param>
        /// <param name="products">argumentat qe do ti kalohen me dy kolona , ku e para eshte emertimi dhe e dyta eshte vlera</param>
        public void sp(string procedureString, string tabela, ref DataTable products)
        {
            vector_transform();
            string mesazhGabimi = "";
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnStr"].ToString();
                using (SqlConnection mySqlConnection = new SqlConnection(connectionString))//nderto dhe perdor objektin sqlconnection
                {
                    try
                    {
                        using (SqlCommand mySqlCommand = mySqlConnection.CreateCommand())//nderto dhe per mysqlcommand
                        {
                            mySqlCommand.CommandText = procedureString;
                            mySqlCommand.CommandType = CommandType.StoredProcedure;


                            // cikel per shtimin e parametrave
                            try
                            {
                                if (vektor.Length > 0)
                                {
                                    for (int i = 0; i < vektor.Length / 2; i++)
                                    {
                                        if (vektor[i, 0] != null && vektor[i, 1] != null && vektor[i, 1] != "")
                                        {
                                            mySqlCommand.Parameters.AddWithValue(vektor[i, 0], vektor[i, 1]);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                mesazhGabimi = "Nuk mund te shtohen parametrat e procedures!!! \n" + ex.Message;
                            }
                            //cikel per shtimin e parametrave
                            try
                            {
                                mySqlConnection.Open();//tento hapjen e lidhjes
                            }
                            catch (Exception ex)
                            {
                                mesazhGabimi = "Nuk mund te lidhet me bazen e te dhenave!!! \n" + ex.Message.ToString();

                            }
                            try
                            {
                                mySqlCommand.ExecuteNonQuery();//tento ekzekutimin e storeprocedure
                            }
                            catch (Exception ex)
                            {
                                mesazhGabimi = "Store Procedure ne Server nuk mund te ekzekutohet!!! \n" + ex.Message.ToString();
                            }
                            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter())//nderto dhe perdor sqldataadapter
                            {
                                mySqlDataAdapter.SelectCommand = mySqlCommand;
                                try
                                {
                                    using (DataSet myDataSet = new DataSet())//nderto dhe perdor dataset
                                    {
                                        try
                                        {
                                            mySqlDataAdapter.Fill(myDataSet, tabela);//tento te mbushesh datasetin
                                        }
                                        catch (Exception ex)
                                        {
                                            mesazhGabimi = "Te dhenat nuk mund te trasferohen!!! \n" + ex.Message.ToString();
                                        }
                                        try
                                        {
                                            products = myDataSet.Tables[tabela];
                                            mySqlConnection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            mesazhGabimi = "Probleme me trasferimin e te dhenave ose me mbylljen e seksionit!!! \n" + ex.Message.ToString();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    mesazhGabimi = "Probleme me ndertimin e DataSet!!! \n" + ex.Message.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mesazhGabimi = "Probleme me ndertimin e komandes SQL!!! \n" + ex.Message.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                mesazhGabimi = "Probleme me ndertimin e Connection String!!! \n" + ex.Message.ToString();
            }

            if (mesazhGabimi != "")
            {
                //                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                //MesazheGabimi test = new MesazheGabimi(100, mesazhGabimi);
                //test.ShowDialog();
            }
        }//END OF SP

        public void ip(string procedureString)
        {
            vector_transform();
            string mesazhGabimi_pos = "";
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnStr"].ToString();
                using (SqlConnection mySqlConnection = new SqlConnection(connectionString))//nderto dhe perdor objektin sqlconnection
                {
                    try
                    {
                        using (SqlCommand mySqlCommand = mySqlConnection.CreateCommand())//nderto dhe per mysqlcommand
                        {
                            mySqlCommand.CommandText = procedureString;
                            mySqlCommand.CommandType = CommandType.StoredProcedure;
                            if (vektor.Length > 0)
                            {
                                for (int i = 0; i < vektor.Length / 2; i++)
                                {
                                    if (vektor[i, 0] != null && vektor[i, 1] != null)
                                    {
                                        mySqlCommand.Parameters.AddWithValue(vektor[i, 0], vektor[i, 1]);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            if (b != null) //shtimi nese ka foto
                            {
                                mySqlCommand.Parameters.AddWithValue("@FOTO", b);
                            }
                            try
                            {
                                mySqlConnection.Open();//tento hapjen e lidhjes
                            }
                            catch (Exception ex)
                            {
                                mesazhGabimi_pos = "Gabim lidhja me DB: \n" + ex.Message.ToString();
                            }
                            try
                            {
                                mySqlCommand.ExecuteNonQuery();//tento ekzekutimin e storeprocedure
                            }
                            catch (Exception ex)
                            {
                                mesazhGabimi_pos = "Gabim egzekutimi : \n" + ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mesazhGabimi_pos = "Gabim me ip  \n" + ex.Message.ToString();
                    }
                }
                if (mesazhGabimi_pos != "")
                {
                    //MesazheGabimi test = new MesazheGabimi(110, mesazhGabimi_pos);
                    //test.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to process request"))
                {
                    //MesazheGabimi test = new MesazheGabimi(110, ex.Message);
                    //test.ShowDialog();
                }
                else if (ex.Message.Contains("Could not connect to"))
                {
                    //MesazheGabimi test = new MesazheGabimi(100, ex.Message);
                    //test.ShowDialog();
                }
                else
                {
                    //MesazheGabimi test = new MesazheGabimi(125, ex.Message);
                    //test.ShowDialog();
                }
            }
        }
        #endregion
    }
}