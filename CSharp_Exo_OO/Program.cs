using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Text;
using Exo_slide_33.Models;
using System.Numerics;
using System.Reflection.Metadata;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Net;
using Exo_slide_33.Exceptions;
using System;

namespace CSharp_Exo_OO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Personne client1 = new Personne();
            Personne client1 = new Personne("Coucou", "Hibou", new DateTime(1999, 05, 15));
            //Courant compte1 = new Courant();
            Compte compte1 = new Courant("0123456", client1, 2000);

            //client1.firstName = "Coucou";
            //client1.lastName = "Hibou";
            //client1.birthDate = new DateTime(1999, 05, 15);

            //compte1.Titulaire = client1;
            //compte1.numero = "0123456";
            //compte1.ligneDeCredit = 2000;


            Banque banque1 = new Banque()
            {
                Nom = "Tutu"
            };
            banque1.Ajouter(compte1.numero, compte1);

            try
            {
                Console.WriteLine("-----------------------------------------");
                compte1.Depot(5000);
                Console.WriteLine($"Le solde de Monsieur {client1.lastName} est de {compte1.solde} euro.");
                Console.WriteLine("-----------------------------------------");
                compte1.Retrait(500);
                Console.WriteLine($"Le solde de Monsieur {client1.lastName} est de {compte1.solde} euro.");
                Console.WriteLine("-----------------------------------------");
                compte1.Retrait(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType);
                Console.WriteLine(ex.Message);
            }

        }
    }
}