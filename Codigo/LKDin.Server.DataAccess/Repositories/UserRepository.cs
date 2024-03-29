﻿using LKDin.Server.Domain;
using LKDin.Server.IDataAccess.Repositories;

namespace LKDin.Server.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            DataManager.AddDataToStore<User>(user);

            return user;
        }

        public bool Exists(string id)
        {
            return DataManager.Users.Any(u => u.Id.Equals(id));
        }

        public User? Get(string id)
        {
            return DataManager.Users.Find(u => u.Id.Equals(id));
        }

        public User Update(User user)
        {
            DataManager.UpdateDataFromStore<User>(user);

            return user;
        }

        public void Delete(User user)
        {
            DataManager.DeleteDataFromStore<User>(user);

            var chatMessageRepository = new ChatMessageRepository();

            chatMessageRepository.DeleteChatMessagesByUserId(user.Id);

            var workProfileRepository = new WorkProfileRepository();

            workProfileRepository.DeleteWorkProfileByUserId(user.Id);
        }
    }
}
