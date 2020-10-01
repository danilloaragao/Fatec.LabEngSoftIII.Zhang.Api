using System;

namespace Fatec.LabEngSoftIII.Zhang.Api.Utils
{
    public class CashInsuficienteException : Exception
    {
        public CashInsuficienteException() : base("Você não possui cash suficiente para essa compra.")
        {
        }
    }

    public class SkinObtidaException : Exception
    {
        public SkinObtidaException() : base("Você já possui essa skin.")
        {
        }
    }
}
