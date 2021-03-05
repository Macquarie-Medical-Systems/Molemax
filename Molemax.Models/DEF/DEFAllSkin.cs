using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFAllSkin")]
    public class DEFAllSkin
    {
        public string DiseaseName { get; set; }
        public string? ParentCategoryId  { get; set; }
        public string? Category { get; set; }
        [Key]
        public string CategoryOrImageId { get; set; }
        public int IsFirstLevelCategory { get; set; }
        public string? Description { get; set; }
        public string? ImageId { get; set; }
    }
}
