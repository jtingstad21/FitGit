using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Linq;

namespace final_app
{
    class Helper
    {
        public FirebaseClient myfirebase = new FirebaseClient("https://fitgit-e60fb.firebaseio.com/");

        public async Task<List<User>> GetAllPersons()
        {

            return (await myfirebase
              .Child("Persons")
              .OnceAsync<User>()).Select(item => new User
              {
                  set = item.Object.Name,
                  PersonId = item.Object.PersonId
              }).ToList();
        }
    }
}
