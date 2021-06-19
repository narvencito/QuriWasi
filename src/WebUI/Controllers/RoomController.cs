using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuriWasi.Application.Rooms.Queries.GetAll;
using QuriWasi.Application.Rooms.Queries.ExportRoom;
using QuriWasi.Application.Rooms.Commands.CreateRoom;
using QuriWasi.Application.Rooms.Commands.UpdateRoom;
using QuriWasi.Application.Rooms.Commands.DeleteRoom;

namespace QuriWasi.Controllers
{
    //[Authorize]
    public class RoomController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<RoomVm>> Get()
        {
            return await Mediator.Send(new GetRoomsQuery());
        }

        [HttpGet(("Images"))]
        public async Task<ActionResult<RoomImageVm>> GetImages()
        {
            return await Mediator.Send(new GetRoomsImagesQuery());
        }

        [HttpGet("Excel/{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportRoomsQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRoomCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRoomCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }
    }
}
