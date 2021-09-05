import React, { useState, useEffect } from "react";
import { Table } from "./Table";
import { starWarsService } from "../services/starwars.service";
import { Select } from "./Select";

export function HeroDashboard(props) {
    const [hero, setHero] = useState("Luke Skywalker");
    const [heroInfo, setHeroInfo] = useState(null);

    const selectOptions = [
        { label: "Luke Skywalker", value: 1 },
        { label: "C-3PO", value: 2 },
        { label: "R2-D2", value: 3 },
        { label: "Darth Vader", value: 4 },
        { label: "Owen Lars", value: 5 },
        { label: "Beru Whitesun lars", value: 6 },
        { label: "R5-D4", value: 7 },
        { label: "Biggs Darklighter", value: 8 },
        { label: "Obi-Wan Kenobi", value: 9 },
    ];

    const getHeroInfo = (heroName) => {
        starWarsService.fetchHeroInfo(heroName).then((data) => {
            setHeroInfo(data);
        });
    };

    useEffect(() => {
        getHeroInfo(hero);
    }, []);

    const onHeroChange = (event) => {
        setHeroInfo(null);
        setHero(event.target.value);
        getHeroInfo(event.target.value);
    };

    return (
        <div>
            <Select
                label="Choose hero:"
                id="hero"
                value={hero}
                options={selectOptions}
                onChange={onHeroChange}
            />

            {heroInfo == null ? (
                <p>Loading...</p>
            ) : (
                <>
                    <Table
                        size="sm"
                        title="Films"
                        headers={[
                            "title",
                            "episode_id",
                            "director",
                            "producer",
                            "release_date",
                        ]}
                        data={heroInfo.films}
                    />
                    <Table
                        size="sm"
                        title="Vehicles"
                        headers={[
                            "name",
                            "model",
                            "manufacturer",
                            "length",
                            "crew",
                            "passengers",
                        ]}
                        data={heroInfo.vehicles}
                    />
                    <Table
                        size="sm"
                        title="Starships"
                        headers={[
                            "name",
                            "model",
                            "manufacturer",
                            "length",
                            "crew",
                            "passengers",
                        ]}
                        data={heroInfo.starships}
                    />
                </>
            )}
        </div>
    );
}
