using System.ComponentModel;

namespace BasicAccountOperations.Domain.Enums
{
    public enum typeAccount
    {
        [DescriptionAttribute("Corrente")]
        corrente = 1,

        [DescriptionAttribute("Poupanca")]
        poupanca  =2
    }
}