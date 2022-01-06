import React, { useEffect, useState } from 'react';
import Car from './Car';
import * as carsService from '../../Services/CarsService';
import MakeSelector from './MakeSelector';

const AllCars = ({ match, }) => {

    const [cars, SetCars] = useState([]);

    useEffect(() => {
        carsService.getAll(match.params.make)
            .then(result => {
                SetCars(result);
            });
    }, [match.params.make]);

    return (
        <div>
            <div>All cars</div>
            <MakeSelector />

            {cars.length > 0
                ? cars.map(x => <Car key={x.id} car={x} />)
                : <h3>No cars yet.</h3>
            }
        </div>
    );
};

export default AllCars;
