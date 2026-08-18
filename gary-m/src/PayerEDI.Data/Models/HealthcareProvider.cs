using System.Text.Json.Serialization;

namespace PayerEDI.Data.Models;

/// <summary>
/// A doctor, PA, Nurse, ETC
/// </summary>
[JsonPolymorphic]
[JsonDerivedType(typeof(ReferringProvider), "referringProvider")]
[JsonDerivedType(typeof(RenderingProvider), "renderingProvider")]
[JsonDerivedType(typeof(SupervisingProvider), "supervisingProvider")]
public abstract record HealthcareProvider(Person Provider);

public record ReferringProvider(Person Provider) : HealthcareProvider(Provider);

/// <summary>
/// A doctor, PA, Nurse, ETC, that referred someone for care to a different provider
/// </summary>
public record RenderingProvider(Person Provider) : HealthcareProvider(Provider);

/// <summary>
/// A doctor, PA, Nurse, ETC that supervised the care, not sure what that actually means though.
/// </summary>
public record SupervisingProvider(Person Provider) : HealthcareProvider(Provider);
