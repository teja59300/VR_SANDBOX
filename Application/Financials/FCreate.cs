using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Financials
{
    public class FCreate
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int TotalAmount { get; set; }
            public int TotalAcres { get; set; }
            public int TotalExpenses { get; set; }
            public int NetProfit { get; set; }
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                    _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var finance = new Financial
                {
                    Id = request.Id,
                    TotalAmount = request.TotalAmount,
                    TotalAcres = request.TotalAcres,
                    TotalExpenses = request.TotalExpenses,
                    Activity = request.Activity

                };
                _context.Financials.Add(finance);
                var fsucess = await _context.SaveChangesAsync() > 0;
                if(fsucess)
                {
                    return Unit.Value;
                }
                throw new Exception("Problem saving changes");
            }
        }
    }
}