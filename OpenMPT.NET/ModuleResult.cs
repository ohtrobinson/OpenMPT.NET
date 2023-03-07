namespace OpenMPT.NET;

/// <summary>
/// A result that occurs from certain operations.
/// </summary>
public enum ModuleResult
{
    // These values are copied straight from the libopenmpt docs. Some of them won't apply here really, but best to
    // include them anyway.
    
    /// <summary>
    /// Lowest value libopenmpt will use for any of its own error codes.
    /// </summary>
    Base = 256,
    
    /// <summary>
    /// NULL pointer argument. 
    /// </summary>
    ArgumentNullPointer = Base + 103,
    
    /// <summary>
    /// Value domain error. 
    /// </summary>
    Domain = Base + 41,
    
    /// <summary>
    /// Unknown internal C++ exception. 
    /// </summary>
    Exception = Base + 11,
    
    /// <summary>
    /// General libopenmpt error. 
    /// </summary>
    General = Base + 101,
    
    /// <summary>
    /// Invalid argument. 
    /// </summary>
    InvalidArgument = Base + 44,
    
    /// <summary>
    /// openmpt_module * is invalid. 
    /// </summary>
    InvalidModulePointer = Base + 102,
    
    /// <summary>
    /// Maximum supported size exceeded. 
    /// </summary>
    Length = Base + 42,
    
    /// <summary>
    /// Logic error. 
    /// </summary>
    Logic = Base + 40,
    
    /// <summary>
    /// No error. 
    /// </summary>
    Ok = 0,
    
    /// <summary>
    /// Out of memory. 
    /// </summary>
    OutOfMemory = Base + 21,
    
    /// <summary>
    /// Argument out of range. 
    /// </summary>
    OutOfRange = Base + 43,
    
    /// <summary>
    /// Arithmetic overflow. 
    /// </summary>
    Overflow = Base + 32,
    
    /// <summary>
    /// Range error. 
    /// </summary>
    Range = Base + 31,
    
    /// <summary>
    /// Runtime error. 
    /// </summary>
    Runtime = Base + 30,
    
    /// <summary>
    /// Arithmetic underflow.
    /// </summary>
    Underflow = Base + 33,
    
    /// <summary>
    /// Unknown internal error. 
    /// </summary>
    Unknown = Base + 1
}