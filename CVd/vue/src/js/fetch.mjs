import { User } from './user.mjs'

export async function fuser(host, userId, langCode) {
    var requestUri = host + '/user/' + userId + '/?lang=' + langCode;
    var response = await fetch(requestUri);

    if (response != null) {
        var json = await response.json();
        return User.from(json);
    }
}