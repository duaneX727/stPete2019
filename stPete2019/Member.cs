using System.ComponentModel.DataAnnotations;

namespace stPete2019
{
    public class Member
    {
        public int Id { get; set; }

        [Required,StringLength(49)]
        public string Name { get; set; }
    }
}