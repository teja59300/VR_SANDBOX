using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
                public class Command : IRequest
                {
                            public Guid Id { get; set; }
                            public string Name { get; set; }
                            public string PhoneNumber { get; set; }
                            public string Address { get; set; }
                            public DateTime? Date { get; set; }
                            public string Description { get; set; }
                            public string NoOfAcres { get; set; }
                            public string Amount { get; set; }
                            public string Status { get; set; }   
                }

                public class CommandValidator:AbstractValidator<Command>
                {
                    public CommandValidator()
                    {
                        RuleFor(x => x.Name).NotEmpty();
                        RuleFor(x => x.PhoneNumber).NotEmpty();
                        RuleFor(x => x.Address).NotEmpty();
                        RuleFor(x => x.Date).NotEmpty();
                        RuleFor(x => x.Description).NotEmpty();
                        RuleFor(x => x.NoOfAcres).NotEmpty();
                        RuleFor(x => x.Amount).NotEmpty();
                        RuleFor(x => x.Status).NotEmpty();
                }
        }
                public class Handler : IRequestHandler<Command>
                {
                    private readonly DataContext _context;
                    public Handler(DataContext context)
                    {
                            _context = context;
        
                    }
                    public async  Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                    {   
                        var activity =  await _context.Activities.FindAsync(request.Id);

                        if(activity == null)
                        {
                            if(activity == null)
                        {
                            throw new RestException(HttpStatusCode.NotFound, new {activity = "Nof Found"});
                        }
                        }
                        activity.Name= request.Name ?? activity.Name;
                        activity.PhoneNumber= request.PhoneNumber ?? activity.PhoneNumber;
                        activity.Date= request.Date ?? activity.Date;
                        activity.Description= request.Description ?? activity.Description;
                        activity.Address=request.Address ?? activity.Address;
                        activity.Status=request.Status ?? activity.Status;
                        activity.NoOfAcres = request.NoOfAcres ?? activity.NoOfAcres;
                        activity.Amount=request.Amount ?? activity.Amount;

                        var success = await _context.SaveChangesAsync() > 0;
                        if(success)
                        {
                            return Unit.Value;
                        }
                        throw new Exception("problem saving changes ");
        
                    }
                }
    }
}