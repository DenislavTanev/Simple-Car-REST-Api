import React from 'react';
import { Link } from 'react-router-dom';

const Car = ({ car, }) => {

    return (
        <div className="col-md-4">
            <Link to={`/car/${car.id}`} className="link-a">Check</Link>
            <div>{car.makeName}</div>
            <div>{car.modelName}</div>
            <div>{car.ownerName}</div>
            <div>{car.cubicCapacity}</div>
            <div>{car.horsePower}</div>
            <div>{car.color}</div>
            <div>{car.registrationPlate}</div>
        </div>
    );
};

export default Car;