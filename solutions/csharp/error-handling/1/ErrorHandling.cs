public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() =>
	throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input) =>
	input == "1" ? 1 : null;

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
	if(input == "1")
	    result = 1;
	else
	    result = 0;
	return input == "1";
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
	try
	{
	    throw new Exception();
	}
	finally
	{
	    disposableObject.Dispose();
	}
    }
}
