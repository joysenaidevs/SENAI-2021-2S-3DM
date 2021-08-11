import { useEffect, useState } from "react";
import axios from 'axios'
import Header from "../../Components/header/header";
import Helmet from 'react-helmet'

function Usuario(){
    const[nome, setNome] = useState('')
    const[senha, setSenha] = useState('')
    const[email, setEmail] = useState('')
    const[idTiposUsuario, setIdTiposUsuario] = useState(0)
    const[idUsuario, setIdUsuario] = useState(0)

    const[listaUsuarios, setListaUsuarios] = useState([])
    const[listaTiposUsuarios, setListaTipoUsuarios] = useState([])

    function buscarUsuarios(){
        axios.get("http://localhost:5000/api/usuario", {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 200){
                setListaUsuarios(resposta.data)
                console.log(listaUsuarios)
            }
        })

        .catch((erro) => {
            console.log(erro)
        })
    }

    function cadastrarUsuario(event){
        event.preventDefault();
            if(idUsuario !==0){
                let atualizar = {
                    nome : nome,
                    email : email,
                    senha : senha,
                    idTiposUsuario : idTiposUsuario
                }
                axios.put('http://localhost:5000/api/usuario/' + idUsuario, atualizar, {
                    headers : {
                        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                    }
                })

                .then(resposta => {
                    if(resposta.status === 202){
                        buscarUsuarios()
                        limparCampos()
                        console.log('usuário atualizado')
                    }
                })

                .catch((erro) => console.log(erro))
            } else {
                let cadastro = {
                    nome : nome,
                    email : email,
                    senha : senha,
                    idTiposUsuario : idTiposUsuario
                }
                    axios.post('http://localhost:5000/api/usuario', cadastro, {
                    headers : {
                        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                    }
                })

                .then( resposta => {
                    if(resposta.status === 201){
                        limparCampos()
                        buscarUsuarios()
                        console.log('Usuário cadastrado')
                    }
                })

                .catch((error) => console.log(error))

            }
                
        }
        
    function buscarIdUsuario(usuario){
                setNome(usuario.nome)
                setEmail(usuario.email)
                setSenha(usuario.senha)
                setIdUsuario(usuario.idUsuario)
                setIdTiposUsuario(usuario.idTiposUsuario)
                console.log('O usuário ' + usuario.idUsuario + ' foi selecionado; O idUsuarioAlterado agora é: '+ usuario.idUsuario)
        }
        
    function excluirUsuario(usuario){
                axios.delete('http://localhost:5000/api/usuario/' + usuario.idUsuario, {
                    headers : {
                        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                    }
                })
                .then(resposta => {
                    if(resposta.status === 204){
                        console.log("O Usuário"+ usuario.idUsuario +" foi excluído")
                        buscarUsuarios()
                    }
                })
                .catch(erro => console.log(erro))
        }

    function buscarTiposUsuarios(){
        axios.get("http://localhost:5000/api/tiposusuario", {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 200){
                setListaTipoUsuarios(resposta.data)
                console.log('Listando tipos')
            }
        })
    }    

    function limparCampos(){
           setNome('')
           setEmail('')
           setSenha('')
           setIdUsuario(0)
           setIdTiposUsuario(0)
        }    

    useEffect(buscarUsuarios, []) 
    useEffect(buscarTiposUsuarios, []) 
    return(
        <div>
            <Helmet>
                    <title>SM - Usuário</title>
            </Helmet>
            <Header />
            <main>
            <section className="sec_1">
                    <div className="content">
                        <div className="titulo-cadastrarEquipamento">
                            <h1>Cadastrar Usuarios</h1>
                            <hr />
                        </div>
                    </div>

                    <form  onSubmit={cadastrarUsuario} className="form content">
                        <div className="grid_1">
                            <input type="text"  value={nome} onChange={(event) => setNome(event.target.value)} name="nome" placeholder="Nome:" class="input watermark" required />
                            <input type="email"  value={email} onChange={(event) => setEmail(event.target.value)} name="email" placeholder="Email:" class="input watermark" required />
                        </div>

                        <div className="grid_1">  
                        <input type="password"  value={senha} onChange={(event) => setSenha(event.target.value)} name="senha" placeholder="Senha:" class="input watermark" required />
                        <select className="select-tipo" name="idTiposUsuario" value={idTiposUsuario} onChange={(event) => setIdTiposUsuario(event.target.value)} required>
                            <option value="0" disabled>---Selecione o tipo de usuário---</option>
                            {
                                listaTiposUsuarios.map((tipos) => {
                                    return(
                                        <option key={tipos.idTiposUsuario} value={tipos.idTiposUsuario}>
                                            {tipos.nome}
                                        </option>
                                    )
                                })
                            }
                        </select>
                        </div>

                            <div className="grid_1"id="botao">
                                <button disabled={email === '' ? 'none' : '' } type="submit">
                                    {
                                        idUsuario === 0 ? 'Cadastrar' : 'Atualizar'
                                    }
                                </button>
                                <button onClick={limparCampos}>Cancelar</button>
                            </div>
                    
                    </form>
                </section>
                <section className="Tabela">
                    <table>
                        <thead>
                            <td className="td-h">ID</td>
                            <td className="td-h">Nome</td>
                            <td className="td-h">Email</td>
                            <td style={{width:"100px"}} className="td-h">Ações</td>
                        </thead>
                        <tbody>
                            {
                                listaUsuarios.map(usuario => {
                                    return(
                                        <tr key={usuario.idUsuario}>
                                            <td>{usuario.idUsuario}</td>
                                            <td>{usuario.nome}</td>
                                            <td>{usuario.email}</td>
                                            <button  className="btnt-ed" onClick={() => buscarIdUsuario(usuario)}>Editar</button>
                                        <button className="btnt-ex" onClick={() => excluirUsuario(usuario)}>Excluir</button>
                                        </tr>
                                    )
                                })
                            }
                            
                        </tbody>
                    </table>
                </section>
                
            </main>
        </div>
    )
}
export default Usuario;