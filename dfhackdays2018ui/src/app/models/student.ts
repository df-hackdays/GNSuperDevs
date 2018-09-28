import { Interest } from './interest';

export interface Student {
    studentId: string;
    firstName: string;
    lastName: string;
    email: string;
    birthday: Date;
    gender: string;
    interests: Interest[];
}
