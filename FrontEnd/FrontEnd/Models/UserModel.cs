namespace FrontEnd.Models;
public class UserModel
{
    public int Id { get; set; }
    public int Legajo { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly FechaNac { get; set; }
    public static UserModel SearchUser(int id)
    {
        List<UserModel> list = new List<UserModel>();

        list.Add(new UserModel()
        {
            Id = 1,
            Legajo = 1,
            Name = "Maxi",
            Surname = "Pintos",
            FechaNac = new DateOnly(1998, 06, 04)
        });

        list.Add(new UserModel()
        {
            Id = 2,
            Legajo = 2,
            Name = "Mauro",
            Surname = "Bernal",
            FechaNac = new DateOnly(1993, 06, 04)
        });

        list.Add(new UserModel()
        {
            Id = 3,
            Legajo = 3,
            Name = "Joaquin",
            Surname = "Rosa",
            FechaNac = new DateOnly(1997, 06, 04)
        });

        list.Add(new UserModel()
        {
            Id = 4,
            Legajo = 4,
            Name = "Mauro",
            Surname = "Sosa",
            FechaNac = new DateOnly(1995, 06, 04)
        });

        return list.Where(w => w.Id == id).FirstOrDefault();
        //return list.Single(s => s.Id == id);
    }
}

