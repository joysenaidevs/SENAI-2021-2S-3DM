import {useState} from 'react'
import axios from 'axios'
import { parseJwt } from '../../services/auth'
import { useHistory } from 'react-router'
import Header from '../../Components/header/header'
import './login.css'
import Helmet  from 'react-helmet'

function Login(){
    const [email, setEmail] = useState('')
    const [senha, setSenha] = useState('') 
    const history = useHistory()
    function efetuaLogin(event){
        event.preventDefault()
        axios.post('http://localhost:5000/api/login', {
            email : email,
            senha : senha
        })
        
        .then(resposta => {
            if(resposta.status === 200){
                localStorage.setItem("usuario-login", resposta.data.token)
                console.log('Token : '+ resposta.data.token)
                console.log(parseJwt())

                if(parseJwt().role === "1"){
                    history.push('/cadastrarusuario')
                } else if(parseJwt().role === "2"){
                    history.push('/cadastrarequipamento')
                }

                
               
            }
        })
        .catch(erro => {
            console.log(erro)
        })

    }

        return(
            <div className="bodyLgn">
                <Helmet>
                    <title>SM - Login</title>
                </Helmet>
                {/* <form onSubmit={efetuaLogin}>
                    <h2>Login:</h2>
                    <input
                        placeholder="email"
                        name="email"
                        type="text"
                        value={email}
                        onChange={(event) => {setEmail(event.target.value)}}
                    />
                    <input
                        placeholder="senha"
                        name="senha"
                        type="text"
                        value={senha}
                        onChange={(event) => {setSenha(event.target.value)}}
                    /> 
                    <button
                        type="submit"
                    >
                        Login
                    </button>
                </form> */}
                <main>
                    <section class="login">
                        <h1>LOGIN</h1>
                        <form onSubmit={efetuaLogin} class="form">
                            <div class="item">
                                <input
                                    class="inputLogin"
                                    placeholder="Email"
                                    type="email"
                                    name="username"
                                    id="loginEmail"
                                    value={email}
                                    onChange={(event) => {setEmail(event.target.value)}}
                                />
                            </div>

                            <div class="item">
                                <input
                                    class="inputLogin"
                                    placeholder="Senha"
                                    type="password"
                                    name="password"
                                    id="loginPassword"
                                    value={senha}
                                    onChange={(event) => {setSenha(event.target.value)}}
                                />
                            </div>

                            <div class="item">
                                <button class="btn_login" id="btnLogin" type="submit">
                                    Login
                                </button>
                            </div>
                        </form>
                    </section>
                </main>
            </div>
        )
    
}

export default Login;