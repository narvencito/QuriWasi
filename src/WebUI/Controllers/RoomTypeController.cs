using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuriWasi.Application.RoomsType.Queries.GetAll;
using QuriWasi.Application.RoomsType.Queries.ExportRoomType;
using QuriWasi.Application.RoomsType.Commands.CreateRoomType;
using QuriWasi.Application.RoomsType.Commands.UpdateRoomType;
using QuriWasi.Application.RoomsType.Commands.DeleteRoomType;

namespace QuriWasi.Controllers
{
    //[Authorize]
    public class RoomTypeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<RoomTypeVm>> Get()
        {
            return await Mediator.Send(new GetRoomsTypeQuery());
        }

        [HttpGet("Excel/{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportRoomsTypeQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRoomTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRoomTypeCommand command)
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
            await Mediator.Send(new DeleteRoomTypeCommand { Id = id });

            return NoContent();
        }
    }
}
