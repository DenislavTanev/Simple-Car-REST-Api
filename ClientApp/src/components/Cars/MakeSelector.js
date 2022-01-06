import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import * as carsService from '../../Services/CarsService';

const MakeSelector = () => {
    const [makes, SetMakes] = useState([]);

    useEffect(() => {
        carsService.getMakes()
            .then(result => {
                SetMakes(result);
            });
    }, []);

    const history = useHistory();

    const onSelectMake = (e) => {
        history.push(`/cars/${e.target.value}`);
    }

    return (
        <div className="col-sm-12">
            <div className="grid-option">
                <form>
                    <select className="custom-select" onChange={onSelectMake}>
                        <option key="all" value="all">All</option>
                        {makes.length > 0
                            ? makes.map(x => <option key={x.id} value={x.name}>{x.name}</option>)
                            : <option key='1'>No makes yet</option>
                        }
                    </select>
                </form>
            </div>
        </div>
        )
}

export default MakeSelector;
