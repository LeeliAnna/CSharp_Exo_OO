using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_slide_33.Models
{
    public class Personne
    {
        #region Propriétés
        public string lastName { get; private set; }
        public string firstName { get; private set; }
        public DateTime birthDate { get; private set; }

        #endregion

        #region Constructeurs

        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            lastName = nom;
            firstName = prenom;
            birthDate = dateNaissance;            
        }

        #endregion
    }
}
