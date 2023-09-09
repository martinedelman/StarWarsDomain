using Microsoft.EntityFrameworkCore;
using starwars.Domain;
using starwars.Exceptions;
using starwars.IDataAccess;

namespace starwars.DataAccess;
public class CharacterManagment : GenericRepository<Character>
{
    public CharacterManagment(DbContext context)
    {
        Context = context;
    }
}

