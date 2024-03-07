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
            Uow = new UoW(AAConfigSettings.GetDbContext());
        }

        [Test]
        public void CreateAccount()
        {
            #region Arrange
            Account account = Configuration.GetEntity<Account>("Account");
            #endregion

            #region Act
            #endregion

            #region Assert
            #endregion
        }
    }
}
