using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace t2s_video
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = "Data Source=DESKTOP-DJ8IC52\\SQLEXPRESS;Initial Catalog=dbvideo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection.Open();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "" || txtConteinerNum.Text == "")
            {
                labelAdd.Text = "Por favor preencha todas as colunas.";
                labelAdd.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (Regex.IsMatch(txtConteinerNum.Text, @"^[a-zA-Z]{4}[0-9]{7}$"))
                {

                    dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                    cmd.CommandText = "SELECT 1 FROM tabelaConteiner WHERE Numero = '" + txtConteinerNum.Text.ToString() + "' ";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    SqlDataReader myreader;
                    myreader = cmd.ExecuteReader();

                    if (myreader.Read().ToString() == "False") //if not exists
                    {
                        myreader.Close();
                        dt = new DataTable();
                        cmd.CommandText = "Insert into tabelaConteiner (Nome,Numero,Tipo,Status,Categoria)values('" + txtCliente.Text.ToString() + "','" + txtConteinerNum.Text.ToString() + "','" + listTipo.Text.ToString() + "', '" + listStatus.Text.ToString() + "','" + listCategoria.Text.ToString() + "')";
                        cmd.Connection = connection;
                        cmd.ExecuteNonQuery();
                        labelAdd.Text = "Contêiner adicionado com sucesso.";
                        labelAdd.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelAdd.Text = "Numeração já consta no sistema.";
                        labelAdd.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    labelAdd.Text = "Numeração do contêiner deve conter 4 letras e 7 numeros. Ex:ABCD1234567";
                    labelAdd.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public void DataShow()
        {
            ds = new DataSet();
            //cmd.CommandText = "Select * From tabelaCliente ORDER BY Cliente";
            cmd.CommandText = "Select tabelaConteiner.Nome,tabelaConteiner.Numero,tabelaConteiner.Status,tabelaMovimentacao.Tipo,tabelaMovimentacao.Inicio,tabelaMovimentacao.Fim From tabelaConteiner FULL JOIN tabelaMovimentacao ON tabelaConteiner.Numero=tabelaMovimentacao.Numero ORDER BY Nome,Tipo";
            cmd.Connection = connection;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView1.DataSource = ds;
            GridView1.DataBind();

            ds = new DataSet();
            cmd.CommandText = "Select Categoria, count(*) as Total FROM tabelaConteiner GROUP BY Categoria"; //Segunda tabela
            cmd.Connection = connection;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridView2.DataSource = ds;
            GridView2.DataBind();

            connection.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "" || txtConteinerNum.Text == "")
            {
                labelAdd.Text = "Por favor preencha todas as colunas.";
                labelAdd.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                cmd.CommandText = "SELECT 1 FROM tabelaConteiner WHERE Numero = '" + txtConteinerNum.Text.ToString() + "' ";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();

                if (myreader.Read().ToString() == "True") //if exists
                {
                    myreader.Close();
                    dt = new DataTable();
                    cmd.CommandText = "Update tabelaConteiner set Nome='" + txtCliente.Text.ToString() + "',Numero='" + txtConteinerNum.Text.ToString() + "',Tipo='" + listTipo.Text.ToString() + "',Status='" + listStatus.Text.ToString() + "',Categoria='" + listCategoria.Text.ToString() + "' Where Numero='" + txtConteinerNum.Text.ToString() + "'";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    labelAdd.Text = "Contêiner atualizado com sucesso.";
                    labelAdd.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelAdd.Text = "Numeração não encontrada no sistema.";
                    labelAdd.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtConteinerNum.Text == "")
            {
                labelAdd.Text = "Por favor digite a numeração do contêiner.";
                labelAdd.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                cmd.CommandText = "SELECT 1 FROM tabelaConteiner WHERE Numero = '" + txtConteinerNum.Text.ToString() + "' ";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();

                if (myreader.Read().ToString() == "True") //if exists
                {
                    myreader.Close();
                    dt = new DataTable();
                    cmd.CommandText = "Delete from tabelaConteiner where Numero='" + txtConteinerNum.Text.ToString() + "'";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    labelAdd.Text = "Contêiner deletado com sucesso.";
                    labelAdd.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelAdd.Text = "Numeração não encontrada no sistema.";
                    labelAdd.ForeColor = System.Drawing.Color.Red;
                }
            
        }
    }

        protected void btnRegistrarMovimentacao_Click(object sender, EventArgs e)
        {
            if (txtConteinerMov.Text == "")
            {
                labelMovimentacao.Text = "Por favor digite a numeração do contêiner.";
                labelMovimentacao.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                cmd.CommandText = "SELECT 1 FROM tabelaConteiner WHERE Numero = '" + txtConteinerMov.Text.ToString() + "' ";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();

                if (myreader.Read().ToString() == "True") //if exists
                {
                    myreader.Close();
                   

                    dt = new DataTable();
                    cmd.CommandText = "Insert into tabelaMovimentacao (Inicio,Fim,Numero,Tipo)values('" + txtinicio.Text.ToString() + "','" + txtFim.Text.ToString() + "','" + txtConteinerMov.Text.ToString() + "','" + listMovimentacao.Text.ToString() + "')";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    labelMovimentacao.Text = "Movimentação registrada no sistema com sucesso.";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelMovimentacao.Text = "Numeração não encontrada no sistema.";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        protected void btnUpdateMovimentacao_Click(object sender, EventArgs e)
        {
            if (txtConteinerMov.Text == "" || txtinicio.Text == "" || txtFim.Text == "")
            {
                labelMovimentacao.Text = "Por favor preencha todos os campos.";
                labelMovimentacao.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                cmd.CommandText = "SELECT 1 FROM tabelaMovimentacao WHERE Numero = '" + txtConteinerMov.Text.ToString() + "' AND Inicio='" + txtinicio.Text.ToString() + "' AND Fim='" + txtFim.Text.ToString() + "'";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();

                if (myreader.Read().ToString() == "True") //if exists
                {
                    myreader.Close();

                    dt = new DataTable();
                    cmd.CommandText = "Update tabelaMovimentacao set Inicio='" + txtinicio.Text.ToString() + "',Fim='" + txtFim.Text.ToString() + "',Tipo='" + listMovimentacao.Text.ToString() + "' Where Numero='" + txtConteinerMov.Text.ToString() + "' AND Inicio='" + txtinicio.Text.ToString() + "' AND Fim='" + txtFim.Text.ToString() + "'";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    labelMovimentacao.Text = "Movimentação atualizada com sucesso!";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelMovimentacao.Text = "Movimentação não encontrado no sistema.";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnDeleteMovimentacao_Click(object sender, EventArgs e)
        {

            if (txtConteinerMov.Text == "" || txtinicio.Text == "" || txtFim.Text == "")
            {
                labelMovimentacao.Text = "Por favor preencha todos os campos.";
                labelMovimentacao.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                dt = new DataTable(); //Codigo pra verificar se o conteiner existe no sistema
                cmd.CommandText = "SELECT 1 FROM tabelaMovimentacao WHERE Numero = '" + txtConteinerMov.Text.ToString() + "' AND Inicio= '" + txtinicio.Text.ToString() + "' AND Fim= '" + txtFim.Text.ToString() + "'";
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                SqlDataReader myreader;
                myreader = cmd.ExecuteReader();

                if (myreader.Read().ToString() == "True") //if exists
                {
                    myreader.Close();

                    dt = new DataTable();
                    cmd.CommandText = "Delete from tabelaMovimentacao Where Numero='" + txtConteinerMov.Text.ToString() + "' AND Inicio= '" + txtinicio.Text.ToString() + "' AND Fim= '" + txtFim.Text.ToString() + "'";
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    labelMovimentacao.Text = "Movimentação removida com sucesso.";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelMovimentacao.Text = "Movimentação não encontrado no sistema.";
                    labelMovimentacao.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            DataShow();
        }
    }
}