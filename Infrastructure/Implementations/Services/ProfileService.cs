using Application.DTOs.Base;
using Application.DTOs.Email;
using Application.DTOs.Profile;
using Application.Interfaces.GenericRepo;
using Application.Interfaces.Services;
using Entities.Constants;
using Entities.Models;
using Entities.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Infrastructure.Implementations.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IGenericRepository _genericRepository;

        public ProfileService(IUserService userService, IEmailService emailService, IGenericRepository genericRepository)
        {
            _userService = userService;
            _emailService = emailService;
            _genericRepository = genericRepository;
        }

        public ProfileDetailsDto GetProfileDetails()
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var role = _genericRepository.GetById<Role>(user.RoleId);

            var result = new ProfileDetailsDto()
            {
                UserId = user.Id,
                FullName = user.FullName,
                Username = user.UserName,
                EmailAddress = user.EmailAddress,
                RoleId = role.Id,
                RoleName = role.Name,
                ImageURL = user.ImageURL ?? "sample-profile.png",
                MobileNumber = user.MobileNo ?? ""
            };

            return result;
        }

        public bool UpdateProfileDetails(ProfileDetailsDto profileDetails)
        {
            var user = _genericRepository.GetById<User>(profileDetails.UserId);

            user.FullName = profileDetails.FullName;

            user.MobileNo = profileDetails.MobileNumber;

            user.ImageURL = profileDetails.ImageURL;

            user.UserName = profileDetails.Username;

            _genericRepository.Update(user);

            return true;
        }

        public bool DeleteProfile()
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var blogs = _genericRepository.Get<Blog>(x => x.CreatedBy == user.Id);

            var blogImages = _genericRepository.Get<BlogImage>(x => blogs.Select(z => z.Id).Contains(x.BlogId));

            var comments = _genericRepository.Get<Comment>(x => x.CreatedBy == user.Id);

            var reactions = _genericRepository.Get<Reaction>(x => x.CreatedBy == user.Id);

            _genericRepository.RemoveMultipleEntity(reactions);

            _genericRepository.RemoveMultipleEntity(comments);

            _genericRepository.RemoveMultipleEntity(blogImages);

            _genericRepository.RemoveMultipleEntity(blogs);

            _genericRepository.Delete(user);

            return true;
        }

        public bool ChangePassword(ChangePasswordDto changePassword)
        {
            var userId = _userService.UserId;

            var user = _genericRepository.GetById<User>(userId);

            var isValid = Password.VerifyHash(changePassword.CurrentPassword, user.Password);

            if (isValid)
            {
                user.Password = Password.HashSecret(changePassword.NewPassword);

                _genericRepository.Update(user);

                return true;
            }

            return false;

        }

        public ResponseDto<object> ResetPassword(string emailAddress)
        {
            var user = _genericRepository.GetFirstOrDefault<User>(x => x.EmailAddress == emailAddress);

            if (user == null)
            {
                return new ResponseDto<object>()
                {
                    Message = "User not found",
                    StatusCode = HttpStatusCode.BadRequest,
                    TotalCount = 1,
                    Status = "Invalid",
                    Data = false
                };
            }

            const string newPassword = Constants.Passwords.BloggerPassword;

            var message =
                $"Hello {user.FullName}, <br><br> " +
                $"This is to inform you that your password has been successfully reset as per your request. " +
                $"Your new password is {newPassword}.<br><br>" +
                $"Best regards,<br>" +
                $"Bislerium.";

            var email = new EmailDto()
            {
                Email = user.EmailAddress,
                Message = message,
                Subject = "Reset Password - Bislerium"
            };

            _emailService.SendEmail(email);

            return new ResponseDto<object>()
            {
                Message = "Successfully Updated",
                StatusCode = HttpStatusCode.OK,
                TotalCount = 1,
                Status = "Success",
                Data = true
            };
        }

    }
}
