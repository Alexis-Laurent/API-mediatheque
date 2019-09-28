using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mediathequeApi.Models
{
    public class DetailsExemplaire
    {

        public int IdDocument { get; set; }
        public string Titre { get; set; }
        public string ISNB { get; set; }
        public string LibelleClassification { get; set; }
        public int AgeMinimum { get; set; }
        public string LibelleStatutExemplaire { get; set; }
        public string LibelleTypeDocument { get; set; }
        public System.DateTime DateEmprunt { get; set; }
        public string NomUsager { get; set; }
        public string PrenomUsager { get; set; }
        public string Adresse { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public string LibelleTypeAbonnement { get; set; }
        
    }
}