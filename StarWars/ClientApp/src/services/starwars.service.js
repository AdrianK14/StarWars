import config from "../config.json";

export const starWarsService = {
    fetchHeroInfo,
};

async function fetchHeroInfo(heroName) {
    return await sendRequest(`heroes/${heroName}`, { method: "GET" });
}

async function sendRequest(url, options) {
    var response = await fetch(`${config.SERVER_URL}${url}`, options);
    if (response.ok) {
        return response.json();
    }
    return Promise.reject(`${response.status}:${response.statusText})`);
}
