using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;
//Criar ViewModelos - você deve criar daqui a pouco

namespace VoeAirlines.Services;

public class LoginService
{

    private readonly VoeAirlinesContext _context;

    public LoginService(VoeAirlinesContext context)
    {

        _context = context;

    }

    public DetalhesLoginViewModel AdicionarLogin(AdicionarLoginViewModel dados)
    {
        var login = new Login(dados.Usuario, dados.Senha, dados.DataCriacao);
        //Contexto -> banco
        _context.Add(login); //adicionar o objeto no cilco de vida do EF.
        _context.SaveChanges();//Salva as mudanças no contexto

        return new DetalhesLoginViewModel
            (
        login.Id,
        login.Usuario,
        login.DataCriacao

            );
    }

    public IEnumerable<ListarLoginViewModel> ListarLogin()
    {
        return _context.Logins.Select(l => new ListarLoginViewModel(l.Usuario,l.DataCriacao));
    }

}


/*using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;
//criar viewmodelos - 

namespace VoeAirlines.Services;
//defindo classe
public class LoginService{
 private readonly VoeAirlinesContext _context;

    public LoginService(VoeAirlinesContext context)
    {
        _context = context;
    }

    public DetalhesLoginViewModel AdicionarLogin(AdicionarLoginViewModel dados){
         var login = new Login(dados.Usuario,dados.Senha,dados.DataCriacao);
         _context.Add(login);
         _context.SaveChanges();

         return new DetalhesLoginViewModel(
            login.Id,
            login.Usuario,
            login.DataCriacao

         );
         
    }
    public IEnumerable<ListarLoginViewModel> ListarLogin(){
        return _context.Logins.Select<l => new ListarLoginViewModel(l.Usuario,l.DataCriacao ));
    }

    /*public IEnumerable<ListarAeronaveViewModel> ListarAeronaves()
    {
        return _context.Aeronaves.Select(a => new ListarAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
    }


    
}*/