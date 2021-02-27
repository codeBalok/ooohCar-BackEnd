using Microsoft.AspNetCore.Identity;
using System;

namespace Core.Infrastructure.ErrorHandler
{
    public class ErrorHandler : IErrorHandler
    {
        public string ErrorIdentityResult(IdentityResult result)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(ErrorMessagesEnum message)
        {
            switch (message)
            {
                case ErrorMessagesEnum.EntityNull:
                    return "The entity passed is null {0}. Additional information: {1}";

                case ErrorMessagesEnum.ModelValidation:
                    return "The request data is not correct. Additional information: {0}";

                case ErrorMessagesEnum.AuthUserDoesNotExists:
                    return "The user doesn't not exists";

                case ErrorMessagesEnum.AuthWrongCredentials:
                    return "The email or password is wrong";

                case ErrorMessagesEnum.AuthCannotCreate:
                    return "Cannot create user";

                case ErrorMessagesEnum.AuthCannotDelete:
                    return "Cannot delete user";

                case ErrorMessagesEnum.AuthCannotUpdate:
                    return "Cannot update user";

                case ErrorMessagesEnum.AuthNotValidInformations:
                    return "Invalid informations";

                case ErrorMessagesEnum.AuthCannotRetrieveToken:
                    return "Cannot retrieve token";
                case ErrorMessagesEnum.EmailNotVerified:
                    return "Email not confirmed.Please verify your email.";
                case ErrorMessagesEnum.InActiveUser:
                    return "User is no longer active.Please contact your administrator.";
                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }

        }
    }
}
