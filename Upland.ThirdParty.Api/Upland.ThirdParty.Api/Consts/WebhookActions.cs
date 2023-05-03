namespace Upland.ThirdParty.Api.Consts
{
    public static class WebhookActions
    {
        public const string AuthenticationSuccess = "AuthenticationSuccess";
        public const string UserDisconnectedApplication = "UserDisconnectedApplication";

        public const string TransactionToEscrowRejected = "TransactionToEscrowRejected";
        public const string TransactionToEscrowCreated = "TransactionToEscrowCreated";
        public const string TransactionToEscrowFailure = "TransactionToEscrowFailure";
        public const string TransactionToEscrowSigned = "TransactionToEscrowSigned";
        public const string TransactionToEscrowFinal = "TransactionToEscrowFinal";
        public const string TransactionToEscrowExpired = "TransactionToEscrowExpired";

        public const string TransactionFromEscrowCreated = "TransactionFromEscrowCreated";
        public const string TransactionFromEscrowFailure = "TransactionFromEscrowFailure";
        public const string TransactionFromEscrowFinal = "TransactionFromEscrowFinal";

        public const string ContainerExpired = "ContainerExpired";
    }
}
}
