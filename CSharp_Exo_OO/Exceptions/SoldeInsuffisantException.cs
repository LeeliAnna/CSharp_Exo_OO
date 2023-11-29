using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exo_slide_33.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public double Solde { get; set; }
        public double Montant { get; set; }
        public double Limite { get; set; }
        public SoldeInsuffisantException(): base ("Solde Insufisant")
        {
            
        }

        public SoldeInsuffisantException(string message) : base(message)
        {
            
        }


        public SoldeInsuffisantException(double solde, double montant, double limite) : this($"Suite à une demande de retrait de {montant} et votre solde étant de {solde}, limité à {-limite}, vous ne pouvez pas effectuer ce retrait")
        {
            Solde = solde;
            Montant = montant;
            Limite = limite;
        }
    }
}
