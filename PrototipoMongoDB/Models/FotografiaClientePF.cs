using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoMongoDB.Models
{
    public class FotografiaClientePF
    {
        public int Id { get; set; }
        public string PedidoId { get; set; }
        public byte[] Imagem { get; set; }
    }
}
