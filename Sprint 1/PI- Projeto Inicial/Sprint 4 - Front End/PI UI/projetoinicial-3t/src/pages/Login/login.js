import {useState, useEffect} from 'react'
import axios from 'axios'
import { parseJwt } from '../../services/auth'
import { Redirect } from 'react-router'

function Login(){
    const [email, setEmail] = useState('')
    const [senha, setSenha] = useState('') 

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

                switch(parseJwt().role)
                {
                    case '1':
                        window.location.replace("http://localhost:3000/cadastrousuarios")
                    break;

                    case '2':
                        window.location.replace("/cadastroequipamento")
                    break;    
                }
            }
        })
        .catch(erro => {
            console.log(erro)
        })

    }

        return(
            <div>
                <form onSubmit={efetuaLogin}>
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
                </form>
            </div>
        )
    
}

export default Login;