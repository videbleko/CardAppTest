using CardApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CardApp.DTO;

public class CreditCardDTO
{
    private const string DateFormat = "MMyy";

    public int Id { get; set; }

    [Required(ErrorMessage = "El campo \"Número de Tarjeta\" es obligatorio.")]
    [MinLength(16, ErrorMessage = "El campo \"Número de Tarjeta\" debe tener 16 dígitos.")]
    [MaxLength(16, ErrorMessage = "El campo \"Número de Tarjeta\" debe tener 16 dígitos.")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo \"Número de Tarjeta\" solo puede contener números.")]
    public string CardNumber { get; set; }

    [Required(ErrorMessage = "El campo \"Nombre Titular\" es obligatorio.")]
    [MaxLength(20, ErrorMessage = "El campo \"Nombre Titular\" no puede exceder los 20 caracteres.")]
    [RegularExpression(@"^[\p{L}\p{M}\s]+$", ErrorMessage = "El campo \"Nombre Titular\" solo puede contener caracteres y espacios.")]
    public string CardName { get; set; } = null!;

    [Required(ErrorMessage ="El campo \"CVV\" es obligatorio.")]
    [MinLength(3, ErrorMessage ="El campo \"CVV\" debe tener 3 digitos")]
    [MaxLength(3, ErrorMessage = "El campo \"CVV\" debe tener 3 digitos")]
    public string CVV { get; set; }

    [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
    [Display(Name = "Fecha de Expiración.")]
    [MinLength(4, ErrorMessage = "La fecha de expiración debe contener 4 dígitos (mm/yy).")]
    [MaxLength(4, ErrorMessage = "La fecha de expiración debe contener 4 dígitos (mm/yy).")]
    [RegularExpression(@"^(0[1-9]|1[0-2])(0[1-9]|[1-9][0-9])$", ErrorMessage = "El formato debe ser MMyy.")]
    [DisplayFormat(DataFormatString = "{0:MMyy}", ApplyFormatInEditMode = true)]
    [CustomValidation(typeof(CreditCardDTO), "ValidarFecha")]
    public string ExpirationDate { get; set; }

    public static ValidationResult ValidarFecha(string fecha)
    {
        var añoMinimo = DateTime.Now.Year;
        var añoMaximo = DateTime.Now.Year + 5;

        if (!DateTime.TryParseExact(fecha, DateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
        {
            return new ValidationResult("La fecha no es válida.");
        }

        if (parsedDate.Year < añoMinimo || parsedDate.Year > añoMaximo)
        {
            return new ValidationResult($"El año debe estar entre {añoMinimo} y {añoMaximo}.");
        }

        return ValidationResult.Success;
    }

}
