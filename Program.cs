using MySql.Data.MySqlClient;

Console.WriteLine($"---bejelentkezés---");
Console.Write("username: ");
string uid = Console.ReadLine()!;
Console.ForegroundColor = ConsoleColor.White;
Console.Write("password: ");
Console.BackgroundColor = ConsoleColor.White;
string pwd = Console.ReadLine()!;
Console.ResetColor();

string conStr = 
    "SERVER    = 172.16.1.241;" +
    $"DATABASE = {uid};" +
    $"UID      = {uid};" +
    $"PWD      = {pwd};";

using MySqlConnection conn = new(conStr);
conn.Open();

string sqlQueryString = "SELECT * FROM teszt;";

MySqlCommand cmd = new(
    cmdText: sqlQueryString,
    connection: conn);

MySqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader["id"]}\t{reader["nev"]}\t{reader["egyenleg"]}");
}

Console.WriteLine("done!");