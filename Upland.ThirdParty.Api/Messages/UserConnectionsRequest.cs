﻿namespace Upland.ThirdParty.Api.Messages
{
    public class UserConnectionRequest
    {
        public string Type { get; set; }
        public UserConnectionRequestData Data { get; set; }
    }

    public class UserConnectionRequestData
    {
        public long ContainerId { get; set; }
        public string OwnerEOSId { get; set; }
        public Guid TransactionId { get; set; }
        public string Message { get; set; }

        public string Code { get; set; }
        public Guid UserId { get; set; }
        public string AccessToken { get; set; }
    }
}
