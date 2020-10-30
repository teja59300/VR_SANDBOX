// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using Domain;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// namespace Application.Financials
// {
//     public class FList
//     {
//         public class Query : IRequest<List<Financial>>
//         {

//         }

//         public class Handler : IRequestHandler<Query, List<Financial>>
//         {
//             private readonly DataContext _context;
//             public Handler(DataContext context)
//             {
//                     _context = context;

//             }
//             public async Task<List<Financial>> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 var financials = await _context.Financials.ToListAsync();
//                 return financials;
//             }
//         }

//     }
// }