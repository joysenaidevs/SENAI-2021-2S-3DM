import './header.css'
import logo from '../../assets/img/senai-logo.png'


 function Header(){
    return(
        <div>
            <header className="cabecalho-principal">
                <div className="container">
                    <a href="/home"><img src={logo} alt="Image" height="50" width="220" /></a>
                    <nav className="cabecalhoPrincipal-nav">
                        <a href="/cadastrarsala">Salas</a>
                        <a href="/cadastrarequipamento">Equipamentos</a>
                        <a href="/cadastrarusuario">Usuários</a>
                        <a onClick={ () => localStorage.removeItem('usuario-login')} href="/">Sair</a>
                    </nav>
                </div>
            </header>        
        </div>  
    )
}

export default Header;
