using QuriWasi.Domain.Entities;
using QuriWasi.Domain.ValueObjects;
using QuriWasi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace QuriWasi.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = Colour.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }
            if (!context.PersonType.Any())
            {
                context.PersonType.AddRange(new PersonType
                {
                    Type = "Administrador",
                },
                new PersonType
                {
                    Type = "Asistente",
                },
                new PersonType
                {
                    Type = "Trabajador",
                },
                new PersonType
                {
                    Type = "Cliente",
                }

                );

                await context.SaveChangesAsync();
            }
            if (!context.Person.Any())
            {
                context.Person.AddRange(new Person
                {
                    Name = "Emerson",
                    LastName= "Navarro",
                    Email="email@gmail.com",
                    Phone="51983581221",
                    Address="Direccion",
                    Age=20,
                    PersonTypeId = 1

                },
                new Person
                {
                    Name = "Mario",
                    LastName = "Enríquez",
                    Email = "macer@gmail.com",
                    Phone = "5199999999",
                    Address = "Direccion",
                    Age = 21,
                    PersonTypeId = 2
                },
                new Person
                {
                    Name = "Pavel",
                    LastName = "Tueros",
                    Email = "email@gmail.com",
                    Phone = "51983581221",
                    Address = "Direccion",
                    Age = 22,
                    PersonTypeId = 2
                },
                new Person
                {
                    Name = "Chano",
                    LastName = "Huaman",
                    Email = "email@gmail.com",
                    Phone = "51983581221",
                    Address = "Direccion",
                    Age = 23,
                    PersonTypeId = 3
                }
                );

                await context.SaveChangesAsync();
            }
            if (!context.RoomType.Any())
            {
                context.RoomType.AddRange(new RoomType
                {
                    Type = "Matrimonial",
                    Description = "Habitacion Matrimonial"
                },
                new RoomType
                {
                    Type = "Simple",
                    Description = "Habitacion Simple"
                },
                new RoomType
                {
                    Type = "Doble",
                    Description = "Habitacion Doble"
                }

                );

                await context.SaveChangesAsync();
            }

            if (!context.Room.Any())
            {
                context.Room.AddRange(new Room
                {
                    RoomNumber = 1,
                    RoomCode = "H001",
                    NickName = "Habitacion 1",
                    Description = "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    RoomTypeId=1
                },
                new Room
                {
                    RoomNumber = 2,
                    RoomCode = "H002",
                    NickName = "Habitacion 2",
                    Description = "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    RoomTypeId = 2
                }
                );

                await context.SaveChangesAsync();
            }

            if (!context.Image.Any())
            {
                context.Image.AddRange(new Image
                {
                    Url= "https://www.construyehogar.com/wp-content/uploads/2020/02/Casa-campo-estilo-moderno.jpg",
                    RoomId = 1
                },
                new Image
                {
                    Url = "https://www.construyehogar.com/wp-content/uploads/2020/02/Dise%C3%B1o-casa-en-ladera-560x370.jpg",
                    RoomId = 1
                }
                );

                await context.SaveChangesAsync();
            }

        }
    }
}
