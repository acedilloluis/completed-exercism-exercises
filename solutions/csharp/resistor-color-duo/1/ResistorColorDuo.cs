public static class ResistorColorDuo
{
    private static string[] bandColors =
        {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
    
    public static int Value(string[] colors) =>
        (Array.IndexOf(bandColors, colors[0])) * 10 + (Array.IndexOf(bandColors, colors[1]));
}
