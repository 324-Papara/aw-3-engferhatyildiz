using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Para.Api.Attribute;

namespace Para.Api.Model;

public abstract class Book(int id, string name, string author, int pageCount, int year)
{
    [Required]
    [Range(minimum:1,maximum:10000)]
    [DisplayName("Book id")]
    public int Id { get; set; } = id;


    [Required]
    [StringLength(maximumLength:50,MinimumLength = 5)]
    [DisplayName("Book name")]
    public string Name { get; set; } = name;


    [Required]
    [StringLength(maximumLength:50,MinimumLength = 5)]
    [DisplayName("Book author info")]
    public string Author { get; set; } = author;


    [Required]
    [Range(minimum:50,maximum:400)]
    [DisplayName("Book page count")]
    [PageCount]
    public int PageCount { get; set; } = pageCount;


    [Required]
    [Range(minimum:1900,maximum:2024)]
    [DisplayName("Book year")]
    public int Year { get; set; } = year;
}