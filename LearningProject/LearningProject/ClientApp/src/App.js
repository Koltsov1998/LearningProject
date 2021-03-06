import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Memes } from './components/Memes';

import './custom.css'
import { GravitySimulation } from './components/GravitySimulation';
import Publics from './components/publicsComponent';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/gravity' component={GravitySimulation} />
        <Route path='/publics' component={Publics} />
        <Route path='/processedmemes' component={Memes} />
        
      </Layout>
    );
  }
}
