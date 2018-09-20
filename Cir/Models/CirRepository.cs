using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Cir.Models
{
    public class CirRepository : ICirRepository
    {
        private IConfiguration _config;

        public CirRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IEnumerable<ImpostoRenda> GetCir()
        {
            using (OracleConnection conexao = new OracleConnection(_config.GetConnectionString("PORTAL")))
            {

                return conexao.Query<ImpostoRenda>(
                    "SELECT * " +
                    "FROM IMPOSTO_RENDA ");
            }
        }

        public IEnumerable<ImpostoRenda> GetCirContrato(string id)
        {
            using (OracleConnection conexao = new OracleConnection(_config.GetConnectionString("PORTAL")))
            {

                return conexao.Query<ImpostoRenda>(
                    "SELECT * " +
                    "FROM IMPOSTO_RENDA " +
                    "WHERE NUMERO_CONTRATO = " + id);
            }
        }

        public IEnumerable<ImpostoRenda> GetCirParams(string strContrato, string strCPFCGC, string strCreCodigoCredor)
        {
            using (OracleConnection conexao = new OracleConnection(_config.GetConnectionString("PORTAL")))
            {
                return conexao.Query<ImpostoRenda>(
                    "SELECT CODIGO_UNIDADE_OPERACIONAL, CODIGO_GRUPO_HABITACIONAL, INDICADOR_CPF_CGC, " +
                       "       CPF_CGC, (NUMERO_CONTRATO || DIGITO_VERIFICADOR) as CONTRATO, " +
                       "       NOME_MUTUARIO, ADM_CODIGO_ADMINISTRADOR, " +
                       "       VALOR_JUROS_DIA, VALOR_SEGUROS, VALOR_TAXA_FCVS, " +
                       "       VALOR_PAGO_TOTAL, VALOR_SALDO_DEVEDOR, " +
                       "       NVL(TRIM(ABREV_IMOVEL),' ') AS ABREV_IMOVEL, NVL(LOGRADOURO_IMOVEL,' ') AS LOGRADOURO_IMOVEL, " +
                       "       NVL(COMPLEMENTO_IMOVEL,' ') AS COMPLEMENTO_IMOVEL, NVL(BAIRRO_IMOVEL,' ') AS BAIRRO_IMOVEL, NVL(CIDADE_IMOVEL,' ') AS CIDADE_IMOVEL, NVL(UF_IMOVEL,' ') AS UF_IMOVEL, " +
                       "       NUMERO_IMOVEL, NVL(CEP_IMOVEL, 0) AS CEP_IMOVEL, " +
                       "       VALOR_DIFERENCA_PAGAMENTO, VALOR_MORA, VALOR_AMORTIZACAO, " +
                       "       VALOR_ENCARGO_TOTAL, (VALOR_ENCARGO_TOTAL + VALOR_SALDO_DEVEDOR) as EM_ENCARGO_TOTAL, " +
                       "       VALOR_TAXA_AVISTA, VALOR_DESCONTO, VALOR_FGTS, VALOR_AMORT_EXTRAORDINARIA, " +
                       "       NVL(CODIGO_ALTERACAO, 0) AS CODIGO_ALTERACAO, TO_char (IMRE_DAT_ALTERACAO, 'dd/mm/yyyy') AS IMRE_DAT_ALTERACAO," +
                       "       CRE_CODIGO_CREDOR, ANO_BASE, VLR_MULTA, SIT_ESPECIAL, " +
                       "       VLR_PAG_PARCEIRO, VLR_PAG_MUTUARIO, VLR_FGTS_CONTRATACAO, " +
                       "       VLR_FGTS_PRESTACAO, VLR_FGTS_AMORT, VLR_FGTS_LIQ, " +
                       "       VLR_REC_LIQ, VLR_REC_AMORT, VLR_TOT_LIQ, VLR_TOT_PAGO_MUT, " +
                       "       VLR_PAG_SINISTRO, APOI_COD_APOLICE, IMRE_VLR_ADJUDICADO, IMRE_VLR_ARREMATACAO, " +
                       "       CODIGO_ORIGEM_RECURSOS, IMRE_COD_LINHA_FINAN, IMRE_TIP_FINANCIAMENTO, IMRE_VLR_PAGAMENTO_FGHAB, IMRE_VLR_SUBSI_ALIENACAO, " +
                       "       IMRE_VLR_PRESTACAO_FAR, IMRE_VLR_PAGO_FDS, IMRE_VLR_FGTS_DEV_ARREMAT, TO_char (IMRE_DAT_SECURITIZACAO_CONTR, 'dd/mm/yyyy') AS IMRE_DAT_SECURITIZACAO_CONTR, IMRE_VLR_TRANSFERENCIA, " +
                       "       TO_char (IMRE_DAT_ENCARGO_ATRASO, 'dd/mm/yyyy') AS IMRE_DAT_ENCARGO_ATRASO, IMRE_TIP_LAYOUT, IMRE_VLR_SALDO_ARREMATACAO, IMRE_VLR_SEGURO_FGHAB " +
                       " FROM IMPOSTO_RENDA " +
                       " WHERE NUMERO_CONTRATO = " + strContrato +
                       " AND   CPF_CGC = " + strCPFCGC +
                       " AND   CRE_CODIGO_CREDOR = " + strCreCodigoCredor);
            }
        }
    }
}
