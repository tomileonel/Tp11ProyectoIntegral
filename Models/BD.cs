using System.Data.SqlClient;
using System.Data;
using Dapper;

public static class BD {
    private static string _connectionString = @"Server=localhost; DataBase=TP11Integral; Trusted_Connection=True;";

public static Registro Usuario;
public static Registro IniciarSesion(string Email, string Contraseña)
{
    Registro iniciar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "IniciarSesion";
        iniciar = DB.QueryFirstOrDefault<Registro>(SP, new {Email = Email, Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);
    }
    Usuario = iniciar;
    return iniciar;
} 

public static Registro Registrarte (string Nombre, string Apellido, string Email, string Contraseña)
{
    Registro registrar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Registrarte";
        registrar = DB.QueryFirstOrDefault<Registro>(SP, new {nombreU = Nombre, apellidoU = Apellido, gmail = Email, contrasena = Contraseña},
        commandType: CommandType.StoredProcedure);   
    }
    return registrar;
}

public static Registro EditarPerfil (string Nombre, string Apellido, string Email, string Contraseña, int Telefono, string FotoPerfil)
{
    Registro editar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "EditarPerfil";
        editar = DB.QueryFirstOrDefault<Registro>(SP, new {Nombre_usuario = Nombre,  Apellido_usuario = Apellido, Email = Email, Contraseña = Contraseña},
        commandType: CommandType.StoredProcedure);
    }
    return editar;
}

public static List<Casa> BuscarCasa(string Nombre, string Direccion, float Precio, bool Pileta, bool Parrilla, int CantAmb, bool Balcon)
{
    List<Casa> buscar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "BuscarCasa";
        buscar = DB.Query<Casa>(SP, new {Nombre_casa = Nombre, Direccion_casa = Direccion, Precio = Precio, Pileta = Pileta, Parrilla = Parrilla, Cantidad_ambientes = CantAmb, Balcon = Balcon},
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

public static List<Alquiler> ObtenerSemanasDisponibles(int idCasa, int mes, int anio)
{
    List<Alquiler> fechas = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "ObtenerSemanasDisponibles";
        fechas = DB.Query<Alquiler>(SP, new {IDCasa = idCasa, Mes = mes, Anio = anio},
        commandType: CommandType.StoredProcedure).ToList();   
    }
    return fechas;
}

public static Alquiler Reservar (int idC, int idU, int mes, int año, int sem)
{
    Alquiler reservar = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "Reservar";
        reservar = DB.QueryFirstOrDefault<Alquiler>(SP, new {IDCasa = idC, IDUsuario = idU, Mes = mes, Anio = año, Semana = sem},
        commandType: CommandType.StoredProcedure);
    }
    return reservar;
}

public static List<Favorito> GuardarFavoritos(int idUsu, int idCasa)
{
    List<Favorito> guardarFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "GuardarFavoritos";
        guardarFav = DB.Query<Favorito>(SP, new {IDUsuario = idUsu, IdCasa = idCasa},
        commandType: CommandType.StoredProcedure).ToList(); 
    }
    return guardarFav;
}

public static List<Favorito> VerFavoritos(int idUsu)
{
    List<Favorito> verFav = null;
    using (SqlConnection DB = new SqlConnection(_connectionString))
    {
        string SP = "VerFavoritos";
        verFav = DB.Query<Favorito>(SP, new {IDUsuario = idUsu},
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