import React, { useEffect, useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import * as carsService from '../../Services/CarsService';

const CarDetails = ({ match, }) => {

    const [car, SetCar] = useState({});

    const history = useHistory();

    useEffect(() => {
        carsService.getCarById(match.params.carId)
            .then(res => {
                SetCar(res);
            });
    }, [match.params.carId]);

    const onDelete = () => {

        carsService.deleteCar(car.id)
            .then(res => {
                history.push('/cars/all');
            })
    }

    return (
        <div className="col-md-4">
            <div>{car.makeName}</div>
            <div>{car.modelName}</div>
            <div>{car.ownerName}</div>
            <div>{car.cubicCapacity}</div>
            <div>{car.horsePower}</div>
            <div>{car.color}</div>
            <div>{car.registrationPlate}</div>
            <Link to={`/edit/${car.id}`} className="link-a" >Edit</Link>
            <button className="link-a delete-btn" onClick={onDelete} >Delete</button>
        </div>
        )
}

export default CarDetails;
