using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Requests.Expenses;
using LuksonExpense.Domain.Shared;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Expenses.Commands.Add
{
    public sealed class AddExpenseCommand : IRequest<Response<ExpenseDTO>>
    {
        public AddExpenseRequest Request { get; set; }
    }
}
