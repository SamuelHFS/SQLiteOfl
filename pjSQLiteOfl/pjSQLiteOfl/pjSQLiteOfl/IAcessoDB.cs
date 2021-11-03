using SQLite;

namespace pjSQLiteOfl
{
    internal interface IAcessoDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}