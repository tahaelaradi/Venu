import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import HomePage from './pages/HomePage';
import Counter from './components/Counter';
import FetchData from './components/FetchData';


import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={HomePage} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
