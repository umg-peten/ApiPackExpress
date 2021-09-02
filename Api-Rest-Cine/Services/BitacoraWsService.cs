using ApiPackExpress.IServices;
using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.Services
{
    public class BitacoraWsService : IBitacoraWSService
    {
        private readonly IConnection _connection;
        private BitacoraWS bitacoraWS;
        public BitacoraWsService(IConnection connection)
        {
            this._connection = connection;
        }
        public void InsertBitacoraWS(BitacoraWS bitacoraWS)
        {
            bitacoraWS = new BitacoraWS();


        }
    }
}
