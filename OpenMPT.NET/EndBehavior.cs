namespace OpenMPT.NET;

/// <summary>
/// Defines what happens when the end of a song is reached.
/// </summary>
public enum EndBehavior
{
    /// <summary>
    /// Stop and do not play any more.
    /// </summary>
    Stop,
    
    /// <summary>
    /// Continue like usual (typically looping, although can have strange behaviour if the module is not designed to
    /// loop.)
    /// </summary>
    Continue,
    
    /// <summary>
    /// Fades the song out. Acts similarly to <see cref="Continue"/> during the fade.
    /// </summary>
    FadeOut
}