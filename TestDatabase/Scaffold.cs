using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabaseSqlite.Entities;

namespace TestDatabaseSqlite
{
    public static class Scaffold
    {
        public static IEnumerable<MembershipType> ScaffoldMembershipTypes()
        {
            return new List<MembershipType>()
            {
                new MembershipType
                {
                    Id = 1,
                    DisplayText = "Mon - Wed",
                    DayFrom = (int)DayOfWeek.Monday,
                    DayTo = (int)DayOfWeek.Wednesday,
                },
                new MembershipType
                {
                    Id = 2,
                    DisplayText = "Wed - Fri",
                    DayFrom = (int)DayOfWeek.Wednesday,
                    DayTo = (int)DayOfWeek.Friday,
                },
                new MembershipType
                {
                    Id = 3,
                    DisplayText = "Sat - Sun",
                    DayFrom = (int)DayOfWeek.Saturday,
                    DayTo = (int)DayOfWeek.Sunday,
                },
            };
        }

        public static IEnumerable<Member> ScaffoldDefaultMembers()
        {
            var members = new List<Member>();
            var rnd = new Random();

            var memId = Guid.NewGuid();
            var memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "John",
                Surname = "Doe",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code  = rnd.Next(1000,9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 1
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Steven",
                Surname = "Bottle",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 1
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Jane",
                Surname = "Doe",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 1
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Lian",
                Surname = "Dell",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 2
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Sue",
                Surname = "Pen",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 2
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Zeke",
                Surname = "Sign",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 2
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Homer",
                Surname = "Simpson",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 3
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Billy",
                Surname = "Bob",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 3
            });

            memId = Guid.NewGuid();
            memNum = rnd.Next(10000, 99999);

            members.Add(new Member
            {
                Id = memId,
                DateOfBirth = DateTime.Now.AddDays(-rnd.Next(6570, 21900)),
                FirstName = "Lucy",
                Surname = "Saniz",
                MembershipNumber = memNum,
                AccessInformation = new AccessInformation
                {
                    Code = rnd.Next(1000, 9999),
                    UpdatedDate = DateTime.Now
                },
                MembershipTypeId = 3
            });

            return members;
        }
    }
}
