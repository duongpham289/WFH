using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repository
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        #region Constructor
        public PositionRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}
