//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitePanierFilm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Category_id { get; set; }
        public int Id { get; set; }
        public string Img_url { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
