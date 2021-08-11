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
import { parseJwt, usuarioAutenticado } from './services/auth';

const PermissaoAdm = ({ component : Component  }) => (
  <Route 
    render = { props =>
      // Verifica se o usuário está logado e se é Administrador
      usuarioAutenticado() && parseJwt().role === "1" || usuarioAutenticado() && parseJwt().role === "2"  ? 
      // Se sim, renderiza de acordo com a rota solicitada e permitida
      <Component {...props} /> : 
      // Se não, redireciona para a página de login
      <Redirect to = '/' />
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <PermissaoAdm exact path="/home" component={App} />
        <PermissaoAdm  exact path="/cadastrarusuario" component={Usuario} />
        <PermissaoAdm  exact path="/cadastrarequipamento" component={Equipamento} />
        <PermissaoAdm  exact path="/cadastrarsala" component={Sala} />
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
