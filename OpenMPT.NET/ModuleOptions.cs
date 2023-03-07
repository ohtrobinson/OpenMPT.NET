namespace OpenMPT.NET;

/// <summary>
/// Settable module options.
/// </summary>
public struct ModuleOptions
{
    /// <summary>
    /// The <see cref="OpenMPT.NET.EndBehavior"/> that occurs at the end of a song.
    /// </summary>
    public EndBehavior EndBehavior;

    /// <summary>
    /// The floating point tempo factor. A value of 1.0 means no change.
    /// </summary>
    public float TempoFactor;

    /// <summary>
    /// The floating point pitch factor. A value of 1.0 means no change.
    /// </summary>
    public float PitchFactor;

    /// <summary>
    /// Create a new <see cref="ModuleOptions"/> with the default values.
    /// </summary>
    public ModuleOptions()
    {
        EndBehavior = EndBehavior.Stop;
        TempoFactor = 1.0f;
        PitchFactor = 1.0f;
    }

    /// <summary>
    /// Create a new <see cref="ModuleOptions"/> with custom values.
    /// </summary>
    /// <param name="endBehavior">The <see cref="OpenMPT.NET.EndBehavior"/> that occurs at the end of a song.</param>
    /// <param name="tempoFactor">The floating point tempo factor. A value of 1.0 means no change.</param>
    /// <param name="pitchFactor">The floating point pitch factor. A value of 1.0 means no change.</param>
    public ModuleOptions(EndBehavior endBehavior = EndBehavior.Stop, float tempoFactor = 1.0f, float pitchFactor = 1.0f)
    {
        EndBehavior = endBehavior;
        TempoFactor = tempoFactor;
        PitchFactor = pitchFactor;
    }
}