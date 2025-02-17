using System.Data.SQLite;

namespace _37_WebApp_SQLite.Utilities;

//esegue la query senza restituzioni
public static class DbUtils
{
    ///<summary>
    ///Esegue la query che non restituisce dati (INSERT, UPDATE, DELETE).
    ///</summary>
    ///<param name="sql">La Query SQL</param>
    ///<param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    ///<returns>Il numero di righe interessate.</returns>
    public static int ExecuteNonQuery(string sql,Action<SQLiteCommand> setupParameters=null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql,connection);
        setupParameters?.Invoke(command);// il metodo invoke esegue il delegate setParameters cioè la funzione che gli passiamo
        return command.ExecuteNonQuery();
    } 
    ///<summary>
    ///Esegue ua query che restituisce un valore scalare
    ///</summary>
    ///<typeparam name="T">il tipo del valore atteso.</typeparam>
    ///<param name="sql">La query SQL.</param>
    ///<param name="setupParameters">Opzionale: callback per aggiungere parametri al comando.</param>
    ///<returns>Il valore restituito convertito al tipo T.</returns>

    //esegue la query e restituisce un valore
    public static T ExecuteScalar<T>(string sql,Action<SQLiteCommand> setupParameters = null)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql,connection);
        setupParameters?.Invoke(command);// il metodo invoke esegue il delegate setParameters cioè la funzione che gli passiamo
        var result= command.ExecuteScalar();
        if(result == null || result == DBNull.Value)
        {
            return default(T);
        }
        return (T)Convert.ChangeType(result,typeof(T));
    }
    ///<summary>
    ///Esegue una query che restituisce più righe e le converte in una lista di oggetti di tipo T.
    ///</summary>
    ///<typeparam name="T">il tipo di oggetto da restituire per ogni riga.</typeparam>
    ///<param name="sql">la query SQL.</param>
    ///<param name="converter">Funzione per convertire una riga (sqliteDataReader) in un oggetto T.</param>
    ///<param name="setupParameters">Opzionale:callback per aggiungere parametri al comando.</param>
    ///<returns>Una lista di oggetti di tipo T.</returns>

    //carica dentro il reader lo stream dei dati (restituisce una lista di oggetti)
    
    public static List<T> ExecuteReader<T>(string sql,Func<SQLiteDataReader,T> converter, Action<SQLiteCommand> setupParameters= null)
    {
        var list = new List<T>();
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        using var command = new SQLiteCommand(sql,connection);
        setupParameters?.Invoke(command);// il metodo invoke esegue il delegate setParameters cioè la funzione che gli passiamo
        using var reader = command.ExecuteReader();
        while(reader.Read())
        {
            list.Add(converter(reader));
        }
        return list;
    }

}
