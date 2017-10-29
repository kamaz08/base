export interface IPersonalData {
    FirstName: String,
    LastName: String,
    BirthDate: Date,
    Pesel: String,
    PhoneNumber: String,
    City: String,
    State: String,
    Street: String,
    ZipCode: String,
    HouseNumber: String,
    FlatNumber: String
}

export interface IPublicProfile {
    ShowFirstName: boolean,
    ShowLastName: boolean,
    ShowBirthDate: boolean,
    ShowPhoneNumber: boolean,
    ShowEmail: boolean,
    Education: String,
    Description: String
}

export interface IChangePassword {
    OldPassword: String;
    Password: String,
    ConfirmPassword: String,
}

export interface IChangeEmail {
    Email: string
}

export interface IPublicData {
    Login: String,
    FirstName: String
    LastName: String,
    BirthDate: String,
    PhoneNumber: String,
    Email: string,
    Education: String[],
    Description: String[]
}