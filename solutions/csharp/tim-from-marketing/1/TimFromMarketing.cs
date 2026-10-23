static class Badge
{
    public static string Print(int? id, string name, string? department) {
        string defaultOrDepartment = (department ?? "OWNER").ToUpper();
        string defaultOrId = (id ?? 0).ToString();

        if (defaultOrId != "0")
            defaultOrId = $"[{defaultOrId}] - ";
        else
            defaultOrId = "";
        
        return $"{defaultOrId}{name} - {defaultOrDepartment}";
    }
}
