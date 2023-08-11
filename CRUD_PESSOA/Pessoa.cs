using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Aula_04_agosto
{
    class Pessoa
    {
        public int Id { get; set; }
        
        public string nome { get; set; }

        public string celular { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\PROGRAMAÇÃO\BANCO DE DADOS\Aula_04_agosto\DbPessoa.mdf"";Integrated Security=True");

        public List<Pessoa> listapessoa()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM Pessoa";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa pes = new Pessoa();
                pes.Id = (int)dr["Id"];
                pes.nome = dr["nome"].ToString();
                pes.celular = dr["celular"].ToString();
                li.Add(pes);    
            }
            return li;  
        }

        public void Inserir(string nome, string celular)
        {
            string sql = "INSERT INTO Pessoa(nome, celular) VALUES ('"+nome+"', '"+celular+"')";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Localiza(int Id)
        {
            string sql = "SELECT * FROM Pessoa  WHERE Id = '" + Id + "'";
            if (con.State == ConnectionState.Open )
            {
                con.Close ();   
            }
            con.Open(); 
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString() ;
                celular = dr["celular"].ToString();
            }
            con.Close();

        }

        public void Atualizar(int Id, string nome, string celular)
        {
            string sql = "UPDATE Pessoa SET nome ='" + nome + "', celular = '" + celular + "' WHERE Id = '" + Id + "'";
            if(con.State == ConnectionState.Open)
            {
                con.Close();    
            }
            con.Open();
            SqlCommand cmd = new SqlCommand (sql, con);
            cmd.ExecuteNonQuery (); 
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Pessoa WHERE Id='"+Id+"'";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool RegistroRepetido(string nome, string celular)
        {
            string sql = "SELECT * FROM Pessoa WHERE nome='" + nome + "' AND celular='" + celular + "'";
            if (con.State == ConnectionState.Open)
            {
                con.Close ();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;
        }   

    }

}
