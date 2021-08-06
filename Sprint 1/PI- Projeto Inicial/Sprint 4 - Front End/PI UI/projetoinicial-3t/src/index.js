import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './pages/home/App';
import Usuario from './pages/Usuario/usuario'
import Equipamento from './pages/Equipamentos/equipamento'
import Sala from './pages/Sala/Sala'
import notFound from './pages/notFound/notFound'
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom' ;
import Login from './pages/Login/login';



const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route exact path="/home" component={App} />
        <Route exact path="/cadastrarusuario" component={Usuario} />
        <Route exact path="/cadastrarequipamento" component={Equipamento} />
        <Route exact path="/cadastrarsala" component={Sala} />
        <Route exact path="/notfound" component={notFound} />

        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>
)


ReactDOM.render(routing,document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
