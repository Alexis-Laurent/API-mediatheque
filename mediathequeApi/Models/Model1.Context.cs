﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MediathequeEntities : DbContext
    {
        public MediathequeEntities()
            : base("name=MediathequeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AbonnementPromo> AbonnementPromo { get; set; }
        public virtual DbSet<ClassificationAge> ClassificationAge { get; set; }
        public virtual DbSet<Coordonnees> Coordonnees { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Exemplaire> Exemplaire { get; set; }
        public virtual DbSet<Fournisseur> Fournisseur { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Paiement> Paiement { get; set; }
        public virtual DbSet<Promo> Promo { get; set; }
        public virtual DbSet<StatutExemplaire> StatutExemplaire { get; set; }
        public virtual DbSet<StatutUsager> StatutUsager { get; set; }
        public virtual DbSet<TypeAbonnement> TypeAbonnement { get; set; }
        public virtual DbSet<TypeDocument> TypeDocument { get; set; }
        public virtual DbSet<Usager> Usager { get; set; }
    }
}