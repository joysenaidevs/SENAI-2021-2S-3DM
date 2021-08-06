import {useEffect, useState} from 'react'
import axios from 'axios'
import { Switch } from 'react-router-dom'

function Equipamento(){

    const [listaEquipamento, setListaEquipamento] = useState([])
    const [marca, setMarca] = useState('')
    const [tipo, setTipo] = useState('')
    const [numeroSerie, setNumeroSerie] = useState(0)
    const [descricao, setDescricao] = useState('')
    const [numeroPatrimonio, setNumeroPatrimonio] = useState(0)
    const [disponivel, setDisponivel] = useState(false)

    function buscarEquipamentos(){
        axios("http://localhost:5000/api/equipamento",  {
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

    function cadastrarEquipamentos(event){
        event.preventDefault()
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
            }
        })
        .catch(erro => {
            console.log(erro)
        })
    }

    useEffect(buscarEquipamentos, [])

    return(
        <div>
            <main>
                <table>
                    <thead>
                        <td>#</td>
                        <td>Marca</td>
                        <td>Tipo</td>
                        <td>Numero de Serie</td>
                        <td>Descricao</td>
                        <td>Numero do Patrimonio</td>
                        <td>Disponivel</td>
                    </thead>

                    <tbody>
                        {
                            listaEquipamento.map(equipamento => {
                                return(
                                    
                                    <tr key={equipamento.idEquipamento}>
                                        <td>{equipamento.idEquipamento}</td>
                                        <td>{equipamento.marca}</td>
                                        <td>{equipamento.tipo}</td>
                                        <td>{equipamento.numeroSerie}</td>
                                        <td>{equipamento.descricao}</td>
                                        <td>{equipamento.numeroPatrimonio}</td>
                                        <td>{
                                            equipamento.disponivel == true && "Ativo" || "Inativo"
                                            }</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>

                <section>
                    <form>
                        <input
                            value={numeroSerie}
                            name="numeroSerie"
                            type="text"
                            onChange={(event) => {setNumeroSerie(event.target.value)}}
                        />
                        <input
                            value={numeroPatrimonio}
                            name="numeroPatrimonio"
                            type="text"
                            onChange={(event) => {setNumeroPatrimonio(event.target.value)}}   
                        />

                    </form>
                </section>
            </main>
        </div>
    )
}


export default Equipamento;