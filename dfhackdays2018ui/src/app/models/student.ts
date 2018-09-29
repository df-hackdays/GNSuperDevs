

export class Student {

    constructor(
        public studentId: string,
        public firstName: string,
        public lastName: string,
        public email: string,
        public birthday: Date,
        public gender: string,
        public profession: string,
        public aspirations: string[],
        public signUpDate: Date
    ) { }

}
