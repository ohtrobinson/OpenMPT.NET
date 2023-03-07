using System;
using System.Runtime.Serialization;

namespace OpenMPT.NET;

public class ModuleLoadException : Exception
{
    public ModuleLoadException() { }
    protected ModuleLoadException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public ModuleLoadException(string message) : base(message) { }
    public ModuleLoadException(string message, Exception innerException) : base(message, innerException) { }
}