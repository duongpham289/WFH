using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;

namespace MISA.CukCuk.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseEntityController<Position>
    {
        #region DECLARE

        IPositionService _positionService;
        #endregion

        #region Constructor
        public PositionsController(IPositionService positionService, IBaseRepository<Position> baseRepository) : base(positionService, baseRepository)
        {
            _positionService = positionService;
        }
        #endregion
    }
}
