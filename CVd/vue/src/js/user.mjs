export class User {
    constructor(
        id,
        surname,
        familyName,
        dateOfBirth,
        contacts,
        milestones,
        skills,
        decorations
    ) {
        this.id = id;
        this.surname = surname;
        this.familyName = familyName;
        this.dateOfBirth = dateOfBirth;
        this.contacts = contacts;
        this.milestones = milestones;
        this.skills = skills;
        this.decorations = decorations;
    }

    static from(json) {
        let user = Object.assign(new User(), json);
        user.contacts = this._listAssign(user.contacts);
        user.milestones = this._listAssign(user.milestones);
        user.skills = this._listAssign(user.skills);
        user.decorations = this._listAssign(user.decorations);
        user.projects = this._listAssign(user.projects);

        //need to do some additional parsing here for milestone descriptions specifically
        return user;
    }

    static _listAssign(jsonList) {
        let list = [];
        for (let i = 0; i < jsonList.length; i++) {
            list.push(Object.assign(new Object(), jsonList[i]));
        }

        return list;
    }
}