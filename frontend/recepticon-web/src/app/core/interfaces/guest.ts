export interface Guest {
    id: number;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    address: string;
    roomId: number;
    checkIn: Date;
    checkOut: Date;
}