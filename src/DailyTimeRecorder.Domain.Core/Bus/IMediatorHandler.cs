using DailyTimeRecorder.Domain.Core.Commands;
using DailyTimeRecorder.Domain.Core.Events;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
