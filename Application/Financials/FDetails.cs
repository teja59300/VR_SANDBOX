using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class FDetails
    {
        public class Query : IRequest<Financial>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Financial>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                    _context = context;

            }
            public  async Task<Financial> Handle(Query request, CancellationToken cancellationToken)
            {
                var financial = await _context.Financials.FindAsync(request.Id);
                return financial;
            }
        }
    }
}