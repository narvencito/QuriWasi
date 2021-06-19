using QuriWasi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Company> Company { get; set; }
        DbSet<Eventuality> Eventyuality { get; set; }
        DbSet<Image> Image { get; set; }
        DbSet<Person> Person { get; set; }
        DbSet<PersonType> PersonType { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Reservation> Reservation { get; set; }
        DbSet<ReservationStatus> ReservationStatus { get; set; }
        DbSet<Room> Room { get; set; }
        DbSet<RoomDetail> RoomDetail { get; set; }
        DbSet<RoomType> RoomType { get; set; }


        DbSet<TodoList> TodoLists { get; set; }
        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
