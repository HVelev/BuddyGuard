using BuddyGuard.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
        }

        public List<Location> CreateLocations()
        {
            return new List<Location>()
            {
                new Location()
            {
                Id = 1, Name = "Абдовица",
                Price = 4.99M
            },
            new Location()
            {
                Id = 2, Name = "Банишора",
                Price = 4.99M
            },
            new Location()
            {
                Id = 3, Name = "Барите",
                Price = 4.99M
            },
            new Location()
            {
                Id = 4, Name = "Белите брези",
                Price = 4.99M
            },
            new Location()
            {
                Id = 5, Name = "Бенковски",
                Price = 4.99M
            },
            new Location()
            {
                Id = 6, Name = "Бизнес парк София",
                Price = 4.99M
            },
            new Location()
            {
                Id = 7, Name = "Бокар",
                Price = 4.99M
            },
            new Location()
            {
                Id = 8, Name = "Борово",
                Price = 4.99M
            },
            new Location()
            {
                Id = 9, Name = "Ботунец",
                Price = 4.99M
            },
            new Location()
            {
                Id = 10, Name = "Бояна",
                Price = 4.99M
            },
            new Location()
            {
                Id = 11, Name = "Бункера",
                Price = 4.99M
            },
            new Location()
            {
                Id = 12, Name = "Бъкстон",
                Price = 4.99M
            },
            new Location()
            {
                Id = 13, Name = "Витоша",
                Price = 4.99M
            },
            new Location()
            {
                Id = 14, Name = "Владимир Заимов",
                Price = 4.99M
            },
            new Location()
            {
                Id = 15, Name = "Враждебна",
                Price = 4.99M
            },
            new Location()
            {
                Id = 16, Name = "Връбница",
                Price = 4.99M
            },
            new Location()
            {
                Id = 17, Name = "Връбница-1",
                Price = 4.99M
            },
            new Location()
            {
                Id = 18, Name = "Връбница-2",
                Price = 4.99M
            },
            new Location()
            {
                Id = 19, Name = "Гевгелийски квартал",
                Price = 4.99M
            },
            new Location()
            {
                Id = 20, Name = "Гео Милев",
                Price = 4.99M
            },
            new Location()
            {
                Id = 21, Name = "Горна баня",
                Price = 4.99M
            },
            new Location()
            {
                Id = 22, Name = "Горубляне",
                Price = 4.99M
            },
            new Location()
            {
                Id = 23, Name = "Гоце Делчев",
                Price = 4.99M
            },
            new Location()
            {
                Id = 24, Name = "Дианабад",
                Price = 4.99M
            },
            new Location()
            {
                Id = 25, Name = "Димитър Миленков",
                Price = 4.99M
            },
            new Location()
            {
                Id = 26, Name = "Драгалевци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 27, Name = "Драз махала",
                Price = 4.99M
            },
            new Location()
            {
                Id = 28, Name = "Дружба",
                Price = 4.99M
            },
            new Location()
            {
                Id = 29, Name = "Дървеница",
                Price = 4.99M
            },
            new Location()
            {
                Id = 30, Name = "Западен парк",
                Price = 4.99M
            },
            new Location()
            {
                Id = 31, Name = "Захарна фабрика",
                Price = 4.99M
            },
            new Location()
            {
                Id = 32, Name = "Зона Б-18",
                Price = 4.99M
            },
            new Location()
            {
                Id = 33, Name = "Зона Б-19",
                Price = 4.99M
            },
            new Location()
            {
                Id = 34, Name = "Зона Б-5-3",
                Price = 4.99M
            },
            new Location()
            {
                Id = 35, Name = "Иван Вазов",
                Price = 4.99M
            },
            new Location()
            {
                Id = 36, Name = "Изгрев",
                Price = 4.99M
            },
            new Location()
            {
                Id = 37, Name = "Изток",
                Price = 4.99M
            },
            new Location()
            {
                Id = 38, Name = "Илинден",
                Price = 4.99M
            },
            new Location()
            {
                Id = 39, Name = "Илиянци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 40, Name = "Киноцентър",
                Price = 4.99M
            },
            new Location()
            {
                Id = 41, Name = "Княжево",
                Price = 4.99M
            },
            new Location()
            {
                Id = 42, Name = "Красна поляна",
                Price = 4.99M
            },
            new Location()
            {
                Id = 43, Name = "Красно село",
                Price = 4.99M
            },
            new Location()
            {
                Id = 44, Name = "Кремиковци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 45, Name = "Крива река",
                Price = 4.99M
            },
            new Location()
            {
                Id = 46, Name = "Кръстова вада",
                Price = 4.99M
            },
            new Location()
            {
                Id = 47, Name = "Кюлуците",
                Price = 4.99M
            },
            new Location()
            {
                Id = 48, Name = "Лагера",
                Price = 4.99M
            },
            new Location()
            {
                Id = 49, Name = "Лев Толстой",
                Price = 4.99M
            },
            new Location()
            {
                Id = 50, Name = "Левски",
                Price = 4.99M
            },
            new Location()
            {
                Id = 51, Name = "Лозенец",
                Price = 4.99M
            },
            new Location()
            {
                Id = 52, Name = "Люлин",
                Price = 4.99M
            },
            new Location()
            {
                Id = 53, Name = "Малашевци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 54, Name = "Малинова долина",
                Price = 4.99M
            },
            new Location()
            {
                Id = 55, Name = "Манастирски ливади",
                Price = 4.99M
            },
            new Location()
            {
                Id = 56, Name = "Младост 1",
                Price = 4.99M
            },
            new Location()
            {
                Id = 57, Name = "Младост 1А",
                Price = 4.99M
            },
            new Location()
            {
                Id = 58, Name = "Младост 2",
                Price = 4.99M
            },
            new Location()
            {
                Id = 59, Name = "Младост 3",
                Price = 4.99M
            },
            new Location()
            {
                Id = 60, Name = "Младост 4",
                Price = 4.99M
            },
            new Location()
            {
                Id = 61, Name = "Модерно преградие",
                Price = 4.99M
            },
            new Location()
            {
                Id = 62, Name = "Момкова махала",
                Price = 4.99M
            },
            new Location()
            {
                Id = 63, Name = "Мотописта",
                Price = 4.99M
            },
            new Location()
            {
                Id = 64, Name = "Мусагеница",
                Price = 4.99M
            },
            new Location()
            {
                Id = 65, Name = "Надежда",
                Price = 4.99M
            },
            new Location()
            {
                Id = 66, Name = "Обеля",
                Price = 4.99M
            },
            new Location()
            {
                Id = 67, Name = "Оборище",
                Price = 4.99M
            },
            new Location()
            {
                Id = 68, Name = "Овча Купел",
                Price = 4.99M
            },
            new Location()
            {
                Id = 69, Name = "Овча Купел 1",
                Price = 4.99M
            },
            new Location()
            {
                Id = 70, Name = "Овча Купел 2",
                Price = 4.99M
            },
            new Location()
            {
                Id = 71, Name = "Орландовци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 72, Name = "Павлово",
                Price = 4.99M
            },
            new Location()
            {
                Id = 73, Name = "Панчарево",
                Price = 4.99M
            },
            new Location()
            {
                Id = 74, Name = "Подуяне",
                Price = 4.99M
            },
            new Location()
            {
                Id = 75, Name = "Полигона",
                Price = 4.99M
            },
            new Location()
            {
                Id = 76, Name = "Разсадника-Коньовица",
                Price = 4.99M
            },
            new Location()
            {
                Id = 77, Name = "Редута",
                Price = 4.99M
            },
            new Location()
            {
                Id = 78, Name = "Република",
                Price = 4.99M
            },
            new Location()
            {
                Id = 79, Name = "Света Троица",
                Price = 4.99M
            },
            new Location()
            {
                Id = 80, Name = "Свобода",
                Price = 4.99M
            },
            new Location()
            {
                Id = 81, Name = "Сердика",
                Price = 4.99M
            },
            new Location()
            {
                Id = 82, Name = "Сеславци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 83, Name = "Симеоново",
                Price = 4.99M
            },
            new Location()
            {
                Id = 84, Name = "Славия",
                Price = 4.99M
            },
            new Location()
            {
                Id = 85, Name = "Слатина",
                Price = 4.99M
            },
            new Location()
            {
                Id = 86, Name = "Стефан Караджа",
                Price = 4.99M
            },
            new Location()
            {
                Id = 87, Name = "Стрелбище",
                Price = 4.99M
            },
            new Location()
            {
                Id = 88, Name = "Студентски град",
                Price = 4.99M
            },
            new Location()
            {
                Id = 89, Name = "Сухата река",
                Price = 4.99M
            },
            new Location()
            {
                Id = 90, Name = "Суходол",
                Price = 4.99M
            },
            new Location()
            {
                Id = 91, Name = "Требич",
                Price = 4.99M
            },
            new Location()
            {
                Id = 92, Name = "Триъгълника",
                Price = 4.99M
            },
            new Location()
            {
                Id = 93, Name = "Факултета",
                Price = 4.99M
            },
            new Location()
            {
                Id = 94, Name = "Филиповци",
                Price = 4.99M
            },
            new Location()
            {
                Id = 95, Name = "Фондови жилища",
                Price = 4.99M
            },
            new Location()
            {
                Id = 96, Name = "Хаджи Димитър",
                Price = 4.99M
            },
            new Location()
            {
                Id = 97, Name = "Хиподрума",
                Price = 4.99M
            },
            new Location()
            {
                Id = 98, Name = "Хладилника",
                Price = 4.99M
            },
            new Location()
            {
                Id = 99, Name = "Христо Ботев",
                Price = 4.99M
            },
            new Location()
            {
                Id = 100, Name = "Цариградски комплекс",
                Price = 4.99M
            },
            new Location()
            {
                Id = 101, Name = "Център",
                Price = 4.99M
            },
            new Location()
            {
                Id = 102, Name = "Челопечене",
                Price = 4.99M
            },
            new Location()
            {
                Id = 103, Name = "Чепинско шосе",
                Price = 4.99M
            },
            new Location()
            {
                Id = 104, Name = "Южен парк",
                Price = 4.99M
            },
            new Location()
            {
                Id = 105, Name = "Ючбунар",
                Price = 4.99M
            },
            new Location()
            {
                Id = 106, Name = "Яворов",
                Price = 4.99M
            }
            };
        }
    }
}
