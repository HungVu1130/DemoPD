using DemoPD.Application.Abstractions.Authentication;
using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.User.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly IPasswordHasher _passwordHasher;
        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenProvider = jwtTokenProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByNameAsync(request.UserName);
            if(user is null)
            {
                return Result.Failure<string>(new Error("Login.InvalidCredentials", "Tai khoan khong ton tai"));
            }
            bool isPasswordValid = _passwordHasher.Verify(request.Password, user.PasswordHash);
            if(!isPasswordValid)
            {
                return Result.Failure<string>(new Error("Login.InvalidCredentials", "Mật khẩu không chính xác."));
            }
            string token = _jwtTokenProvider.Generate(user);
            return Result.Success(token);
        }
    }
}
