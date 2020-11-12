using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.Entities
{
    [Table("DifferenceObject")]
    public class DifferenceObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column("Index")]
        [Index(IsUnique = true)]
        public int Index { get; set; }

        [Column("DiffResult")]
        public string DiffResult { get; set; }

        [Column("RightValue")]
        public string RightValue { get; set; }

        [Column("LeftValue")]
        public string LeftValue { get; set; }
    }
}
