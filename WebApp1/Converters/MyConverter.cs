using Newtonsoft.Json;
using WebApp1.Models;

namespace WebApp1.Converters
{
    public class ModelConverter
    {

        public BackUser? UserToOut(User user)
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

            } catch
            {
                return null;

            }

          

        
               

        }

        public User? OutToUser(BackUser user)
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
            } catch
            {

                return null;    
            }
         

           

        }

        public string? ModelToString<T>(T? model)


        {
            if (model is null)
                return null;

            if (model is User)
            {

                return JsonConvert.SerializeObject(model);


            }

            if (model is BackUser)
            {

                return JsonConvert.SerializeObject(model);
            }

            return null;

        }

        public BackUser? UsertoOutUpdate(User user)
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
