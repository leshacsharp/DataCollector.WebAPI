using DataCollector.WebAPI.Models.Api;
using DataCollector.WebAPI.Models.Dto;
using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using LinqKit;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContext _db;
        public UserService(IDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetByIdAsync(string userId)
        {
            var id = new ObjectId(userId);
            var user = await _db.Users.AsQueryable()
                                .AsExpandable()
                                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public Task<List<UserDto>> GetAsync(UserFilterModel filterModel)
        {
            var filter = PredicateBuilder.New<User>(u => true);
            #region expressions

            if (!string.IsNullOrEmpty(filterModel.CommonInfo.FirstName))
            {
                filter = filter.And(u => u.CommonInfo.FirstName.ToLower().Contains(filterModel.CommonInfo.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.CommonInfo.LastName))
            {
                filter = filter.And(u => u.CommonInfo.LastName.ToLower().Contains(filterModel.CommonInfo.LastName.ToLower()));
            }

            if (filterModel.CommonInfo.Gender != Gender.Unknown)
            {
                filter = filter.And(u => u.CommonInfo.Gender == filterModel.CommonInfo.Gender);
            }

            if (!filterModel.CommonInfo.WithoutAge)
            {
                filter = filter.And(u => u.CommonInfo.Age.HasValue && u.CommonInfo.Age.Value >= filterModel.CommonInfo.FromAge);
                filter = filter.And(u => u.CommonInfo.Age.HasValue && u.CommonInfo.Age.Value <= filterModel.CommonInfo.ToAge);
            }

            if (!string.IsNullOrEmpty(filterModel.CommonInfo.Country))
            {
                filter = filter.And(u => u.CommonInfo.Country.ToLower().Contains(filterModel.CommonInfo.Country.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.CommonInfo.City))
            {
                filter = filter.And(u => u.CommonInfo.City.ToLower().Contains(filterModel.CommonInfo.City.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.Contacts.MobilePhone))
            {
                filter = filter.And(u => u.Contacts.MobilePhone.Contains(filterModel.Contacts.MobilePhone));
            }

            if (!string.IsNullOrEmpty(filterModel.Education.Country))
            {
                filter = filter.And(u => u.Education.Any(ev => ev.Country.ToLower().Contains(filterModel.Education.Country.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Education.City))
            {
                filter = filter.And(u => u.Education.Any(ev => ev.City.ToLower().Contains(filterModel.Education.City.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Education.EducationalInstitution))
            {
                filter = filter.And(u => u.Education.Any(ev => ev.EducationalInstitution.ToLower().Contains(filterModel.Education.EducationalInstitution.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Education.Speciality))
            {
                filter = filter.And(u => u.Education.Any(ev => ev.Speciality.ToLower().Contains(filterModel.Education.Speciality.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Career.Country))
            {
                filter = filter.And(u => u.Career.Any(ev => ev.Country.ToLower().Contains(filterModel.Career.Country.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Career.City))
            {
                filter = filter.And(u => u.Career.Any(ev => ev.City.ToLower().Contains(filterModel.Career.City.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Career.Position))
            {
                filter = filter.And(u => u.Career.Any(ev => ev.Position.ToLower().Contains(filterModel.Career.Position.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Career.PlaceOfWork))
            {
                filter = filter.And(u => u.Career.Any(ev => ev.Position.ToLower().Contains(filterModel.Career.PlaceOfWork.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.LifePositions.WorldView))
            {
                filter = filter.And(u => u.LifePositions.WorldView.ToLower().Contains(filterModel.LifePositions.WorldView.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.LifePositions.MainInLife))
            {
                filter = filter.And(u => u.LifePositions.MainInLife.ToLower().Contains(filterModel.LifePositions.MainInLife.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.LifePositions.MainInPeople))
            {
                filter = filter.And(u => u.LifePositions.MainInPeople.ToLower().Contains(filterModel.LifePositions.MainInPeople.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.LifePositions.PositionToSigarets))
            {
                filter = filter.And(u => u.LifePositions.PositionToSigarets.ToLower().Contains(filterModel.LifePositions.PositionToSigarets.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.LifePositions.PositionToAlhocol))
            {
                filter = filter.And(u => u.LifePositions.PositionToAlhocol.ToLower().Contains(filterModel.LifePositions.PositionToAlhocol.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.Activity.Book))
            {
                filter = filter.And(u => u.Activities.Books.Any(b => b.ToLower().Contains(filterModel.Activity.Book.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Activity.Film))
            {
                filter = filter.And(u => u.Activities.Films.Any(f => f.ToLower().Contains(filterModel.Activity.Film.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Activity.Game))
            {
                filter = filter.And(u => u.Activities.Games.Any(b => b.ToLower().Contains(filterModel.Activity.Game.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Activity.Music))
            {
                filter = filter.And(u => u.Activities.Musics.Any(b => b.ToLower().Contains(filterModel.Activity.Music.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Activity.Hoobie))
            {
                filter = filter.And(u => u.Activities.Hoobies.Any(b => b.ToLower().Contains(filterModel.Activity.Hoobie.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Interest.TypeOfBook))
            {
                filter = filter.And(u => u.Interests.TypesOfMusic.Any(b => b.ToLower().Contains(filterModel.Interest.TypeOfBook.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Interest.TypeOfFilm))
            {
                filter = filter.And(u => u.Interests.TypesOfFilms.Any(b => b.ToLower().Contains(filterModel.Interest.TypeOfFilm.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Interest.TypeOfGame))
            {
                filter = filter.And(u => u.Interests.TypesOfGames.Any(b => b.ToLower().Contains(filterModel.Interest.TypeOfGame.ToLower())));
            }

            if (!string.IsNullOrEmpty(filterModel.Interest.TypeOfMusiс))
            {
                filter = filter.And(u => u.Interests.TypesOfMusic.Any(b => b.ToLower().Contains(filterModel.Interest.TypeOfMusiс.ToLower())));
            }

            #endregion

            var query = _db.Users.AsQueryable()
                                 .AsExpandable()
                                 .Where(filter)
                                 .Select(u => new UserDto()
                                 {
                                     Id = u.Id,
                                     FirstName = u.CommonInfo.FirstName,
                                     LastName = u.CommonInfo.LastName,
                                     Age = u.CommonInfo.Age,
                                     City = u.CommonInfo.City,
                                     MobilePhone = u.Contacts.MobilePhone,
                                     Email = u.Contacts.Email,
                                     Vk = u.Contacts.Vk
                                 });

            return query.ToListAsync();
        }
    }
}
