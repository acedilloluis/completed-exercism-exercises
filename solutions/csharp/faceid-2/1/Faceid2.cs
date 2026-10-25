using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj) 
    {
        FacialFeatures face = obj as FacialFeatures;

        return face.EyeColor == EyeColor && face.PhiltrumWidth == PhiltrumWidth; 
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj)
    {
        Identity identity = obj as Identity;

        return 
            identity.Email == Email && 
            FacialFeatures.Equals(identity.FacialFeatures);
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private HashSet<Identity> _registeredIdentities = [];
    private Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
        faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) =>
        identity.Equals(_admin);

    public bool Register(Identity identity) =>
        _registeredIdentities.Add(identity);

    public bool IsRegistered(Identity identity) =>
        _registeredIdentities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) =>
        ReferenceEquals(identityA, identityB);
}
