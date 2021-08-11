import { useState, useEffect } from 'react';
import '../Equipamentos/equipamento.css';
import { Helmet } from 'react-helmet';
import Header from '../../Components/header/header';
import axios from 'axios';

function App() {
  const [listaSalas, setListaSalas] = useState([])
  const [listaEquipamentos, setListaEquipamentos] = useState([])

  function buscarSalas(){
      axios.get('http://localhost:5000/api/sala/listar', {
        headers : {
          'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
        }
      })

      .then(resposta => {
        if(resposta.status === 200){
          setListaSalas(resposta.data)
          console.log('Listando salas')
        }
      })

      .catch((erro) => console.log(erro))
  }

  function buscarEquipamentos(){
    axios.get('http://localhost:5000/api/equipamento', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if(resposta.status === 200){
        setListaEquipamentos(resposta.data)
        console.log('Listando equipamentos')
      }
    })

    .catch((erro) => console.log(erro))
  }

  useEffect(buscarSalas, [])
  useEffect(buscarEquipamentos, [])

  return (
    <div className="App">
      <Helmet>
        <title>SM - Home</title>
      </Helmet>
      <Header />
      <section className="listagem">
        <div className="lista1">
          <div className="content">
              <div className="titulo-cadastrarEquipamento">
                <br />
                <br />
                <br />
                <br />
                  <h1>Lista de equipamentos</h1>
                <hr />
              </div>
          </div>
            <section className="Tabela">
                  <table>
                        <thead>
                            <td className="td-h">Marca</td>
                            <td className="td-h">Tipo</td>
                            <td className="td-h">Numero de Serie</td>
                            <td className="td-h">Descricao</td>
                            <td className="td-h">Numero do Patrimonio</td>
                            <td className="td-h">Disponivel</td>
                  
                        </thead>

                        <tbody>
                            {
                                listaEquipamentos.map(equipamento => {
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
                                          
                                          
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                  </section>
        </div>
        <div className="lista2">
        <div className="content">
              <div className="titulo-cadastrarEquipamento">
                <br />
                <br />
                  <h1>Lista de Salas</h1>
                  <hr />
              </div>
          </div>
        <section className="Tabela">
              <table>
                    <thead>
                        <td className="td-h">Nome</td>
                        <td className="td-h">Andar</td>
                        <td className="td-h">M²</td>
                    </thead>

                    <tbody>
                        {
                            listaSalas.map(sala=> {
                                return(
                                    
                                    <tr key={sala.idSala}>
                                        <td>{sala.nome}</td>
                                        <td>{sala.andar}°</td>
                                        <td>{sala.metragem}</td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>
        </section>
      </div>
      </section>
    </div>
  );
}

export default App;
