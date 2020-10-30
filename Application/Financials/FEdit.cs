// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using Domain;
// using MediatR;
// using Persistence;

// namespace Application.Financials
// {
//     public class FEdit
//     {
//                 public class Command : IRequest
//                 {
//                     public int Id { get; set; }
//                     public int? TotalAmount { get; set; }
//                     public int? TotalAcres { get; set; }
//                     public int? TotalExpenses { get; set; }
//                     public int? NetProfit { get; set; }
//                     public Activity Activity { get; set; }
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
//                             finance.TotalAcres =request.TotalAcres ?? finance.TotalAcres;
//                             finance.TotalAmount=request.TotalAmount ?? finance.TotalAmount;
//                             finance.NetProfit = request.NetProfit ?? finance.NetProfit;
//                             finance.Activity = request.Activity ?? finance.Activity;
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