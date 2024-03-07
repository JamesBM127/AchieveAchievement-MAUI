namespace AATest
{
    public class SimpleTests
    {
        public IConfiguration Configuration
        {
            get
            {
                return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }
        }
        private IUoW Uow;

        [SetUp]
        public void SetUp()
        {
            //string connectionString = "Server=.;Database=AADBTest;TrustServerCertificate=True;Trusted_Connection=True;";
            string connectionString = "AADBTest";
            Uow = new UoW(AAConfigSettings.GetAndCreateDbContext(DatabaseOptions.InMemoryDatabase, connectionString));
        }

        [Test]
        public async Task Create_AccountAndPlayer_Success()
        {
            #region Arrange
            Account account = Configuration.GetEntity<Account>("Account");
            account.Player = Configuration.GetEntity<Player>("Player");
            #endregion

            #region Act
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;
            bool addedAccount = await Uow.AddAsync<Account>(account);
            bool saved = await Uow.CommitAsync(addedAccount && addedPlayer);
            #endregion

            #region Assert
            Assert.That(addedPlayer, Is.True);
            Assert.That(addedAccount, Is.True);
            Assert.That(saved, Is.True);
            #endregion
        }
    }
}
