using System;

namespace dotnetAPI.Data
{
	public class AuthRepository : IAuthRepository
	{
		public AuthRepository()
		{
		}

        public Task<ServiceResponse<string>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

