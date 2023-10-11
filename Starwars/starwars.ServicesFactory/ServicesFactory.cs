﻿using starwars.BusinessLogic;
using starwars.DataAccess;
using starwars.IDataAccess;
using Microsoft.Extensions.DependencyInjection;
using starwars.IBusinessLogic;
using starwars.Domain;
using Microsoft.EntityFrameworkCore;

namespace starwars.ServicesFactory;

public class ServicesFactory
{

    public ServicesFactory() { }

    public void RegistrateServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DbContext, StarwarsContext>();
        serviceCollection.AddScoped<IGenericRepository<Character>, CharacterManagment>();
        serviceCollection.AddScoped<IGenericRepository<Session>, SessionManagment>();
        serviceCollection.AddScoped<IGenericRepository<User>, UserManagement>();
                    
        // Lo hago scoped ya que este manager maneja estado, tiene el currentUser
        serviceCollection.AddScoped<ISessionService, SessionService>();
        serviceCollection.AddScoped<ICharacterService, CharacterService>();
        serviceCollection.AddScoped<IForceCalculator, ForceCalculator>();
        serviceCollection.AddScoped<IForceCalcStrategy, JediStrategy>();
        serviceCollection.AddScoped<IForceCalcStrategy, SithStrategy>();
        serviceCollection.AddScoped<IPersonalityQuestion, PersonalityQuestionnaire>();
    }
}
