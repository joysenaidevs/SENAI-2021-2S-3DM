import { useState, useEffect } from "react"
import axios from 'axios'
import '../Equipamentos/equipamento.css'
import { parseJwt } from "../../services/auth"
import { Helmet } from "react-helmet"
import Header from "../../Components/header/header"

function Sala(){
    const [andar, setAndar] = useState(0)
    const [nome, setNome] = useState('')
    const [metragem, setMetragem] = useState(0)
    const [idUsuario, setIdUsuario] = useState(0)
    const [listaSalas, setListaSalas] = useState([])
    const [idSalaAlterado, setIdSalaAlterado] = useState(0)


    function cadastrarSala(event){
        event.preventDefault()

        let id = parseJwt().jti

        setIdUsuario(id)


        if(idSalaAlterado !== 0){

            let salaAlterado = {
                nome : nome,
                andar : andar,
                metragem : metragem
            }
            axios.put('http://localhost:5000/api/sala/'+ idSalaAlterado, salaAlterado, {
                headers : {
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })

            .then(resposta => {
                if(resposta.status === 204){
                    buscarSalas()
                    console.log('sala atualizada')
                }
            })

            .catch((erro) => console.log(erro))
        } else {

        let sala = {
            andar : andar,
            nome : nome,
            metragem : metragem
        }
        axios.post('http://localhost:5000/api/sala', sala, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 201){
                buscarSalas();
                console.log('sala cadastrada')
            }
        })

        .catch((erro) => console.log(erro))
        }  
    }

    function buscarSalas(){

        if(parseJwt().role === "1"){
            axios.get('http://localhost:5000/api/sala/listar', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 200){
                setListaSalas(resposta.data)
                console.log('listando salas!')
            }
        })

        .catch((erro) => console.log(erro))
        } else if(parseJwt().role === "2"){
            axios.get('http://localhost:5000/api/sala', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 200){
                setListaSalas(resposta.data)
                console.log('listando salas!')
            }
        })

        .catch((erro) => console.log(erro))
        }

        
    }

    function limparCampos(){
        setMetragem(0)
        setNome('')
        setAndar(0)
        setIdSalaAlterado(0)
    }

    function buscarIdSala(sala){
        setNome(sala.nome)
        setAndar(sala.andar)
        setMetragem(sala.metragem)
        setIdSalaAlterado(sala.idSala)
        console.log('A Sala ' + sala.idSala + ' foi selecionado; O idSalaAlterado agora é: '+ sala.idSala)
    }

    function excluirSala(sala){
        

        axios.delete('http://localhost:5000/api/sala/' + sala.idSala, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

        .then(resposta => {
            if(resposta.status === 204){
                buscarSalas()
                console.log('Sala deletada')
            }
        })

        .catch((erro) => console.log(erro))
    }

useEffect(buscarSalas, [])

    return(
        <div>
            <Helmet>
                <title>SM - Sala</title>
            </Helmet>
            <Header />
            <main>
            <section className="sec_1">
                    <div className="content">
                        <div className="titulo-cadastrarEquipamento">
                            <h1>Cadastrar Salas</h1>
                            <hr />
                        </div>
                    </div>

                    <form  onSubmit={cadastrarSala} className="form content">
                        <div className="grid_1">
                            <input type="text"  value={nome} onChange={(event) => setNome(event.target.value)} name="nome" placeholder="Nome:" class="input watermark" required />
                            <input type="text"  value={metragem} onChange={(event) => setMetragem(event.target.value)} name="email" placeholder="Metragem:" class="input watermark" required /><label>M²</label>
                        </div>

                        <div className="grid_1">  
                        <select className="select-tipo" name="andar" value={andar} onChange={(event) => setAndar(event.target.value)} required>
                            <option value="0" disabled>---Selecione o andar---</option>
                            <option value="1">1° Andar</option>
                            <option value="2">2° Andar</option>
                            <option value="3">3° Andar</option>
                            <option value="4">4° Andar</option>
                            <option value="5">5° Andar</option>
                            <option value="6">6° Andar</option>
                            <option value="7">7° Andar</option>
                            <option value="8">8° Andar</option>
                        </select>    
                        </div>

                            <div className="grid_1"id="botao">
                                <button disabled={nome === '' ? 'none' : '' } type="submit">
                                    {
                                        idSalaAlterado === 0 ? 'Cadastrar' : 'Atualizar'
                                    }
                                </button>
                                <button onClick={limparCampos}>Cancelar</button>
                            </div>
                    
                    </form>
                </section>
                <section className="Tabela">
              <table>
                    <thead>
                        <td className="td-h">Nome</td>
                        <td className="td-h">Andar</td>
                        <td className="td-h">M²</td>
                        <td style={{width:"100px"}} className="td-h">Ações</td>
                    </thead>

                    <tbody>
                        {
                            listaSalas.map(sala=> {
                                return(
                                    
                                    <tr key={sala.idSala}>
                                        <td>{sala.nome}</td>
                                        <td>{sala.andar}</td>
                                        <td>{sala.metragem}</td>
                                        <button  className="btnt-ed" onClick={() => buscarIdSala(sala)}>Editar</button>
                                        <button className="btnt-ex" onClick={() => excluirSala(sala)}>Excluir</button>
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




export default Sala;