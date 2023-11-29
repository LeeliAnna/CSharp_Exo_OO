using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exo_slide_33.Models.Compte;

namespace Exo_slide_33.Models
{
    public class Banque
    {
        
        #region Propriétés
        public string Nom { get; set; }

        //public event PassageEnNegatifDelegate PassageEnNegatifAction;

        #endregion
        private Dictionary<string , Compte> _comptes = new Dictionary<string, Compte>();

        #region Indexeur
        public Compte? this[string numero]
        {
            get 
            {
                Compte c1;
                _comptes.TryGetValue(numero, out c1);
                return c1; 
            }
        }
        #endregion

        #region Méthode

        public void Ajouter(string numero , Compte compte)
        {
            if (!_comptes.ContainsKey(compte.numero)) 
            {
                _comptes.Add(numero, compte);
                compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            }
            
        }

        public void Supprimer(string numero, Compte compte)
        {
            if (!_comptes.ContainsKey(numero))
            {
                _comptes.Remove(numero);
                compte.PassageEnNegatifEvent -= PassageEnNegatifAction;
            }
            
            
        }

        public double AvoirDesComptes(Personne p)
        {
            double avoir = 0.0;

            foreach (Compte c in _comptes.Values)
            {
                if (c.Titulaire.lastName == p.lastName)
                {
                    avoir += c.solde;
                }
            }
            return avoir;
        }

        public void PassageEnNegatifAction(Compte compte)
        {
            Console.WriteLine($" Le compte {compte.numero} vient de passer en négatif ");
        }

        //public void DeclencheMessage()
        //{
        //    foreach (Compte compte in _comptes.Values)
        //    {
        //        PassageEnNegatifAction?.Invoke(compte);
        //        Console.WriteLine($" Le compte {compte.numero} vient de passer en négatif ");
        //    }
        //}

        #endregion

    }
}
