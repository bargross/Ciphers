using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Common.Model.Keys
{
    public interface IKeys<T>
    {
        T KeyOne { get; set; }
        T KeyTwo { get; set; }
    }
}
