using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Authorization;
using Cir.Models;
using Dapper;

namespace Cir.Controllers
{
    [Route("api/[controller]")]
    public class CirController : Controller
    {
        private IConfiguration _config;

        private ICirRepository _cirInfo;

        public CirController(IConfiguration configuration, ICirRepository cirInfo)
        {
            _config = configuration;
            _cirInfo = cirInfo;
        }
        /// <summary>
        /// Apresenta uma lista com as informações da declaração de imposto de renda dos contratos.
        /// </summary>
        /// <param name="">Lista Imposto de Renda</param>
        /// <returns>Lista com dados da declaração de imposto de renda.</returns>
        [HttpGet]
        public IEnumerable<ImpostoRenda> GetCir()
        {
            return _cirInfo.GetCir();
        }

        /// <summary>
        /// Apresenta as informações da declaração de imposto de renda de um contrato.
        /// </summary>
        /// <param name="id">Número contrato</param>
        /// <returns>Dados da declaração de imposto de renda passando um contrato como parâmetro.</returns>
        [Authorize("Bearer")]
        [HttpGet("{id}")]        
        public IEnumerable<ImpostoRenda> GetCirContrato(string id)
        {
            return _cirInfo.GetCirContrato(id);
        }

        /// <summary>
        /// Apresenta as informações da declaração de imposto de renda de um contrato, cpf e credor.
        /// </summary>
        /// <param name="strContrato">Número contrato</param>
        /// <returns>Número válido de contrato do mutuário.</returns>
        /// <param name="strCPFCGC">Número CPF/CGC</param>
        /// <returns>Número válido de cpf ou cgc do mutuário.</returns>
        /// <param name="strCreCodigoCredor">Código do credor</param>
        /// <returns>Número do credor do contrato.</returns>
        [HttpGet("params")]
        public IEnumerable<ImpostoRenda> GetCirParams(string strContrato, string strCPFCGC, string strCreCodigoCredor)
        {
            return _cirInfo.GetCirParams(strContrato, strCPFCGC, strCreCodigoCredor);
        }
    }
}
