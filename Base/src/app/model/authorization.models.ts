export interface IRegistrationUser {
    UserName: string,
    Password: string,
    ConfirmPassword: string,
    Email: string
}

export interface IToken {
    Content: string,
    Authorization: string
}

export interface ILogin {
    grant_type: string,
    username: string,
    password: string,
    otpkey: string
}