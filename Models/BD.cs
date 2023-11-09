using System.Data.SqlClient;
using Dapper;

public static class BD {
    private static string _connectionString = @"Server=localhost; DataBase=TP11Integral; Trusted_Connection=True;";


public static Registro IniciarSesion(string Email, string Contraseña)
{
    Registro iniciar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "IniciarSesion";
        iniciar = DB.QueryFirstOfDefault<Registro>(SP, new {Email = Email}, new {Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);
    }
    return iniciar;
} 

public static Registro Registrarte (string Nombre, string Apellido, string Email, string Contraseña)
{
    Registro registrar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Registrate";
        registrar = DB.QueryFirstOfDefault<Registro>(SP, new {Nombre_usuario = Nombre}, new {Apellido_usuario = Apellido}, new {Email = Email}, new {Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);   
    }
    return registrar;
}

public static List<Alquiler> ObtenerSemanasDisponibles(int idCasa, int mes, int anio)
{
    Alquiler fechas = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "ObtenerSemanasDisponibles";
        fechas = DB.Query<Alquiler>(SP, new {IDCasa = idCasa}, new {Mes = mes}, new {Anio = anio},
        commandType: CommandType.StoredProcedure).ToList();   
    }
    return fechas;
}

public static Favorito GuardarFavoritos(int idUsu, int idCasa)
{
    Favorito guardarFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "GuardarFavoritos";
        guardarFav = DB.Query<Favoritos>(SP, new {IDUsuario = idUsu}, new {idCasa = idCasa},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return guardarFav;
}

public static Favorito VerFavoritos(int udUsu)
{
    Favorito verFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "VerFavoritos";
        verFav = DB.Query<Favoritos>(SP, new {IDUsuario = idUsu},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return verFav;
}

public static Casa TienePileta(bool pileta)
{
    Casa pile = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "TienePileta";
        pile = DB.Query<Casa>(SP, new {Pileta = pileta},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return pile;
}

public static Casa TieneParrilla(bool parrilla)
{
    Casa parri = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "TieneParrilla";
        parri = DB.Query<Casa>(SP, new {Parrilla = parrilla},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return parri;
}

public static Casa TieneBalcon(bool balcon)
{
    Casa bal = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "TieneBalcon";
        bal = DB.Query<Casa>(SP, new {Balcon = balcon},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return bal;
}

public static Casa CantidadAmbientes(int cantAmbientes)
{
    Casa amb = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "CantidadAmbientes";
        amb = DB.Query<Casa>(SP, new {Cantidad_ambientes = cantAmbientes},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
}

}