using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorsTracker.BLL.Services;
using VisitorsTracker.Models;

namespace VisitorsTracker.BLL.BusinessLogic
{

    public class FetchGuestInput: ActionInput
    {
        public int? offset { get; set; }
        public int? limit { get; set; }
        public string userAgent { get; set; }
        public string platform { get; set; }
        public string language { get; set; }
        public string country { get; set; }
    }

    public class FetchGuestsManager : BaseActionManager<FetchGuestInput, Task<PageResult<Guest>>>
    {

        private IGuestService _service;

        public FetchGuestsManager( IGuestService service, FetchGuestInput input): base(input)
        {
            _service = service;
        }

        public override Task<PageResult<Guest>> DoAction()
        {
            return _service.GetNAsync(
                this._input.limit ?? 10,
                this._input.offset ?? 0,
                this._input.userAgent,
                this._input.platform,
                this._input.language,
                this._input.country
            );
        }
    }
}
