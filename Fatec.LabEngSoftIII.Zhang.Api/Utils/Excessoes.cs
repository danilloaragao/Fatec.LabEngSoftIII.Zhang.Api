using System;

namespace Fatec.LabEngSoftIII.Zhang.Api.Utils
{
    public class CashInsuficienteException : Exception
    {
        public CashInsuficienteException() : base("Você não possui cash suficiente para essa compra.")
        {

        }
    }
}
