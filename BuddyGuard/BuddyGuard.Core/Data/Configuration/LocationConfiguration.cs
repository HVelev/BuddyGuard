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
            builder.HasData(new Location()
            {
                Id = 1, Name = "Абдовица",
                PriceId = 1
            },
            new Location()
            {
                Id = 2, Name = "Банишора",
                PriceId = 1
            },
            new Location()
            {
                Id = 3, Name = "Барите",
                PriceId = 1
            },
            new Location()
            {
                Id = 4, Name = "Белите брези",
                PriceId = 1
            },
            new Location()
            {
                Id = 5, Name = "Бенковски",
                PriceId = 1
            },
            new Location()
            {
                Id = 6, Name = "Бизнес парк София",
                PriceId = 1
            },
            new Location()
            {
                Id = 7, Name = "Бокар",
                PriceId = 1
            },
            new Location()
            {
                Id = 8, Name = "Борово",
                PriceId = 1
            },
            new Location()
            {
                Id = 9, Name = "Ботунец",
                PriceId = 1
            },
            new Location()
            {
                Id = 10, Name = "Бояна",
                PriceId = 1
            },
            new Location()
            {
                Id = 11, Name = "Бункера",
                PriceId = 1
            },
            new Location()
            {
                Id = 12, Name = "Бъкстон",
                PriceId = 1
            },
            new Location()
            {
                Id = 13, Name = "Витоша",
                PriceId = 1
            },
            new Location()
            {
                Id = 14, Name = "Владимир Заимов",
                PriceId = 1
            },
            new Location()
            {
                Id = 15, Name = "Враждебна",
                PriceId = 1
            },
            new Location()
            {
                Id = 16, Name = "Връбница",
                PriceId = 1
            },
            new Location()
            {
                Id = 17, Name = "Връбница-1",
                PriceId = 1
            },
            new Location()
            {
                Id = 18, Name = "Връбница-2",
                PriceId = 1
            },
            new Location()
            {
                Id = 19, Name = "Гевгелийски квартал",
                PriceId = 1
            },
            new Location()
            {
                Id = 20, Name = "Гео Милев",
                PriceId = 1
            },
            new Location()
            {
                Id = 21, Name = "Горна баня",
                PriceId = 1
            },
            new Location()
            {
                Id = 22, Name = "Горубляне",
                PriceId = 1
            },
            new Location()
            {
                Id = 23, Name = "Гоце Делчев",
                PriceId = 1
            },
            new Location()
            {
                Id = 24, Name = "Дианабад",
                PriceId = 1
            },
            new Location()
            {
                Id = 25, Name = "Димитър Миленков",
                PriceId = 1
            },
            new Location()
            {
                Id = 26, Name = "Драгалевци",
                PriceId = 1
            },
            new Location()
            {
                Id = 27, Name = "Драз махала",
                PriceId = 1
            },
            new Location()
            {
                Id = 28, Name = "Дружба",
                PriceId = 1
            },
            new Location()
            {
                Id = 29, Name = "Дървеница",
                PriceId = 1
            },
            new Location()
            {
                Id = 30, Name = "Западен парк",
                PriceId = 1
            },
            new Location()
            {
                Id = 31, Name = "Захарна фабрика",
                PriceId = 1
            },
            new Location()
            {
                Id = 32, Name = "Зона Б-18",
                PriceId = 1
            },
            new Location()
            {
                Id = 33, Name = "Зона Б-19",
                PriceId = 1
            },
            new Location()
            {
                Id = 34, Name = "Зона Б-5-3",
                PriceId = 1
            },
            new Location()
            {
                Id = 35, Name = "Иван Вазов",
                PriceId = 1
            },
            new Location()
            {
                Id = 36, Name = "Изгрев",
                PriceId = 1
            },
            new Location()
            {
                Id = 37, Name = "Изток",
                PriceId = 1
            },
            new Location()
            {
                Id = 38, Name = "Илинден",
                PriceId = 1
            },
            new Location()
            {
                Id = 39, Name = "Илиянци",
                PriceId = 1
            },
            new Location()
            {
                Id = 40, Name = "Киноцентър",
                PriceId = 1
            },
            new Location()
            {
                Id = 41, Name = "Княжево",
                PriceId = 1
            },
            new Location()
            {
                Id = 42, Name = "Красна поляна",
                PriceId = 1
            },
            new Location()
            {
                Id = 43, Name = "Красно село",
                PriceId = 1
            },
            new Location()
            {
                Id = 44, Name = "Кремиковци",
                PriceId = 1
            },
            new Location()
            {
                Id = 45, Name = "Крива река",
                PriceId = 1
            },
            new Location()
            {
                Id = 46, Name = "Кръстова вада",
                PriceId = 1
            },
            new Location()
            {
                Id = 47, Name = "Кюлуците",
                PriceId = 1
            },
            new Location()
            {
                Id = 48, Name = "Лагера",
                PriceId = 1
            },
            new Location()
            {
                Id = 49, Name = "Лев Толстой",
                PriceId = 1
            },
            new Location()
            {
                Id = 50, Name = "Левски",
                PriceId = 1
            },
            new Location()
            {
                Id = 51, Name = "Лозенец",
                PriceId = 1
            },
            new Location()
            {
                Id = 52, Name = "Люлин",
                PriceId = 1
            },
            new Location()
            {
                Id = 53, Name = "Малашевци",
                PriceId = 1
            },
            new Location()
            {
                Id = 54, Name = "Малинова долина",
                PriceId = 1
            },
            new Location()
            {
                Id = 55, Name = "Манастирски ливади",
                PriceId = 1
            },
            new Location()
            {
                Id = 56, Name = "Младост",
                PriceId = 1
            },
            new Location()
            {
                Id = 57, Name = "Младост 1А",
                PriceId = 1
            },
            new Location()
            {
                Id = 58, Name = "Младост 2",
                PriceId = 1
            },
            new Location()
            {
                Id = 59, Name = "Младост 3",
                PriceId = 1
            },
            new Location()
            {
                Id = 60, Name = "Младост 4",
                PriceId = 1
            },
            new Location()
            {
                Id = 61, Name = "Модерно преградие",
                PriceId = 1
            },
            new Location()
            {
                Id = 62, Name = "Момкова махала",
                PriceId = 1
            },
            new Location()
            {
                Id = 63, Name = "Мотописта",
                PriceId = 1
            },
            new Location()
            {
                Id = 64, Name = "Мусагеница",
                PriceId = 1
            },
            new Location()
            {
                Id = 65, Name = "Надежда",
                PriceId = 1
            },
            new Location()
            {
                Id = 66, Name = "Обеля",
                PriceId = 1
            },
            new Location()
            {
                Id = 67, Name = "Оборище",
                PriceId = 1
            },
            new Location()
            {
                Id = 68, Name = "Овча Купел",
                PriceId = 1
            },
            new Location()
            {
                Id = 69, Name = "Овча Купел 1",
                PriceId = 1
            },
            new Location()
            {
                Id = 70, Name = "Овча Купел 2",
                PriceId = 1
            },
            new Location()
            {
                Id = 71, Name = "Орландовци",
                PriceId = 1
            },
            new Location()
            {
                Id = 72, Name = "Павлово",
                PriceId = 1
            },
            new Location()
            {
                Id = 73, Name = "Павлово",
                PriceId = 1
            },
            new Location()
            {
                Id = 74, Name = "Подуяне",
                PriceId = 1
            },
            new Location()
            {
                Id = 75, Name = "Полигона",
                PriceId = 1
            },
            new Location()
            {
                Id = 76, Name = "Разсадника-Коньовица",
                PriceId = 1
            },
            new Location()
            {
                Id = 77, Name = "Редута",
                PriceId = 1
            },
            new Location()
            {
                Id = 78, Name = "Република",
                PriceId = 1
            },
            new Location()
            {
                Id = 79, Name = "Света Троица",
                PriceId = 1
            },
            new Location()
            {
                Id = 80, Name = "Свобода",
                PriceId = 1
            },
            new Location()
            {
                Id = 81, Name = "Сердика",
                PriceId = 1
            },
            new Location()
            {
                Id = 82, Name = "Сеславци",
                PriceId = 1
            },
            new Location()
            {
                Id = 83, Name = "Симеоново",
                PriceId = 1
            },
            new Location()
            {
                Id = 84, Name = "Славия",
                PriceId = 1
            },
            new Location()
            {
                Id = 85, Name = "Слатина",
                PriceId = 1
            },
            new Location()
            {
                Id = 86, Name = "Стефан Караджа",
                PriceId = 1
            },
            new Location()
            {
                Id = 87, Name = "Стрелбище",
                PriceId = 1
            },
            new Location()
            {
                Id = 88, Name = "Студентски град",
                PriceId = 1
            },
            new Location()
            {
                Id = 89, Name = "Сухата река",
                PriceId = 1
            },
            new Location()
            {
                Id = 90, Name = "Суходол",
                PriceId = 1
            },
            new Location()
            {
                Id = 91, Name = "Требич",
                PriceId = 1
            },
            new Location()
            {
                Id = 92, Name = "Триъгълника",
                PriceId = 1
            },
            new Location()
            {
                Id = 93, Name = "Факултета",
                PriceId = 1
            },
            new Location()
            {
                Id = 94, Name = "Филиповци",
                PriceId = 1
            },
            new Location()
            {
                Id = 95, Name = "Фондови жилища",
                PriceId = 1
            },
            new Location()
            {
                Id = 96, Name = "Хаджи Димитър",
                PriceId = 1
            },
            new Location()
            {
                Id = 97, Name = "Хиподрума",
                PriceId = 1
            },
            new Location()
            {
                Id = 98, Name = "Хладилника",
                PriceId = 1
            },
            new Location()
            {
                Id = 99, Name = "Христо Ботев",
                PriceId = 1
            },
            new Location()
            {
                Id = 100, Name = "Цариградски комплекс",
                PriceId = 1
            },
            new Location()
            {
                Id = 101, Name = "Център",
                PriceId = 1
            },
            new Location()
            {
                Id = 102, Name = "Челопечене",
                PriceId = 1
            },
            new Location()
            {
                Id = 103, Name = "Чепинско шосе",
                PriceId = 1
            },
            new Location()
            {
                Id = 104, Name = "Южен парк",
                PriceId = 1
            },
            new Location()
            {
                Id = 105, Name = "Ючбунар",
                PriceId = 1
            },
            new Location()
            {
                Id = 106, Name = "Яворов",
                PriceId = 1
            });
        }
    }
}
