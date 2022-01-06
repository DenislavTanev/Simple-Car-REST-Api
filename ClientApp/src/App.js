import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'
import Create from './components/Cars/Create';
import AllCars from './components/Cars/AllCars';
import CarDetails from './components/Cars/CarDetails';
import Edit from './components/Cars/Edit';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetch-data' component={FetchData} />
                <Route path='/create' component={Create} />
                <Route path='/cars/:make' component={AllCars} />
                <Route path='/car/:carId' component={CarDetails} />
                <Route path='/edit/:carId' component={Edit} />
            </Layout>
        );
    }
}
