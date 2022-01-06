import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import * as carsService from '../../Services/CarsService';

const Create = () => {
    const [makes, SetMakes] = useState([]);
    const [models, SetModels] = useState([]);

    useEffect(() => {
        carsService.getMakes()
            .then(result => {
                SetMakes(result);
                console.log(result)
            });
    }, []);

    const history = useHistory();

    const onCarCreate = (e) => {
        e.preventDefault();
        let formData = new FormData(e.currentTarget);

        fetch('cars', {
            method: 'POST',
            body: formData
        })
            .then(res => {
                history.push('/cars/all');
            })
    }

    const onSelectType = (e) => {

        let models = makes.find(x => x.id === e.target.value).models;

        SetModels(models);
    }

    return (
        <form id='create-form' onSubmit={onCarCreate} method="POST">
            <fieldset>
                <div className='field form-el form-title'>
                    Add new<span className="color-b">Car</span>
                </div>
                <div className="field form-el">
                    <label htmlFor="makeId">Makes</label>
                    <span className="input">
                        <select id="makeId" name="makeId" className="custom-select" onChange={onSelectType}>
                            <option key='1'>Select make.</option>
                            {makes.length > 0
                                ? makes.map(x => <option key={x.id} value={x.id}>{x.name}</option>)
                                : <option key='1'>No makes yet</option>
                            }
                        </select>
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="modelId">Makes</label>
                    <span className="input">
                        <select id="modelId" name="modelId" className="custom-select">
                            <option key='1'>Select model.</option>
                            {models.length > 0
                                ? models.map(x => <option key={x.id} value={x.id}>{x.name}</option>)
                                : <option key='2'>Select make first.</option>
                            }
                        </select>
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="ownerName">OwnerName</label>
                    <span className="input">
                        <input type="text" name="ownerName" id="ownerName" placeholder="OwnerName" />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="registrationPlate">RegistrationPlate</label>
                    <span className="input">
                        <input type="text" name="registrationPlate" id="registrationPlate" placeholder="RegistrationPlate" />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="color">Color</label>
                    <span className="input">
                        <input type="text" name="color" id="color" placeholder="Color" />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="cubicCapacity">CubicCapacity</label>
                    <span className="input">
                        <input type="number" name="cubicCapacity" id="cubicCapacity" placeholder="CubicCapacity" />
                    </span>
                </div>
                <div className="field form-el">
                    <label htmlFor="horsePower">HorsePower</label>
                    <span className="input">
                        <input type="number" name="horsePower" id="horsePower" placeholder="HorsePower" />
                    </span>
                </div>
                <div className='field form-el'>
                    <input className="button submit btns" type="submit" value="Add Car" />
                </div>
            </fieldset>
        </form>
    );
}

export default Create;
