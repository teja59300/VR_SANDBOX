using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public string NoOfAcres { get; set; }
            public string Amount { get; set; }
            public string Status { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
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
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                 _userAccessor = userAccessor;
                _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = new Activity
                {
                    Id = request.Id,
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Date = request.Date,
                    Description = request.Description,
                    NoOfAcres = request.NoOfAcres,
                    Amount = request.Amount,
                    Status = request.Status
                };
                _context.Activities.Add(activity);

                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUserName());

                var attendee = new UserActivity
                {
                    AppUser = user,
                    Activity = activity,
                    IsHost = true,
                    DateJoined = DateTime.Now
                };

                _context.UserActivities.Add(attendee);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("problem saving changes");


                

            }
        }
    }
}