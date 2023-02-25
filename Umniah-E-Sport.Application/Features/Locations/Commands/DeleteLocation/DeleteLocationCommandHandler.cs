using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationCommandResponse>
    {
        private readonly ILocationManager _locationManager;

        public DeleteLocationCommandHandler(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        public async Task<DeleteLocationCommandResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationManager.GetAsync(request.Id);
            if (location != null)
            {
                location.IsDeleted = true;
                await _locationManager.UpdateAsync(location);
                return new DeleteLocationCommandResponse { Success = true };
            }
            return new DeleteLocationCommandResponse { Success = false, Message = "Not Found" };
        }
    }
}
