using CompressCraft.Domain.Abstractions.Errors;

namespace CompressCraft.Domain.Users;

public static class UsersErrors
{
    public static class UserErrors
    {
        public static readonly Error UserNameMustBeProvide = new Error(
             $"[{nameof(User)}]",
             "User name must be provide"
        );

        public static readonly Error PasswordMustBeProvide = new Error(
            $"[{nameof(User)}]",
            "Password must be provide"
       );
    }

    public static class PermissionErrors
    {
        public static readonly Error PermissionNameMustBeProvide = new Error(
            $"[{nameof(Permission)}]",
            "Permission name must be provide"
       );
    }
}
