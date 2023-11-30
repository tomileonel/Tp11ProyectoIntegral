using System.Data.SqlClient;
using System.Data;
using Dapper;

public static class BD {
    private static string _connectionString = @"Server=.; DataBase=TP11Integral; Trusted_Connection=True;";

public static Registro Usuario = null;
public static Registro IniciarSesion(string Email1, string Contrasena)
{
    Registro iniciar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "IniciarSesion";
        iniciar = DB.QueryFirstOrDefault<Registro>(SP, new {gmail = Email1, Contrasena = Contrasena},
        commandType: CommandType.StoredProcedure);
    }
    Usuario = iniciar;
    return iniciar;
} 

public static Registro Registrarte (string Nombre, string Apellido, string Email, string contrasena)
{
    Registro registrar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Registrarte";
        registrar = DB.QueryFirstOrDefault<Registro>(SP, new {nombreU = Nombre, apellidoU = Apellido, gmail = Email, contrasena = contrasena},
        commandType: CommandType.StoredProcedure);   
    }
    return registrar;
}

public static void CerrarSesion(){
Usuario = null;
}
public static Registro EditarPerfil (string Nombre, string Apellido, string Email, string Contrasena, int Telefono, string FotoPerfil)
{
    Registro editar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "EditarPerfil";
        editar = DB.QueryFirstOrDefault<Registro>(SP, new {nombreU= Nombre,  apellidoU = Apellido, gmail = Email, Contrasena = Contrasena, telefono = Telefono, foto = FotoPerfil},
        commandType: CommandType.StoredProcedure);
    }
    Usuario = IniciarSesion(Email,Contrasena);
    return editar;
}

public static List<Casa> BuscarCasa(string direccion, float precio, bool pileta, bool parrilla, int cantAmb, bool balcon)
{
    List<Casa> buscar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "BuscarCasa";
    buscar = DB.Query<Casa>(SP, new { Direccion = direccion, Precio = precio, Pileta = pileta, Parrilla = parrilla, CantAmb = cantAmb, Balcon = balcon },
    commandType: CommandType.StoredProcedure).ToList();

    }
    return buscar;
}

public static List<Casa> TraerCasas()
{
    List<Casa> buscar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "TraerCasas";
        buscar = DB.Query<Casa>(SP,
        commandType: CommandType.StoredProcedure).ToList();
    }
    return buscar;
}



public static void Reservar (int idC, int idU, int mes, int año, int sem)
{
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Reservar";
        DB.Execute(SP, new {IDCasa = idC, IdUser = idU, Mes = mes, Anio = año, Semana = sem},
        commandType: CommandType.StoredProcedure);
    }
}

public static List<int> ObtenerSemanasDisponibles(int idCasa, int mes, int anio)
{
    List<int> semanasDisponibles = new List<int>();

    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "ObtenerSemanasDisponibles";

        semanasDisponibles = DB.Query<int>(SP, new { IDCasa = idCasa, mes = mes, anio = anio },
            commandType: CommandType.StoredProcedure).ToList();
    }

    return semanasDisponibles;
}

public static List<Favorito> GuardarFavoritos(int idUsu, int idCasa)
{
    List<Favorito> guardarFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "GuardarFavoritos";
        guardarFav = DB.Query<Favorito>(SP, new { IdUser = idUsu, IdCasa = idCasa },
            commandType: CommandType.StoredProcedure).ToList();
    }
    return guardarFav;
}

public static int VerificarEmailRegistrado(string email)
{
    int registrosEncontrados;

    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "VerificarEmailRegistrado";
        registrosEncontrados = DB.Query<int>(SP, new { Email = email },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
    }

    return registrosEncontrados;
}

public static bool EsFavorito(int idUsuario, int idCasa)
{
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "EsFavorito";
        var parameters = new { IDUsuario = idUsuario, IdCasa = idCasa };
        bool result = DB.QueryFirstOrDefault<bool>(SP, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }
}

public static void SacarDeFavoritos(int idUsu, int idCasa)
{
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "SacarDeFavoritos";
        DB.Execute(SP, new { IdUser = idUsu, IdCasa = idCasa }, commandType: CommandType.StoredProcedure);
    }
}

public static List<Casa> VerFavoritos(int idUsu)
{
    List<Casa> verFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "VerFavoritos";
        verFav = DB.Query<Casa>(SP, new {IdUser = idUsu},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return verFav;
}

public static Casa TraerUnaCasa(int idCasa)
{
    Casa unaCasa = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "TraerUnaCasa";
        unaCasa = DB.QueryFirstOrDefault<Casa>(SP, new {IdCasa = idCasa},
        commandType: CommandType.StoredProcedure);
    }
    return unaCasa;
}



// public static List<Casa> TienePileta(bool pileta)
// {
//     Casa pile = null;
//     using (SqlConnection DB = new SqlConnection(_connectionString))
//     {
//         string SP = "TienePileta";
//         pile = DB.Query<Casa>(SP, new {Pileta = pileta},
//         commandType: CommandType.StoredProcedure).ToList(); 
//     }
//     return pile;
// }

// public static Casa TieneParrilla(bool parrilla)
// {
//     Casa parri = null;
//     using (SqlConnection DB = new SqlConnection(_connectionString))
//     {
//         string SP = "TieneParrilla";
//         parri = DB.Query<Casa>(SP, new {Parrilla = parrilla},
//         commandType: CommandType.StoredProcedure).ToList(); 
//     }
//     return parri;
// }

// public static Casa TieneBalcon(bool balcon)
// {
//     Casa bal = null;
//     using (SqlConnection DB = new SqlConnection(_connectionString))
//     {
//         string SP = "TieneBalcon";
//         bal = DB.Query<Casa>(SP, new {Balcon = balcon},
//         commandType: CommandType.StoredProcedure).ToList(); 
//     }
//     return bal;
// }

// public static Casa CantidadAmbientes(int cantAmbientes)
// {
//     Casa amb = null;
//     using (SqlConnection DB = new SqlConnection(_connectionString))
//     {
//         string SP = "CantidadAmbientes";
//         amb = DB.Query<Casa>(SP, new {Cantidad_ambientes = cantAmbientes},
//         commandType: CommandType.StoredProcedure).ToList(); 
//     }
//     return amb;
// }

}