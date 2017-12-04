export interface IOrder {
    Name: String,
    Rate: String,
    NumberOfEmploye: Number,
    Category: String,
    State: String,
    City: String,
    Street: String,
    ResultDate: Date,
    WorkDate: Date,
    EmployerName: String,
    EmployerId: String,
    Description: String,
    ExecutionTime: String,
    Requirements: String
}

export interface IOrderDisplay {
    Id: Number,
    Name: String,
    Rate: String,
    NumberOfEmploye: Number,
    Category: String,
    State: String,
    City: String,
    Street: String,
    ResultDate: Date,
    WorkDate: Date,
    EmployerName: String,
    EmployerId: String,
    Description: String[],
    ExecutionTime: String,
    Requirements: String[]
    IsOpen: boolean;
}

export enum OrderOwnerEnum {
    Author = 0,
    Candidate = 1,
    Customer = 2,
    Guest = 3
}