export interface CreateUser {
    firstName: string;
    lastName: string;
    username: string;
    password: string;
    confirmPassword: string;
    role: number;
}