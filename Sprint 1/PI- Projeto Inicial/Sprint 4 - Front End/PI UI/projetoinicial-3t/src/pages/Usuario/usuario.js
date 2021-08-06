import { useEffect, useState } from "react";
import axios from 'axios'

function Usuario(){
    const[nome, setNome] = useState('')
    const[senha, setSenha] = useState('')
    const[email, setEmail] = useState('')

    const[listaUsuarios, setListaUsuarios] = useState([])

    function cadastrarUsuario(event){
        event.preventDefault();

        axios.post('http://localhost:5000/api/usuario', {
                nome : nome,
                email: email,
                senha : senha
            }, {
                headers : {
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            }

            .then( resposta => {
                if(resposta.status === 200){
                    setListaUsuarios(resposta.data)
                    console.log('Usuário cadastrado')
                }
            })

            .catch((error) => console.log(error))
    )}
}
export default Usuario;