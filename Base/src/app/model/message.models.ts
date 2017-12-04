export interface IPublicMessage {
    Id: Number,
    Name: String,
    OrderId: Number,
    OrderName: String,
    IsReaded: Boolean,
}

export interface IMessage {
    Id: Number,
    Message: String[],
    UserName: String,
    Date: String
}

export interface IPrivateMessageUser {
    UserName: String,
    UserId: String,
    PublicKey: String
}

export interface PrivMess {
    To: String,
    OrderId: Number,
    Message: String
}
