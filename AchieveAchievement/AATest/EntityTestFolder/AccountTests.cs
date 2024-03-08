namespace AATest.EntityTestFolder
{
    public class AccountTests
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
            string connectionString = "Server=.;Database=AADBTest;TrustServerCertificate=True;Trusted_Connection=True;";
            //string connectionString = "AADBTest";
            Uow = new UoW(AAConfigSettings.GetAndCreateDbContext(DatabaseOptions.SqlServer, connectionString));
        }

        #region Validation Account

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        [TestCase("123456789012345678901")]
        public async Task Validation_AccountWithLoginInvalid_ArgumentException(string? login)
        {
            #region Arrange
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;
            #endregion

            #region Act
            account.Login = login;
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Login"));
            #endregion
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public async Task Validation_AccountWithPasswordInvalid_ArgumentException(string? password)
        {
            #region Arrange
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;
            #endregion

            #region Act
            account.Password = password;
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Password"));
            #endregion
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        [TestCase("testgmailcom")]
        [TestCase("testgmail.com")]
        [TestCase("test@gmailcom")]
        [TestCase("test@gmail")]
        public async Task Validation_AccountWithEmailInvalid_ArgumentException(string? email)
        {
            #region Arrange
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;
            #endregion

            #region Act
            account.Email = email;
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Email"));
            #endregion
        }

        [Test]
        public async Task Validation_AccountWithBirthdateInvalid_ArgumentException()
        {
            #region Arrange
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;
            #endregion

            #region Act
            account.BirthDate = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day);
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]BirthDate"));
            #endregion
        }

        [Test]
        public void Validation_AccountWithoutPlayer_ArgumentException()
        {
            #region Arrange
            Account account = Configuration.GetEntity<Account>("Account");
            #endregion

            #region Act
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Player"));
            #endregion
        }

        [Test]
        public void Validation_AccountWithAllPropertiesInvalid_ArgumentException()
        {
            #region Arrange
            Account account = new();
            #endregion

            #region Act
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => account.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Login [2]Password [3]Email [4]BirthDate [5]Player"));
            #endregion
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        [TestCase("1234567890123456")]
        public void Validation_PlayerWithNameInvalid_ArgumentException(string? name)
        {
            #region Arrange
            Player player = Configuration.GetEntity<Player>("Player");
            #endregion

            #region Act
            player.Name = name;
            #endregion

            #region Assert
            var exception = Assert.Throws<ArgumentException>(() => player.IsValid());
            Assert.That(exception.Message, Is.EqualTo("Invalid  [1]Name"));
            #endregion
        }

        #endregion

        #region CRUD
        [Test]
        public async Task Create_AccountAndPlayer_Success()
        {
            #region Arrange
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            #endregion

            #region Act
            bool isValidPlayer = account.Player.IsValid();
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;

            bool isValidAccount = AccountSettings.IsValid(account);
            bool addedAccount = await Uow.AddAsync<Account>(account);
            bool saved = await Uow.CommitAsync(addedAccount && addedPlayer);
            #endregion

            #region Assert
            Assert.That(isValidPlayer, Is.True);
            Assert.That(isValidAccount, Is.True);
            Assert.That(addedPlayer, Is.True);
            Assert.That(addedAccount, Is.True);
            Assert.That(saved, Is.True);
            #endregion
        }

        [Test]
        public async Task Get_Account_Success()
        {
            #region Arrange
            Account account = await CreateAccountAndPlayer();
            #endregion

            #region Act
            Account accFromDb = await Uow.GetAsync<Account>(x => x.Id == account.Id);
            #endregion

            #region Assert
            Assert.That(accFromDb.Id, Is.EqualTo(account.Id));
            Assert.That(accFromDb.Login, Is.EqualTo(account.Login));
            Assert.That(accFromDb.Password, Is.EqualTo(account.Password));
            Assert.That(accFromDb.BirthDate, Is.EqualTo(account.BirthDate));
            Assert.That(accFromDb.Email, Is.EqualTo(account.Email));
            Assert.That(accFromDb.PlayerId, Is.EqualTo(account.PlayerId));
            #endregion
        }

        [Test]
        public async Task Get_Player_Success()
        {
            #region Arrange
            Account account = await CreateAccountAndPlayer();
            #endregion

            #region Act
            Player playerFromDb = await Uow.GetAsync<Player>(x => x.Id == account.Player.Id);
            #endregion

            #region Assert
            Assert.That(playerFromDb.Id, Is.EqualTo(account.Player.Id));
            Assert.That(playerFromDb.ShowContacts, Is.EqualTo(account.Player.ShowContacts));
            Assert.That(playerFromDb.AccountId, Is.EqualTo(account.Player.AccountId));
            #endregion
        }
        
        [Test]
        public async Task Delete_AccountPlayerContactsInCascade_Success()
        {
            #region Arrange
            Account account = await CreateAccountAndPlayer();
            Contact contact = Configuration.GetEntity<Contact>("Contact");
            Contact contact2 = Configuration.GetEntity<Contact>("Contact");
            contact.PlayerId = account.Player.Id;
            contact2.PlayerId = account.Player.Id;
            bool addedContact = await Uow.AddAsync(contact);
            bool addedContact2 = await Uow.AddAsync(contact2);
            await Uow.CommitAsync(addedContact && addedContact2);
            #endregion

            #region Act
            bool deleted = Uow.Delete(account);
            bool successfullyDeleted = await Uow.CommitAsync(deleted);
            #endregion

            #region Assert
            Assert.That(deleted, Is.True);
            Assert.That(successfullyDeleted, Is.True);
            #endregion
        }

        private async Task<Account> CreateAccountAndPlayer()
        {
            Account account = AAConfigSettings.GetAccountWithPlayer(Configuration);
            bool addedPlayer = await Uow.AddAsync<Player>(account.Player);
            account.PlayerId = account.Player.Id;

            bool addedAccount = await Uow.AddAsync<Account>(account);
            await Uow.CommitAsync(addedAccount && addedPlayer);

            return account;
        }

        #endregion
    }
}
