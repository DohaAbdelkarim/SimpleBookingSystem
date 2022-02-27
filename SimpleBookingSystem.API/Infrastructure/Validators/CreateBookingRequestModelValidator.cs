using FluentValidation;
using SimpleBookingSystem.API.Models;
using System;

namespace SimpleBookingSystem.API.Infrastructure
{
    public class CreateBookingRequestModelValidator : AbstractValidator<CreateBookingRequestModel>
    {
        public CreateBookingRequestModelValidator()
        {
            RuleFor(x => x.DateFrom).Must(ValidateDate).WithMessage("Invalid DateFrom");

            RuleFor(x => x.DateTo).Must(ValidateDate).WithMessage("Invalid DateTo");

            RuleFor(x => x.ResourceId).GreaterThan(0).WithMessage("ResourceId is Required");

            RuleFor(x => x.BookedQuantity).GreaterThan(0).WithMessage("BookedQuantity is Required");
        }
        private bool ValidateDate(DateTimeOffset date)
        {
            return !date.Equals(default(DateTimeOffset)) && (date != null);
        }
    }
}