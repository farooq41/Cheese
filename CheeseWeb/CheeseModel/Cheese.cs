using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseModel
{
    public class Cheese
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public CheesePicture Picture { get; set; }

    }
}
