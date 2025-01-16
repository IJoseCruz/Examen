using FluentValidation;

namespace Examen.Model.DTO.Validations
{
    public class RequestProductosValidator : AbstractValidator<RequestProducto>
    {
        public RequestProductosValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio.")
                .Length(3, 100)
                .WithMessage("El nombre debe tener entre 3 y 100 caracteres.");

            RuleFor(x => x.Precio)
                .GreaterThan(0)
                .WithMessage("El precio debe ser mayor que 0.");

            RuleFor(x => x.CantidadStock)
                .GreaterThanOrEqualTo(0).
                WithMessage("La cantidad en stock no puede ser negativa.");
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("La descripción debe tener maximo 500 caracteres");
        }
    }
}
