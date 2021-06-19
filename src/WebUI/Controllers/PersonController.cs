using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuriWasi.Application.Persons.Queries.GetAll;
using QuriWasi.Application.Persons.Queries.ExportPerson;
using QuriWasi.Application.Persons.Commands.CreatePerson;
using QuriWasi.Application.Persons.Commands.UpdatePerson;
using QuriWasi.Application.Persons.Commands.DeletePerson;

namespace QuriWasi.Controllers
{
    //[Authorize]
    public class PersonController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PersonVm>> Get()
        {
            return await Mediator.Send(new GetPersonsQuery());
        }

        [HttpGet("Excel/{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportPersonsQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePersonCommand command)
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
            await Mediator.Send(new DeletePersonCommand { Id = id });

            return NoContent();
        }
    }
}
