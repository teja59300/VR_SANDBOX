// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using Persistence;

// namespace Application.Financials
// {
//     public class FDelete
//     {
//                 public class Command : IRequest
//                 {
//                     public int Id { get; set; }
//                 }
        
//                 public class Handler : IRequestHandler<Command>
//                 {
//                     private readonly DataContext _context;
//                     public Handler(DataContext context)
//                     {
//                             _context = context;
        
//                     }
//                     public async  Task<Unit> Handle(Command request, CancellationToken cancellationToken)
//                     {
//                         //handler logic comes here
//                         var finance = await _context.Financials.FindAsync(request.Id);
//                         if(finance == null)
//                         {
//                             throw new Exception("no financials found");
//                         }
//                         else
//                         {
//                             _context.Remove(finance);
//                         }
//                         var success = await _context.SaveChangesAsync() > 0;
//                         if(success)
//                         {
//                             return Unit.Value;
//                         }
//                         throw new Exception("problem saving changes ");
        
//                     }
//                 }
//     }
// }