export class User {
    constructor(
        id,
        surname,
        familyName,
        dateOfBirth
    ) {
        this.id = id;
        this.surname = surname;
        this.familyName = familyName;
        this.dateOfBirth = dateOfBirth;
    }

    static from(json) {
        return Object.assign(new User(), json);
    }
}