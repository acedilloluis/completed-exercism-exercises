public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
	using Database dataBase = database;
	dataBase.BeginTransaction();
	dataBase.Write(data);
	dataBase.EndTransaction();
    }

    public bool WriteSafely(string data)
    {
	using Database dataBase = database;
	try
	{
	    database.BeginTransaction();
	    database.Write(data);
	    database.EndTransaction();
	    return true;
	}
	catch
	{
	    return false;
	}   
    }
}
