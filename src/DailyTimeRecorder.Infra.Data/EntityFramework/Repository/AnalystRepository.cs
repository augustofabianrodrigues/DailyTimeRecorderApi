using DailyTimeRecorder.Domain.Interfaces;
using DailyTimeRecorder.Domain.Models;
using DailyTimeRecorder.Infra.Data.EntityFramework.Context;

namespace DailyTimeRecorder.Infra.Data.EntityFramework.Repository
{
    public sealed class AnalystRepository : Repository<Analyst>, IAnalystRepository
    {
        public AnalystRepository(
            DailyTimeRecorderContext context) : base(context)
        {
        }
    }
}
