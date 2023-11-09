using System.Data.SqlClient;
using Dapper;

public static class BD {
    private static string _connectionString = @"Server=localhost; DataBase=TP11Integral; Trusted_Connection=True;";


public static Registro IniciarSesion(string Email, string Contraseña)
{
    Registro reg = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "IniciarSesion";
        reg = DB.QueryFirstOfDefault<Registro>(SP, new {Email = Email}, new {Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);
    }
} 

public static Registro Registrarte (string Nombre, string Apellido, string Email, string Contraseña)
{
    Registro reg = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Registrate";
        reg = DB.QueryFirstOfDefault<Registro>(SP, new {Nombre_usuario = Nombre}, new {Apellido_usuario = Apellido}, new {Email = Email}, new {Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);   
    }
}

public static List<Alquiler> ObtenerSemanasDisponibles(int idCasa, int mes, int anio)
{
    Alquiler alq = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "ObtenerSemanasDisponibles";
        alq = DB.Query<Alquiler>(SP, new {IDCasa = idCasa}, new {Mes = mes}, new {Anio = anio},
        commandType: CommandType.StoredProcedure).ToList();   
    }
}

public static Favoritos GuardarFavoritos(int idUsu, int idCasa)
{
    Favoritos fav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "GuardarFavoritos";
        fav = DB.Query<Favoritos>(SP, new {IDUsuario = idUsu}, new {idCasa = idCasa},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
}

public static Favoritos VerFavoritos(int udUsu)
{
    Favoritos fav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "VerFavoritos";
        fav = DB.Query<Favoritos>(SP, new {IDUsuario = idUsu},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
}

}