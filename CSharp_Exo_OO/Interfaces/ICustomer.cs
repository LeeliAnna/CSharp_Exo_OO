using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_slide_33.Interfaces
{
    public interface ICustomer
    {

        //1. Définir l’interface « ICustomer », afin de limiter l’accès à consulter la propriété « Solde » et d’utiliser les méthodes « Depot » et « Retrait ».


        #region Propriétés
        double solde { get; }
        #endregion

        #region Méthodes
        void Depot(double montant);
        void Retrait(double montant);
        #endregion
    }
}
