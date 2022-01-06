import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import * as carsService from '../../Services/CarsService';

const Edit = ({ match, }) => {

    const [car, SetCar] = useState(
        {
            id: '',
            ownerName: '',
            registrationPlate: '',
            color: '',
            cubicCapacity: '',
            horsePower: '',
        }
    );

    const handleChange = e => {
        const { name, value } = e.target;
        SetCar(prevState => ({
            ...prevState,
            [name]: value
        }));
        console.log(car)
    };

    useEffect(() => {
        carsService.getCarById(match.params.carId)
            .then(res => {
                SetCar(res);
            });
    }, [match.params.carId,]);

    const history = useHistory();

    const onCarEdit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        fetch('cars', {
            method: 'PUT',
            body: formData
        })
            .then(res => {
                history.push(`/car/${car.id}`);
            });
    }

    return (
        <form id='edit-form' onSubmit={onCarEdit} method="PUT">
            <fieldset>
                <div className='field form-el form-title'>
                    Edit<span className="color-b">Car</span>
                </div>
                
                <div className="field form-el">
                    <label htmlFor="ownerName">OwnerName</label>
                    <span className="input">
                        <input type="text" name="ownerName" id="ownerName" value={car.ownerName} onChange={handleChange} />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="registrationPlate">RegistrationPlate</label>
                    <span className="input">
                        <input type="text" name="registrationPlate" id="registrationPlate" value={car.registrationPlate} onChange={handleChange} />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="color">Color</label>
                    <span className="input">
                        <input type="text" name="color" id="color" value={car.color} onChange={handleChange} />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="cubicCapacity">CubicCapacity</label>
                    <span className="input">
                        <input type="number" name="cubicCapacity" id="cubicCapacity" value={car.cubicCapacity} onChange={handleChange} />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="horsePower">HorsePower</label>
                    <span className="input">
                        <input type="number" name="horsePower" id="horsePower" value={car.horsePower} onChange={handleChange} />
                    </span>
                </div>
                <div className='field form-el'>
                    <input type='text' name='Id' id='Id' defaultValue={car.id} hidden />
                </div>
                <div className='field form-el'>
                    <input className="button submit btns" type="submit" value="Update" />
                </div>
            </fieldset>
        </form>
    );
}

export default Edit;
