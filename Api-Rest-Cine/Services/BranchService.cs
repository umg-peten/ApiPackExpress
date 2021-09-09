using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class BranchService : IBranchService
    {
        private readonly IConnection _connection;
        private Branch branch;
        public BranchService(IConnection connection)
        {
            this._connection = connection;
        }

        public Branch getBranchById()
        {
            using (var SqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SPGetBrnch", SqlCon);
      
            }
            return new Branch();
        }

        public List<Branch> getBranchs()
        {

            Branch br;
            List<Branch> lista = new List<Branch>();
            using (var SqlCon = _connection.GetSqlConnection(_connection.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("SPGetBranch", SqlCon);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection.Open();
                SqlDataReader rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        br = new Branch();
                        br.BranchId = Int32.Parse(rdr["IdBranch"].ToString());
                        br.Telephone = rdr["telephone"].ToString();
                        br.Address = rdr["address"].ToString();
                        br.Name = rdr["name"].ToString();
                        br.CoorX = rdr["coorX"].ToString();
                        br.CoorY= rdr["coorY"].ToString();
                        br.Municipality = new Municipality()
                        {
                            MunicipalityId = Int32.Parse(rdr["idMunicipality"].ToString()),
                            Town = rdr["town"].ToString(),
                            state = new State()
                            {
                                StateId = Int32.Parse(rdr["idState"].ToString()),
                                name = rdr["statename"].ToString()
                            }
                        };

                        lista.Add(br);

                    }

                }
            }
            return lista;
        }

    }
}
