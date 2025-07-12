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

        for (let i = 0; i < user.milestones.length; i++) {
            let milestone = user.milestones[i];
            milestone.start = this._toCustomFormat(milestone.start, milestone.startOption, 'de');
            milestone.end = this._toCustomFormat(milestone.end, milestone.endOption, 'de');
        };

        //need to do some additional parsing here for milestone descriptions specifically
        return user;
    }

    static _toCustomFormat(dateStr, option, locale) {
        if (!dateStr) { return dateStr; }
        let split = dateStr.split('-');

        if (locale == 'de') {
            if (option == 0) { return split[2] + '.' + split[1] + '.' + split[0]; }
            else if (option == 1) { return this._getMonth(split[1]) + ' ' + split[0]; }
            else if (option == 2) { return split[0]; }
        }
        else {
            if (option == 0) { return split[0] + '/' + split[1] + '/' + split[2]; }
            else if (option == 1) { return split[0] + '/' + split[1]; }
            else if (option == 2) { return split[0]; }
        }
    }

    static _getMonth(month) {
        switch (parseInt(month)) {
            case 1: return 'Januar';
            case 2: return 'Februar';
            case 3: return 'März';
            case 4: return 'April';
            case 5: return 'Mai';
            case 6: return 'Juni';
            case 7: return 'Juli';
            case 8: return 'August';
            case 9: return 'September';
            case 10: return 'Oktober';
            case 11: return 'November';
            case 12: return 'Dezember';
        }
    }

    static _listAssign(jsonList) {
        let list = [];
        for (let i = 0; i < jsonList.length; i++) {
            list.push(Object.assign(new Object(), jsonList[i]));
        }

        return list;
    }
}