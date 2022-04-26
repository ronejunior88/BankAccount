using System.ComponentModel;

namespace BasicAccountOperations.Domain.Enums
{
    public enum typeTransfer
    {
        [DescriptionAttribute("Deposit")]
        corrente = 1,

        [DescriptionAttribute("Withdraw")]
        poupanca  =2
        
    }
}