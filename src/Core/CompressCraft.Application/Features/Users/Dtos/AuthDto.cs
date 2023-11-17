namespace CompressCraft.Application.Features.Users.Dtos;

public record AuthDto(string UserId, string UserName, string AccessToken, long Expires);
