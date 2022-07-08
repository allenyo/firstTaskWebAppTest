using api1Domain.Interfaces;
using api1Domain.Models;

namespace api1Service
{
    internal class ModelConverter : IModelConverter
    {
        public User? BackToUser(BackUser user)
        {
            try
            {
                var nuser = new User
                {
                    Id = user.Id,
                    FullName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Time = user.Time,
                    BirthDay = user.BirthMonth + "/" + user.BirthDay + "/" + user.BirthYear
                };
                return nuser;
            }
            catch
            {

                return null;
            }

        }

        public BackUser? UserToBack(User user)
        {
            try
            {
                var birth = user.BirthDay.Split(new char[] { '/', ' ', '.' });


                var userToOut = new

                    BackUser
                {
                    Id = user.Id,
                    FirstName = user.FullName.Split(" ").First(),
                    LastName = user.FullName.Split(" ").Last(),
                    Email = user.Email,
                    Phone = user.Phone,
                    BirthYear = birth.ElementAt(2),
                    BirthMonth = birth.ElementAt(1),
                    BirthDay = birth.ElementAt(0),
                    Time = user.Time,

                };

                return userToOut;

            }
            catch
            {
                return null;

            }

        }

        public BackUser? UserToBackUpdate(User user)
        {
            try
            {


                try
                {
                    var birth = user.BirthDay.Split(new char[] { '/', ' ', '.' });

                    if (birth.ElementAt(1).Contains('0'))
                    {
                        birth[1] = birth[1][1..];

                    }

                    if (birth.ElementAt(0).Contains('0'))
                    {
                        birth[0] = birth[0][1..];

                    }


                    var userToOut = new

                        BackUser
                    {
                        Id = user.Id,
                        FirstName = user.FullName.Split(" ").First(),
                        LastName = user.FullName.Split(" ").Last(),
                        Email = user.Email,
                        Phone = user.Phone,
                        BirthYear = birth.ElementAt(2),
                        BirthMonth = birth.ElementAt(1),
                        BirthDay = birth.ElementAt(0),
                        Time = user.Time,

                    };

                    return userToOut;

                }
                catch
                {

                    var userToOut = new

                   BackUser
                    {
                        Id = user.Id,
                        FirstName = user.FullName.Split(" ").First(),
                        LastName = user.FullName.Split(" ").Last(),
                        Email = user.Email,
                        Phone = user.Phone,
                        Time = user.Time,

                    };

                    return userToOut;

                }

            }
            catch
            {
                return null;

            }
        }
    }
}
