static class Badge
{
    public static string Print(int? id, string name, string? department) {
        string defaultOrDepartment = (department?.ToUpper() ?? "OWNER");
        string defaultOrId = id.HasValue ? $"[{id}] - " : "";
        
        return $"{defaultOrId}{name} - {defaultOrDepartment}";
    }
}
