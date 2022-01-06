import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <Link to={'/create'} className="link-a">Create</Link>
                <Link to={'/cars/all'} className="link-a">All cars</Link>
            </div>
        );
    }
}
