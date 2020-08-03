export class ServiceResponceGeneric<T> {
    code: ServiseResponceCode;
    data: T;
    message: string;
}

export class ServiceResponceNonGeneric {
    code: ServiseResponceCode;
    message: string;
}

export enum ServiseResponceCode {
    Ok = 0,
    Warning = 1,
    Error = 2
}