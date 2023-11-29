using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo_slide_33.Exceptions;
using Exo_slide_33.Interfaces;
using Exo_slide_33.Models;

namespace Exo_slide_33.Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public delegate void PassageEnNegatifDelegate(Compte compte);

        #region Propriétés
        public string numero { get; private set; }
        private double _solde;
        public double solde
        {
            get { return _solde; }
            private set { _solde = value; }
        }
        public Personne Titulaire { get; private set; }

        public event PassageEnNegatifDelegate PassageEnNegatifEvent;

        #endregion

        #region Constructeurs

        public Compte(string numero, Personne titulaire)
        {
            this.numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            _solde = solde;
        }

        #endregion

        #region Méthodes

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant) ,"Le montant doit être supérieur à zéro.");
            }
            if (solde - montant <= ligneDeCredit)
            {
                throw new SoldeInsuffisantException(solde, montant, ligneDeCredit);
            }
            solde -= montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0.0);
        }

        public virtual void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Le montant doit être supérieur à zéro.");
            }
            solde += montant;

        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            solde += CalculInteret();
        }

        protected void DeclencheEvenement()
        {
            PassageEnNegatifEvent?.Invoke(this);
        }

        #endregion

        #region Surcharge
        public static double operator +(Compte compte, double _solde)
        {
            //ternaire 
            return _solde + ((compte._solde < 0.0) ? 0.0 : compte._solde);


        }
        #endregion




    }
}
