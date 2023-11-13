﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ICommonMethods
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
