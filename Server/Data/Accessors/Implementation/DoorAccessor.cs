using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Accessors.Implementation
{
    public class DoorAccessor : AccessorBase<Door>, IDoorAccessor
    {
        public DoorAccessor(HomeContext context) : base(context.Doors, context) { }

        public override async Task<Door> FindAsync(Expression<Func<Door, Boolean>> filter)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .Join(_context.Rooms, door => door.RoomId, room => room.Id,
                (door, room) => new Door
                {
                    Id = door.Id,
                    Pin = door.Pin,
                    RemovedDate = door.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).FirstOrDefaultAsync();
        }
        public override async Task<IList<Door>> GetAsync()
        {
            return await _data.Join(_context.Rooms, 
                door => door.RoomId, 
                room => room.Id,
                (door, room) => new Door
                {
                    Id = door.Id,
                    Pin = door.Pin,
                    RemovedDate = door.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).AsNoTracking().ToListAsync();
        }

        public override async Task<IList<Door>> GetAsync(Expression<Func<Door, Boolean>> filter = null)
        {
            return await _data.AsNoTracking()
                .Where(filter)
                .Join(_context.Rooms,
                door => door.RoomId,
                room => room.Id,
                (door, room) => new Door
                {
                    Id = door.Id,
                    Pin = door.Pin,
                    RemovedDate = door.RemovedDate,
                    RoomId = room.Id,
                    Room = room
                }).ToListAsync();
        }
    }
}