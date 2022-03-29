using System.Linq.Expressions;
using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Accessors.Implementation
{
    public class LightAccessor : AccessorBase<Light>, ILightAccessor
    {
        public LightAccessor(HomeContext context) : base(context.Lights, context) { }

        public override async Task<Light> FindAsync(Expression<Func<Light, Boolean>> filter)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .Join(_context.Rooms, light => light.RoomId, room => room.Id,
                (light, room) => new Light
                {
                    Id = light.Id,
                    Pin = light.Pin,
                    RemovedDate = light.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).FirstOrDefaultAsync();
        }
        public override async Task<IList<Light>> GetAsync()
        {
            return await _data.Join(_context.Rooms, 
                light => light.RoomId, 
                room => room.Id,
                (light, room) => new Light
                {
                    Id = light.Id,
                    Pin = light.Pin,
                    RemovedDate = light.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).AsNoTracking().ToListAsync();
        }

        public override async Task<IList<Light>> GetAsync(Expression<Func<Light, Boolean>> filter = null)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .Join(_context.Rooms,
                light => light.RoomId,
                room => room.Id,
                (light, room) => new Light
                {
                    Id = light.Id,
                    Pin = light.Pin,
                    RemovedDate = light.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).ToListAsync();
        }
    }
}
