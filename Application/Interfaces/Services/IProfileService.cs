using Application.DTOs.Base;
using Application.DTOs.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProfileService
    {
        ProfileDetailsDto GetProfileDetails();

        bool UpdateProfileDetails(ProfileDetailsDto profileDetails);

        bool DeleteProfile();

        bool ChangePassword(ChangePasswordDto changePassword);

        ResponseDto<object> ResetPassword(string emailAddress);
    }
}
