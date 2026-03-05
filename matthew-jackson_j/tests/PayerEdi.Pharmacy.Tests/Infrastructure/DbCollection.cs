namespace PayerEdi.Pharmacy.Tests.Infrastructure;

[CollectionDefinition("db")]
/// <summary>
/// XUnit collection that shares a single <see cref="DbFixture"/> instance.
/// </summary>
public sealed class DbCollection : ICollectionFixture<DbFixture> { }
