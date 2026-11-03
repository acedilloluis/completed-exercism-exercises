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
	try
	{
	    Write(data);
	    return true;
	}
	catch
	{
	    return false;
	}   
    }
}
