//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mediathequeApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AbonnementPromo
    {
        public int IdAbonnementPromo { get; set; }
        public int IdTypeAbonnement { get; set; }
        public int IdPromo { get; set; }
    
        public virtual Promo Promo { get; set; }
        public virtual TypeAbonnement TypeAbonnement { get; set; }
    }
}
