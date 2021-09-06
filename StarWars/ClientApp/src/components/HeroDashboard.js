import React, { useState, useEffect } from "react";
import { Table } from "./Table";
import { starWarsService } from "../services/starwars.service";

export function HeroDashboard(props) {

    const [heroInfo, setHeroInfo] = useState(null);

    useEffect(() => {
        starWarsService.fetchHeroInfo(props.hero).then((data) => {
            setHeroInfo(data);
        });
    }, [props.hero]);

    return (
        <>
            {heroInfo == null ? (
                <h4>Loading...</h4>
            ) : (
                <>
                    <Table
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
        </>
    );
}
