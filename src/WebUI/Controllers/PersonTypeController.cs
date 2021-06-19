using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuriWasi.Application.PersonsType.Queries.GetAll;
using QuriWasi.Application.PersonsType.Queries.ExportPersonType;
using QuriWasi.Application.PersonsType.Commands.CreatePersonType;
using QuriWasi.Application.PersonsType.Commands.UpdatePersonType;
using QuriWasi.Application.PersonsType.Commands.DeletePersonType;

namespace QuriWasi.Controllers
{
    //[Authorize]
    public class PersonTypeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PersonTypeVm>> Get()
        {
            return await Mediator.Send(new GetPersonsTypeQuery());
        }

        [HttpGet("Excel/{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportPersonsTypeQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePersonTypeCommand command)
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
            await Mediator.Send(new DeletePersonTypeCommand { Id = id });

            return NoContent();
        }
    }
}
