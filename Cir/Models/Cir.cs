using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace Cir.Models
{
    public class RESUMO
    {
        public string IDENTIFICACAO { get; set; }
        public string CPF_CGC { get; set; }
    }

    public static class Roles
    {
        public const string ROLE_API_CIR = "Acesso-APICir";
    }

    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }

    [Table("dbo.IMPOSTO_RENDA")]
    public class ImpostoRenda
    {
        [Key]
        public string NUMERO_CONTRATO{ get; set; }
        [Required]
        public long CPF_CGC { get; set; }
        [Required]
        public int ANO_BASE { get; set; }
        [Required]
        public int ADM_CODIGO_ADMINISTRADOR { get; set; }
        [Required]
        public int CRE_CODIGO_CREDOR { get; set; }
        public int CODIGO_FILIAL { get; set; }
        public int CODIGO_UNIDADE_OPERACIONAL { get; set; }
        public int DIGITO_VERIFICADOR { get; set; }
        public int SEQUENCIA { get; set; }
        public int CODIGO_ORIGEM_RECURSOS { get; set; }
        public string NOME_MUTUARIO { get; set; }
        public int CODIGO_UNIDADE_COBRANCA { get; set; }
        public int CODIGO_GRUPO_HABITACIONAL { get; set; }
        public int CODIGO_SUBTITULO_CONTABIL { get; set; }
        public string ABREV_IMOVEL { get; set; }
        public string LOGRADOURO_IMOVEL { get; set; }
        public string COMPLEMENTO_IMOVEL { get; set; }
        public string BAIRRO_IMOVEL { get; set; }
        public string CIDADE_IMOVEL { get; set; }
        public string UF_IMOVEL { get; set; }
        public int NUMERO_IMOVEL { get; set; }
        public int CEP_IMOVEL { get; set; }
        public string LOGRADOURO_CORRESP { get; set; }
        public string ABREV_CORRESP { get; set; }
        public string COMPLEMENTO_CORRESP { get; set; }
        public string BAIRRO_CORRESP { get; set; }
        public string CIDADE_CORRESP { get; set; }
        public string UF_CORRESP { get; set; }
        public int NUMERO_CORRESP { get; set; }
        public int CEP_CORRESP { get; set; }
        public long VALOR_AMORTIZACAO { get; set; }
        public long VALOR_PRESTACAO { get; set; }
        public long VALOR_SEGUROS { get; set; }
        public long VALOR_TAXAS { get; set; }
        public long VALOR_FCVS { get; set; }
        public long VALOR_FGTS { get; set; }
        public long VALOR_MORA { get; set; }
        public long VALOR_JUROS_DIA { get; set; }
        public long VALOR_TAXA_AVISTA { get; set; }
        public long VALOR_TAXA_FCVS { get; set; }
        public long VALOR_ENCARGO_TOTAL { get; set; }
        public long VALOR_MORA_TOTAL { get; set; }
        public long VALOR_AMORT_EXTRAORDINARIA { get; set; }
        public long VALOR_SALDO_DEVEDOR { get; set; }
        public long VALOR_DESCONTO { get; set; }
        public long VALOR_DIFERENCA_PAGAMENTO { get; set; }
        public long IMRE_VLR_ADJUDICADO { get; set; }
        public long IMRE_VLR_ARREMATACAO { get; set; }
        public int FLAG_SIINC { get; set; }
        public int CODIGO_ALTERACAO { get; set; }
        public long VLR_MULTA { get; set; }
        public int SIT_ESPECIAL { get; set; }
        public long VLR_PAG_PARCEIRO { get; set; }
        public long VLR_PAG_MUTUARIO { get; set; }
        public long VLR_FGTS_CONTRATACAO { get; set; }
        public long VLR_FGTS_PRESTACAO { get; set; }
        public long VLR_FGTS_AMORT { get; set; }
        public long VLR_FGTS_LIQ { get; set; }
        public long VLR_REC_LIQ { get; set; }
        public long VLR_REC_AMORT { get; set; }
        public long VLR_TOT_LIQ { get; set; }
        public long VLR_TOT_PAGO_MUT { get; set; }
        public long VLR_PAG_SINISTRO { get; set; }
        public long APOI_COD_APOLICE { get; set; }
        public long VALOR_PAGO_TOTAL { get; set; }
        public int IMRE_COD_LINHA_FINAN { get; set; }
        public int IMRE_TIP_FINANCIAMENTO { get; set; }
        public long IMRE_VLR_PAGAMENTO_FGHAB { get; set; }
        public long IMRE_VLR_SUBSI_ALIENACAO { get; set; }
        public long IMRE_VLR_PRESTACAO_FAR { get; set; }
        public long IMRE_VLR_FGTS_DEV_ARREMAT { get; set; }
        public string IMRE_DAT_SECURITIZACAO_CONTR { get; set; }
        public long IMRE_VLR_SEGURO_FGHAB { get; set; }
        public long IMRE_VLR_TRANSFERENCIA { get; set; }
        public long IMRE_VLR_SALDO_ARREMATACAO { get; set; }
        public long IMRE_TIP_LAYOUT { get; set; }
        public string IMRE_DAT_ENCARGO_ATRASO { get; set; }
        public string IMRE_DAT_ALTERACAO { get; set; }
        public long IMRE_VLR_PAGO_FDS { get; set; }
        public long IMRE_VLR_DIVIDA_TOTAL { get; set; }
        public long IMRE_SALDO_SINIS_RESAR { get; set; }
        public long IMRE_SINIS_RESAR_ANO_BASE { get; set; }
    }
}
