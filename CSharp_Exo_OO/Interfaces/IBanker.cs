using Exo_slide_33.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_slide_33.Interfaces
{
    public interface IBanker
    {
        //2.Définir l’interface « IBanker » ayant les mêmes fonctionnalités que « ICustomer ».
        //Elle lui permettra, en plus, d’invoquer la méthode du « AppliquerInteret » et offrira un accès en lecture au « Titulaire » et au « Numero ».
        //4. Si nous ajoutions la propriété « LigneDeCredit » à « IBanker », définir sur papier les modifications qu’il faudrait apporter à nos classes.
        // il faudrait alors que la ligne de credit se retrouve non plus dans courant mais dans compte.


        #region Propriétés
        double solde { get; }
        string numero { get; }
        Personne Titulaire { get; }
        #endregion

        #region Méthodes
        void Depot(double montant);
        void Retrait(double montant);
        void AppliquerInteret();
        #endregion
    }
}
