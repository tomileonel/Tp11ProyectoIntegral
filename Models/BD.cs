using System.Data.SqlClient;
using System.Data;
using Dapper;

public static class BD {
    private static string _connectionString = @"Server=DESKTOP-PPCLIMN\SQLEXPRESS; DataBase=TP11Integral; Trusted_Connection=True;";

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

// Extra

public static void AgregarCasa(string nombre, string direccion, double precio, bool pileta, bool parrilla, int cantidadAmbientes, bool bacon, int idUsuario, string foto)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string storedProcedure = "AgregarCasas";
        connection.Open();
        connection.Execute(
            storedProcedure,
            new
            {
                nombre = nombre,
                direccion = direccion,
                precio = precio,
                pileta = pileta,
                parrilla = parrilla,
                CantidadAmbientes = cantidadAmbientes,
                bacon = bacon,
                IDUsuario = idUsuario,
                foto = foto
            },
            commandType: CommandType.StoredProcedure);
    }
}

public static List<Casa> ListarCasasUsuario(int idUsuario)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string storedProcedure = "listarCasasUsuario";
        connection.Open();
        return connection.Query<Casa>(storedProcedure, new { IDUsuario = idUsuario }, commandType: CommandType.StoredProcedure).ToList();
    }
}


public static void BorrarCasa(int idCasa)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string storedProcedure = "BorrarCasa";
        connection.Open();
        connection.Execute(storedProcedure, new { idCasa = idCasa }, commandType: CommandType.StoredProcedure);
    }
}


public static void ModificarCasa(int idCasa, string nombre, string direccion, double precio, bool pileta, bool parrilla, int cantidadAmbientes, bool bacon, string foto)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string storedProcedure = "ModificarCasa";
        connection.Open();
        connection.Execute(
            storedProcedure,
            new
            {
                IdCasa = idCasa,
                nombre = nombre,
                direccion = direccion,
                precio = precio,
                pileta = pileta,
                parrilla = parrilla,
                CantidadAmbientes = cantidadAmbientes,
                bacon = bacon,
                foto = foto
            },
            commandType: CommandType.StoredProcedure);
    }
}
}
