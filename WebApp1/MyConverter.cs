using Newtonsoft.Json;
using WebApp1.Models;

namespace WebApp1
{
    public class ModelConverter
    {

        public BackUser? UserToOut(User user)
        {


            string[]? birth = user.BirthDay.ToString().Split(new char[] { '/'});

            var userToOut = new {
                user.Id, FirstName = user.FullName.Split(" ").FirstOrDefault(), LastName = user.FullName.Split(" ").LastOrDefault(),
                user.Email,
                user.Phone, BirthYear = birth.ElementAtOrDefault(2), BirthMonth = birth.ElementAtOrDefault(1), BirthDay = birth.ElementAtOrDefault(0),
                user.Time

            };

            var json = JsonConvert.SerializeObject(userToOut);
            var backUser = JsonConvert.DeserializeObject<BackUser>(json);

            if (backUser != null)
                return backUser;

            return null;

        }

        public User OutToUser(BackUser user)
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

    }

}
