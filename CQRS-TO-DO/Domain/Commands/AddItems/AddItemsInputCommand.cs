using System;

namespace CQRS_TO_DO.Domain
{
    public class AddItemsInputCommand
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
