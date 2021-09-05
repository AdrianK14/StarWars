import config from "../configuration.json";

export const starWarsService = {
    fetchHeroInfo,
};

function fetchHeroInfo(heroName) {
    return sendRequest(`person/${heroName}`, { method: "GET" });
}

function sendRequest(url, options) {
    var response = fetch(`${config.SERVER_URL}${url}`, options);
    if (response.ok) {
        return response.json();
    }
    return Promise.reject(`${response.status}:${response.statusText})`);
}
