using AchieveAchievementLibrary.JBMException;

namespace AATest
{
    public class CustomExceptionTests
    {
        #region IsBusyException
        [Test]
        public void IsBusyException_ThrowDefaultMessage_Success()
        {
            #region Arrange
            string expectedMessage = "Another operation is running, try again if the problem persist, restart the app!";
            #endregion

            #region Act && Assert
            IsBusyException? ex = Assert.Throws<IsBusyException>(() => { throw new IsBusyException(); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }

        [Test]
        public void IsBusyException_ThrowCustomMessage_Success()
        {
            #region Arrange
            string expectedMessage = "The app is busy!";
            #endregion

            #region Act && Assert
            IsBusyException? ex = Assert.Throws<IsBusyException>(() => { throw new IsBusyException(expectedMessage); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }
        #endregion

        #region NotAddedException
        [Test]
        public void NotAddedException_ThrowDefaultMessage_Success()
        {
            #region Arrange
            string expectedMessage = "Entity not added on database!";
            #endregion

            #region Act && Assert
            NotAddedException? ex = Assert.Throws<NotAddedException>(() => { throw new NotAddedException(); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }

        [Test]
        public void NotAddedException_ThrowCustomMessage_Success()
        {
            #region Arrange
            string expectedMessage = $"{nameof(Account)} not added on database!";
            #endregion

            #region Act && Assert
            NotAddedException? ex = Assert.Throws<NotAddedException>(() => { throw new NotAddedException(expectedMessage); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }

        [Test]
        public void NotAddedException_ThrowDefaultMessageCustomEntity_Success()
        {
            #region Arrange
            string expectedMessage = $"{nameof(Account)} not added on database!";
            #endregion

            #region Act && Assert
            NotAddedException? ex = Assert.Throws<NotAddedException>(() => { throw new NotAddedException(nameof(Account), NotAddedException.defaultMessage); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }
        #endregion
    }
}
