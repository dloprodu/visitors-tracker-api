using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorsTracker.BLL.Services;
using VisitorsTracker.Models;

namespace VisitorsTracker.BLL.BusinessLogic
{
    public class RegisterGuestInput: ActionInput
    {
        public Guest guest { get; set; }
    }

    public class RegisterGuestManager : BaseActionManager<RegisterGuestInput, Task<Guest>>
    {

        private IGuestService _service;

        public RegisterGuestManager(IGuestService service, RegisterGuestInput input): base(input)
        {
            _service = service;
        }

        public override Task<Guest> DoAction()
        {
            return _service.CreateAsync(this._input.guest);
        }
    }
}
