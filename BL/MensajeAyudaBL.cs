using EN;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MensajeAyudaBL
    {
        private MensajeAyudaDAL dal = new MensajeAyudaDAL();

        public bool EnviarMensaje(MensajesAyuda m)
        {
            return dal.RegistrarMensaje(m);
        }
    }
}
