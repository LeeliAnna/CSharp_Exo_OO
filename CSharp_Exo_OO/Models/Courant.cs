using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Exo_slide_33.Exceptions;
using Exo_slide_33.Models;

namespace Exo_slide_33.Models
{
    public class Courant : Compte
    {
        #region Propriétés

        private double _ligneDeCredit { get; set; }
        public double LigneDeCredit { 
            get
            {
                return _ligneDeCredit;
            }
            private set
            {
                _ligneDeCredit = value;
                if (value <= 0)
                {
                    _ligneDeCredit = 0;
                    throw new InvalidOperationException("La ligne de crédit ne peux pas descendre en dessous de zéro");
                }
            }
        }

        #endregion

        #region Constructeurs

        public Courant(string numero, Personne titulaire) : base (numero, titulaire)
        {
            
        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }

        #endregion

        #region Méthodes
        int montant;
        public override void Retrait(double montant)
        {
            double ancienSolde = solde;
            base.Retrait(montant , _ligneDeCredit);
            if (ancienSolde >= 0 && solde < 0)
            {
                DeclencheEvenement();
            }
            else
            {
                throw new SoldeInsuffisantException();
            }

        }

        public override void Depot(double montant)
        {
            base.Depot(montant);
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Le montant doit être supérieur à zéro.");
            }
        }
        protected override double CalculInteret()
        {
            return solde > 0 ? solde * 0.03 : solde * 0.0975;
        }

        #endregion

    }
}
