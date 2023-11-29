using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_slide_33.Models
{
    public class Epargne : Compte
    {

        #region Propriétés
        //1.Créer une classe « Epargne » permettant la gestion d’un carnet d’épargne qui devra implémenter

        //◼ Les propriétés publiques:
        //◼ Numéro(string)
        //◼ Solde(double) - Lecture seule
        //◼ DateDernierRetrait(DateTime) - représentant la date du dernier retrait sur le carnet
        //◼ Titulaire(Personne)

        //4.Changer l’encapsulation des propriétés des classes « Personne », « Compte » et « Epargne » afin de spécifier leur mutateur en « private ».
        public DateTime dateDernierRetrait { get; private set; }


        #endregion

        #region Constructeurs
        //2.Le cas échéant, ajoutez le ou les constructeurs aux classes « Courant » et « Epargne ».
        public Epargne(string numero, Personne titulaire) : base (numero, titulaire)
        {
            
        }

        public Epargne(string numero, Personne titulaire, double solde) :base (numero, titulaire, solde)
        {
            
        }

        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            base.Retrait(montant);
            dateDernierRetrait = DateTime.Now;
        } 

        public override void Depot(double montant)
        {

        }

        protected override double CalculInteret()
        {
            return solde * 0.045;
        }

        #endregion
    }
}
