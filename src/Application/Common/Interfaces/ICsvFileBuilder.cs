using QuriWasi.Application.Rooms.Queries.ExportRoom;
using QuriWasi.Application.RoomsType.Queries.ExportRoomType;
using QuriWasi.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace QuriWasi.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
        byte[] BuildRoomItemFile(IEnumerable<RoomItemRecord> records);
        byte[] BuildRoomTypeItemFile(IEnumerable<RoomTypeItemRecord> records);
    }
}
