import {useEffect, useState} from 'react'
import axios from 'axios'
import { Switch } from 'react-router-dom'
import './equipamento.css'
import Header from '../../Components/header/header'
import { Helmet } from 'react-helmet'

function Equipamento(){

    const [listaEquipamento, setListaEquipamento] = useState([])
    const [marca, setMarca] = useState('')
    const [tipo, setTipo] = useState('')
    const [numeroSerie, setNumeroSerie] = useState(0)
    const [descricao, setDescricao] = useState('')
    const [numeroPatrimonio, setNumeroPatrimonio] = useState(0)
    const [disponivel, setDisponivel] = useState(false)
    const [idEquipamento, setIdEquipamento] = useState(0)

    function buscarEquipamentos(){
        axios.get("http://localhost:5000/api/equipamento",  {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if(resposta.status === 200 ){
                    setListaEquipamento(resposta.data)
                    console.log(listaEquipamento)
                }
            })

            .catch(erro => {
                console.log(erro)
            })
        
    }

    function limparCampos(){
        setIdEquipamento(0)
        setMarca('')
        setTipo('')
        setNumeroSerie(0)
        setNumeroPatrimonio(0)
        setDescricao('')
    }

    function cadastrarEquipamentos(event){
        if( idEquipamento !== 0){
            let equipamentos = {
                marca : marca,
                tipo : tipo,
                numeroSerie : numeroSerie,
                descricao : descricao,
                numeroPatrimonio : numeroPatrimonio,
                disponivel : disponivel
            }
            axios.put('http://localhost:5000/api/equipamento/'+idEquipamento,equipamentos, {
                headers : {
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then(resposta => {
                if(resposta.data === 204){
                    console.log('Equipamento atualizado!')
                    buscarEquipamentos()
                    limparCampos()
                    event.preventDefault()
                }
            })
            .catch((erro) => console.log(erro))
        } else {
            event.preventDefault();
            let cadastro = {
                marca : marca,
                tipo : tipo,
                numeroSerie : numeroSerie,
                descricao : descricao,
                numeroPatrimonio : numeroPatrimonio,
                disponivel : disponivel
            }
    
            axios.post("http://localhost:5000/api/equipamento",cadastro, {
                    headers : {
                        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                    }
                }
            )
    
            .then(resposta => {
                if(resposta.status === 201){
                    console.log("Equipamento cadastrado!")
                    buscarEquipamentos()
                    limparCampos()
                }
            })
            .catch(erro => {
                console.log(erro)
            })
            
        }       
    }
    function buscarIdEquipamento(equipamento){
        setMarca(equipamento.marca)
        setTipo(equipamento.tipo)
        setNumeroSerie(equipamento.numeroSerie)
        setNumeroPatrimonio(equipamento.numeroPatrimonio)
        setDescricao(equipamento.descricao)
        setIdEquipamento(equipamento.idEquipamento)
        console.log('O Equipamento ' + equipamento.idEquipamento + ' foi selecionado; O idEquipamentoAlterado agora é: '+ equipamento.idEquipamento)
    }

    function excluirEquipamento(equipamento){
        axios.delete('http://localhost:5000/api/equipamento/' + equipamento.idEquipamento)
        .then(resposta => {
            if(resposta.status === 204){
                console.log("O equipamento "+ equipamento.idEquipamento +" foi excluído")
                buscarEquipamentos()
            }
        })
        .catch(erro => console.log(erro))
    }

    useEffect(buscarEquipamentos, [])

    return(
        <div>
            <Helmet>
                <title>SM - Equipamentos</title>
            </Helmet>
            <Header />
           <main>
                <section className="sec_1">
                    <div className="content">
                        <div className="titulo-cadastrarEquipamento">
                            <h1>Cadastrar Equipamento</h1>
                            <hr />
                        </div>
                    </div>

                    <form  onSubmit={cadastrarEquipamentos} className="form content">
                        <div className="grid_1">
                            <select  className="select-tipo" name="tipo" value={tipo} onChange={(event) => setTipo(event.target.value)} required>
                                <option Disabled value="0">Selecione o tipo de equipamento</option>
                                <option value="Informática">Informática</option>
                                <option value="Eletroeletrônica">Eletroeletrônica</option> 
                                <option value="Mobiliário">Mobiliário</option>  
                            </select>
                            <input type="text"  value={marca} onChange={(event) => setMarca(event.target.value)} name="marca" placeholder="Marca" class="input watermark" required />
                        </div>

                        <div className="grid_1">  

                            <input type="number" minLength="6" name="numeroSerie" value={numeroSerie} placeholder="Nº de Serie" class="input watermark" onChange={(event) => setNumeroSerie(event.target.value)} required/>
                            <input type="number" minLength="6" name="numeroPatrimonio" value={numeroPatrimonio}  placeholder="Nº de Patrimonio"  onChange={(event) => setNumeroPatrimonio(event.target.value)} class="input watermark" required/>

                        </div>

                        <p className="title-descricao">Descrição:</p>
                        <input type="text" value={descricao} className="descricao" onChange={(event) => setDescricao(event.target.value)} name="descricao" required/>

                        <h2>Estado</h2>
                    <div className="coluna">
                            <div class="coluna2">

                                <input type="checkbox"  value={true}  onChange={(event) => setDisponivel(event.target.value)} name="disponivel" id="estado" />
                                <label for="estado">Ativo</label>

                            </div>
                            <div className="coluna2">

                                <input type="checkbox"  value={false} name="disponivel" onChange={(event) => setDisponivel(event.target.value)} id="estado"  />
                                <label for="estado">Inativo</label>

                            </div>
                    </div>

                            <div className="grid_1"id="botao">
                                <button className="btn-cadastro" disabled={descricao === '' ? 'none' : '' } type="submit">
                                    {
                                        idEquipamento === 0 ? 'Cadastrar' : 'Atualizar'
                                    }
                                </button>
                                <button className="clean" disabled={idEquipamento === 0 ? true : false} onClick={limparCampos}>Limpar</button>
                            </div>
                    
                    </form>
                </section>
              <section className="Tabela">
              <table>
                    <thead>
                        <td className="td-h">Marca</td>
                        <td className="td-h">Tipo</td>
                        <td className="td-h">Numero de Serie</td>
                        <td className="td-h">Descricao</td>
                        <td className="td-h">Numero do Patrimonio</td>
                        <td className="td-h">Disponivel</td>
                        <td style={{width:"100px"}} className="td-h">Ações</td>
                    </thead>

                    <tbody>
                        {
                            listaEquipamento.map(equipamento => {
                                return(
                                    
                                    <tr key={equipamento.idEquipamento}>
                                        <td>{equipamento.marca}</td>
                                        <td>{equipamento.tipo}</td>
                                        <td>{equipamento.numeroSerie}</td>
                                        <td>{equipamento.descricao}</td>
                                        <td>{equipamento.numeroPatrimonio}</td>
                                        <td>{
                                            equipamento.disponivel == true && "Ativo" || "Inativo"
                                            }
                                        </td>
                                        <button  className="btnt-ed" onClick={() => buscarIdEquipamento(equipamento)}>Editar</button>
                                        <button className="btnt-ex" onClick={() => excluirEquipamento(equipamento)}>Excluir</button>
                                      
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


export default Equipamento;