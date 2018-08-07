namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;
        public AddFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AddFriend <username1> <username2>                 
        public string Execute(string[] data)
        {
            string username = data[0];
            string friendUsername = data[1];
            var userExist = this.userService.Exists(username);
            var friendExists = this.userService.Exists(friendUsername);

            if (!userExist)
            {
                throw new ArgumentException($"{username} not found!");
            }
            if (!friendExists)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            bool isSendRequestFromUser = user.Friends.Any(x => x.Username == friend.Username);
            bool isSendRequestFromFriend = friend.Friends.Any(x => x.Username == user.Username);

            if (isSendRequestFromUser && isSendRequestFromFriend)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }

            else if (isSendRequestFromUser && !isSendRequestFromFriend)
            {
                throw new InvalidOperationException("Request is already send!");
            }
            else if (!isSendRequestFromFriend && isSendRequestFromUser)
            {
                throw new InvalidOperationException("Request is already send!");
            }

            this.userService.AddFriend(user.Id, friend.Id);

            return $"Friend {friend.Username} added to {user.Username}";
        }
    }
}
