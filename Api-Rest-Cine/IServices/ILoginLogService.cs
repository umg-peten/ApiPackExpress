﻿using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.IServices
{
    public interface ILoginLogService
    {
        public void insertLoginLog(LoginLog loginlog);
        public bool verifyPasswordUsed(string pw, int idUser);
    }
}
