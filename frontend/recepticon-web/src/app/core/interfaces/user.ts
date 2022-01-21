import { Role } from "./role";

export interface User {
    firstName: string;
    lastName: string;
    id: number;
    username: string;
    isDeleted: boolean;
    role: Role;
}