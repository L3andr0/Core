using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Cir.Models;
using Dapper;

namespace Cir
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RESUMO Find(string userID, string cpfcgc)
        {
            using (OracleConnection conexao = new OracleConnection(_configuration.GetConnectionString("PORTAL")))
            {

                return conexao.QueryFirstOrDefault<RESUMO>(
                    "SELECT IDENTIFICACAO, CPF_CGC " +
                    " FROM RESUMO " +
                    " WHERE IDENTIFICACAO = " + userID +
                    " AND CPF_CGC = " + cpfcgc);
            }
        }
    }
}