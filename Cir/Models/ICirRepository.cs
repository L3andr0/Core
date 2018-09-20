using System.Collections.Generic;

namespace Cir.Models
{
    public interface ICirRepository
    {
        IEnumerable<ImpostoRenda> GetCir();
        IEnumerable<ImpostoRenda> GetCirContrato(string id);
        IEnumerable<ImpostoRenda> GetCirParams(string strContrato, string strCPFCGC, string strCreCodigoCredor);

    }
}
